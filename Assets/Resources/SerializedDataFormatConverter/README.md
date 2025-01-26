# Serialized Data Format Converter

## Getting Started

Initialize
```sh
rye sync
```

Usage
```sh
rye run app --help

# rye run app input.json
rye run app chapter1.json

# rye run app -o postfix input.json
rye run app -o 1 chapter1.json

# rye run app -f 1 -t 2 -o 1 -l en chapter1.json
# f: input format version
# t: output format version
# o: output postfix
# l: output locale code (cannot affects to content. It's just for the metadata)
```
