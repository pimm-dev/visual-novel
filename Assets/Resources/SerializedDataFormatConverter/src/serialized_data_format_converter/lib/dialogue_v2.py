import os
from json import loads, dumps

OUTPUT_L10N_LOCALE = "ko"

LOCALES = {
    "en": "English(en)",
    "ko": "Korean(ko)",
}

BACKGROUND_V1_TO_V2 = [
    "hall",
    "black",
    "bedroom",
    "classroom_testing",
    "classroom",
    "campus_overview",
    "forest",
    "front_gate",
    "hallway",
    "alchemy"
]

CHARACTER_V1_TO_V2 = [
    "elina",
    "cecilia",
    "sophia",
    "coco",
    "player",
    "narration",
    "principal",
    "professor",
    "student",
]


def convert(data: dict, postfix: str="0") -> tuple:
    """
    Required: Dialogue data in format v1
    Returns: (Dialogue data in format v2, l10n table)
    """

    next_root = {
        "format": "2",
        "dialogueTablePostfix": postfix,
        "dialogueFlow": [],
    }

    next_dialogue_flow_block = {
        "dialogueFlowID": "",
        "backgroundID": "",
        "dialogues": [],
    }

    next_dialogue_block = {
        "dialogueID": "",
        "characterID": "",
        "l10nContentID": "",
    }

    next_l10n_table = {}

    dialogue_flow = []
    for i in range(len(data["scenes"])):
        scene = data["scenes"][i]

        next_dialogue_flow_block = {
            "dialogueFlowID": f"chap{postfix}d{i}",
            "backgroundID": BACKGROUND_V1_TO_V2[scene["background"]],
            "dialogues": [],
        }
        
        for j in range(len(scene["dialogueDatas"])):
            dialogue = scene["dialogueDatas"][j]
            l10n_content_id = f"chap{postfix}d{i}t{j}"
            next_dialogue_block = {
                "dialogueID": "",
                "characterID": "",
                "l10nContentID": "",
            }
            next_dialogue_block["dialogueID"] = dialogue["dialogueID"]
            next_dialogue_block["characterID"] = CHARACTER_V1_TO_V2[dialogue["character"]]
            next_dialogue_block["l10nContentID"] = l10n_content_id
            next_dialogue_flow_block["dialogues"].append(next_dialogue_block)
            next_l10n_table[l10n_content_id] = dialogue["text"]
        
        next_root["dialogueFlow"].append(next_dialogue_flow_block)
    
    return (next_root, next_l10n_table)

def render_l10n_table(display_locale: str, l10n_table: dict) -> str:
    strbuf = [f"Key,Id,{display_locale}"]
    for k, v in l10n_table.items():
        strbuf.append(f"{k},,{v}")
    return "\n".join(strbuf)

def convert_file(path: str, locale_code: str=OUTPUT_L10N_LOCALE, postfix: str=None) -> None:
    if not os.path.exists(path):
        raise ValueError(f"File not found: {path}")
    data = loads(open(path, encoding="utf-8").read())

    locale = None
    if locale_code in LOCALES:
        locale = LOCALES[locale_code]
    else:
        locale = locale_code

    if postfix is None:
        postfix = "".join([each for each in os.path.basename(path).split(".")[0] if each.isdigit()])
    
    next_dialogue_json, next_l10n_table = convert(data, postfix)
    
    starts = path.split(".")[0]
    with open(f"{starts}.v2.flow.json", "w", encoding="utf-8") as f:
        f.write(dumps(next_dialogue_json, ensure_ascii=False, indent=4))
    with open(f"{starts}.v2.l10n.{locale_code}.csv", "w", encoding="utf-8") as f:
        f.write(render_l10n_table(locale, next_l10n_table))

if __name__ == "__main__":
    convert_file("chapter1.json", "ko")
