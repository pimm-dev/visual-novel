# Prototype Tables

These tables are not used or loaded by the game directly. They have to be used for registering their content to StringTable managed by UnityEngine.

## Getting Started

Open Localization Table Editor and create a new table. Import the table from the file. Select the file from this directory and select the file you want to import.

## Scripts

### MergeLocales.cs

This script merges multiple locale files into one file. It is useful when you want to merge two locale files into one file.

```sh
sh run.sh MergeLocales.cs --help
sh run.sh MergeLocales.cs content.en.csv content.ko.csv
sh run.sh MergeLocales.cs content.en.csv content.ko.csv --output content.csv
```

```bat
run.bat MergeLocales.cs
```

## Trouble Shooting

**Errors are occured by code in this directory at UnityEngine**

Check the directory `Main` is exists or not. If exists, remove the directory and try again.
The compiled code can affect to Unity Editor.

All of runner scripts remove the `Main` directory after the execution. If you make keyboard interrupt or stop the script, the `Main` directory can be remained.

```sh
rm -rf Main
```
