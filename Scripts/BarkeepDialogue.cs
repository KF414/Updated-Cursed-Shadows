using UnityEngine;
using TMPro;
using System.Collections;

public class BarkeepDialogue : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Transform player;
    public Transform barkeep;
    private bool canInteract = false;
    public bool QuestCompleted = false;

    void Update()
    {
        if (Vector3.Distance(player.position, barkeep.position) <= 14.0f)
        {
            canInteract = true;

            if (Input.GetMouseButtonDown(0) && canInteract)
            {
                if (!QuestCompleted)
                {
                    StartCoroutine(BarkeepQuestDialogue());
                }
                else
                {
                    StartCoroutine(BarkeepAfterQuestDialogue());
                }
            }
        }
        else
        {
            canInteract = false;
        }
    }

    private IEnumerator BarkeepQuestDialogue()
    {
        string[] dialogue = {
            "Duke Rain: Good morrow. I have heard tell of unrest at the old Renshaw manor.",
            "Bartender: Aye, milord. That place be accursed now. A foul goblin hath taken residence, slaying the hapless souls who once dwelt there.",
            "Duke Rain: Why hath no one dispatched this creature?",
            "Bartender: Fear, milord. The beast hath tasted blood. They say 'tis no mere goblin now, but something far more sinister.",
            "Duke Rain: I shall see to it personally.",
            "Bartender: Brave words, milord, or mayhap foolhardy. But if ye succeed, ye shall be hailed as a hero. And your cups shall ever be filled.",
            "Duke Rain: Have a cask ready. I shall return anon.",
            "Bartender: Godspeed, Duke Rain. You shall need His favour."
        };

        foreach (string line in dialogue)
        {
            dialogueText.text = line;
            yield return new WaitForSeconds(3);
        }
        dialogueText.text = "";
    }

    private IEnumerator BarkeepAfterQuestDialogue()
    {
        string[] dialogue = {
            "Bartender: Thank you, Duke. Here is your reward: 30 gold and +5 reputation.",
            "Duke Rain: Thank you. Fare thee well.",
            "Bartender: And to you, milord. May your next adventure be less perilous."
        };

        foreach (string line in dialogue)
        {
            dialogueText.text = line;
            yield return new WaitForSeconds(3);
        }
        dialogueText.text = "";
    }
}
