using UnityEngine;
using TMPro;
using System.Collections;

public class QuestBoard : MonoBehaviour
{
    public TMP_Text questText;

    private bool questSeen = false;

    void OnMouseDown()
    {
        if (!questSeen)
        {
            StartCoroutine(ShowQuestInformation());
        }
    }

    IEnumerator ShowQuestInformation()
    {
        questText.text = "The monster in question is an aberrant with a mutation which gives it increased intelligence. The monster has killed the Renshaw family and is currently lurking there, occasionally bringing back prey to feast on at the house.";
        yield return new WaitForSeconds(5);
        questText.text = "In this demo scene, the investigation phase will be skipped and here are the goblin's habits, characteristics and weaknesses which will be shown below.";
        yield return new WaitForSeconds(5);
        questText.text = "Habits: Known for their love of mischief and causing trouble.Often engage in thievery and hoarding small, shiny objects.Have a penchant for creating traps and playing pranks.";
        yield return new WaitForSeconds(5);
        questText.text = "Characteristics: Small, grotesque, and humanoid with green or dark skin.Sharp teeth and claws, often depicted with large, pointed ears. Agile and quick, but not particularly strong.";
        yield return new WaitForSeconds(5);
        questText.text = "Weaknesses: Dislike of sunlight, which can weaken or harm them. Often superstitious and fearful of certain symbols or charms, such as iron or holy symbols.Prone to being outsmarted due to their impulsive nature.";
        yield return new WaitForSeconds(5);
        questText.text = "";
        questSeen = true;
    }
}
