# Story Dialogue Flows (v2)

This folder contains all the dialogues for the story. The dialogues are stored in JSON format. 

The JSON file is named ends with `.v2.flow.json`. Because the first version of the format was deprecated, and needed to distinguish the new format from the old format.

## Components

Dialogue data are splited into two components. The first stores the dialogue's flow, the second stores the content.

This directory contains the first only. The second is stored under the `/Assets/Resources/PrototypeTables` with csv format (name ends with `.v2.l10n.[locale].csv`) to support Unity's localization system.

## Manifest format

All v2 JSON files are store in this folder, and the value of `format` in the root node is `"2"`. (Because of possibility of versioning using string value, setting the value as integer is not recommended.)

```json
{
  "format": "2",
}
```
