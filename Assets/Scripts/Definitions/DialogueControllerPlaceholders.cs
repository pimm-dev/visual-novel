using System.Collections;
using System.Collections.Generic;

public class DialogueControllerLogicPlaceholders
{
    public static IEnumerator<string> _chapterOrders()
    {
        /**
         * ACTION REQUIRED:
         *   There aren't any field to direct the next flow of the dialogue currently.
         *   Implement the logic to determine the next chapter ID after update format.
         *   This method is a placeholder for the logic to determine the next chapter ID.
         */
        yield return "1";
        yield return "2";
        yield return "3";
        yield return "4";
        yield return "5";
        yield return "6";
        /**
         * Implementation example:
         *   DialogueContainer dialogueContainer;
         *   if (dialogueContainer.next != null) { yield return next; }
         */
    }

    public static IEnumerator<string> GetNextChapterID = _chapterOrders();
}
