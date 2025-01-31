import argparse
from .lib import dialogue_v2 as v2

def app():
    parser = argparse.ArgumentParser(description='Convert serialized data format')
    parser.add_argument('-f', '--input-format', type=int, default=1, help='Input format version')
    parser.add_argument('-t', '--output-format', type=int, default=2, help='Output format version')
    parser.add_argument('-o', '--output', type=str, default="(based on input)", help='Output file name')
    parser.add_argument('-l', '--locale', type=str, default="ko", help='Locale code')
    parser.add_argument('input', type=str, help='Input file name')
    
    args = parser.parse_args()
    
    if args.input_format == 1 and args.output_format == 2:
        output_postfix = ""
        if args.output == "(based on input)":
            output_postfix = None
        else:
            output_postfix = args.output
        v2.convert_file(args.input, args.locale, output_postfix)
    else:
        args.print_help()

if __name__ == '__main__':
    app()
