using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace IO.GitHub.ShapeLayer.Utilities
{
    public class MergeLocales
    {
        /**
        * NOTICE: Because this code is intended to be executed by `run.bat` or `run.sh`,
        * the PATH_OFFSET have to be set looking at the execution environment.
        * Since the runner script exectues this code from `main/` directory, the PATH_OFFSET is `../`.
        */
        public const string PATH_OFFSET = "../";

        public static void PrintUsage()
        {
            Console.WriteLine
            (
                "Usage: MergeLocales [FILE*]\n" + 
                "---\n" +
                "   Merge multiple locale files into one file.\n" +
                "   [FILE*] are must be CSV files that compatible with Unity's Localization Table.\n" +
                "   The first file will be used as a base file. (Recommand: first file is English)\n" +
                "Options:\n" +
                "  -o, --output: Output file path. (default: `merged.csv`)\n" +
                "  -h, --help: Show this message and exit."
            );
        }

        public static void Main(string[] args)
        {
            string output = "merged.csv";
            List<string> files = new List<string>();
            RunnerArgs optionArgsTriggered = RunnerArgs.None;
            bool operationInterruptRequested = false;
            foreach (string arg in args)
            {
                // Handle if parsing option arguments has been triggered by previous argument
                switch (optionArgsTriggered)
                {
                    case RunnerArgs.Output:
                        output = arg;
                        optionArgsTriggered = RunnerArgs.None;
                        operationInterruptRequested = true;
                        break;
                }

                if (operationInterruptRequested)
                {
                    operationInterruptRequested = false;
                    continue;
                }

                // Parse option arguments
                if (arg == "-h" || arg == "--help")
                {
                    PrintUsage();
                    return;
                }
                else if (arg == "-o" || arg == "--output")
                {
                    optionArgsTriggered = RunnerArgs.Output;
                    continue;
                }
                else
                {
                    if (!arg.EndsWith(".csv"))
                    {
                        Console.WriteLine($"Error: {arg} file seems not a CSV file.");
                        return;
                    }
                    if (!File.Exists(Path.Combine(PATH_OFFSET, arg)))
                    {
                        Console.WriteLine($"Error: {arg} file not found.");
                        return;
                    }
                    files.Add(arg);
                }
            }
            MergeFiles(files, output);
        }

        public static void MergeFiles(List<string> files, string output)
        {
            LocaleMerger merger = new LocaleMerger();
            foreach (string file in files)
            {
                string csv = File.ReadAllText(Path.Combine(PATH_OFFSET, file));
                string[][] parsed = CSVParser.ParseCSV(csv);
                string[] header = parsed[0];

                int keyField = Array.IndexOf(parsed[0], "Key");
                if (keyField == -1)
                {
                    Console.Error.WriteLine($"Error: {file} file does not have `Key` field.");
                    return;
                }

                string[] excludes = { "Key", "Id" };
                int[] localeFound = (
                    from i in Enumerable.Range(0, header.Length)
                    where !excludes.Contains(header[i])
                    select i
                ).ToArray();
                
                string[] row;
                Dictionary<string, string> contents;  // <Key, Content>
                foreach (int locale in localeFound)
                {
                    contents = new Dictionary<string, string>();
                    for (int i = 1; i < parsed.Length; i++)
                    {
                        contents.Add(parsed[i][keyField], parsed[i][locale]);
                    }
                    merger.AddContentsWithLocale(header[locale], contents);
                }
            }
            
            LocaleValidationResult result = merger.ValidateIsComplete();
            if (!result.isComplete)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning: Some contents are missed in locales:");
                foreach (Tuple<string, string> missed in result.missed)
                {
                    Console.WriteLine($"  - {missed.Item1} in {missed.Item2}");
                }
                Console.ResetColor();
            }

            if (File.Exists(Path.Combine(PATH_OFFSET, output)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {output} file already exists. It will be overwritten.");
                Console.ResetColor();
            }
            File.WriteAllText(Path.Combine(PATH_OFFSET, output), merger.RenderStringTableToCSV());

            Console.WriteLine($"Merged locales are saved to {output}.");
        }
    }

    public enum RunnerArgs
    {
        None,
        Help,
        Output
    }

    public class LocaleValidationResult
    {
        public bool isComplete { get; set; }
        public List<Tuple<string, string>> missed { get; set; }
        public LocaleValidationResult()
        {
            isComplete = true;
            missed = new List<Tuple<string, string>>();
        }
    }

    public class CSVParser
    {
        public static string[] ParseCSVLine(string line)
        {
            List<string> fields = new List<string>();
            string field = "";
            bool inQuote = false;
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '"')
                {
                    inQuote = !inQuote;
                }
                else if (c == ',' && !inQuote)
                {
                    fields.Add(field);
                    field = "";
                }
                else
                {
                    field += c;
                }
            }
            fields.Add(field);
            return fields.ToArray();
        }

        public static string[][] ParseCSV(string csv)
        {
            string[] lines = csv.Split('\n');
            string[][] parsed = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                parsed[i] = ParseCSVLine(lines[i]);
            }
            return parsed;
        }
    }

    public class LocaleMerger
    {
        // for validating contents are not missed in each locale
        private List<string> _locales = new List<string>();

        // key: `string` Content Identifier Key, value: Locale key(locale)-value(content) pairs
        private Dictionary<string, Dictionary<string, string>> _contents = new Dictionary<string, Dictionary<string, string>>();
        
        public void AddContentIdentifiers(List<string> contentIdentifiers)
        {
            foreach (string contentIdentifier in contentIdentifiers)
            {
                _contents.Add(contentIdentifier, new Dictionary<string, string>());
            }
        }

        public void AddContentsWithLocale(string locale, Dictionary<string, string> contents)
        {
            if (!_locales.Contains(locale))
            {
                _locales.Add(locale);
            }

            foreach (KeyValuePair<string, string> content in contents)
            {
                if (!_contents.ContainsKey(content.Key))
                {
                    _contents.Add(content.Key, new Dictionary<string, string>());
                }
                _contents[content.Key].Add(locale, content.Value);
            }
        }

        public LocaleValidationResult ValidateIsComplete()
        {
            LocaleValidationResult result = new LocaleValidationResult();
            foreach (KeyValuePair<string, Dictionary<string, string>> content in _contents)
            {
                if (content.Value.Count != _locales.Count)
                {
                    foreach (string locale in _locales)
                    {
                        if (!content.Value.ContainsKey(locale))
                        {
                            result.isComplete = false;
                            result.missed.Add(new Tuple<string, string>(content.Key, locale));
                        }
                    }
                }
            }
            return result;
        }

        public string RenderStringTableToCSV()
        {
            string csv = "";
            csv += "Key,Id";
            foreach (string locale in _locales)
            {
                csv += $",{locale}";
            }
            csv += "\n";

            foreach (KeyValuePair<string, Dictionary<string, string>> content in _contents)
            {
                csv += content.Key;
                csv += ",";  // let Id field empty
                foreach (string locale in _locales)
                {
                    csv += $",{content.Value[locale]}";
                }
                csv += "\n";
            }

            return csv;
        }
    }
}
