using UnityEngine;
using TMPro;
using System.Collections;

public class StartText : MonoBehaviour
{
    public TMP_Text controlText; // Reference to the TextMeshPro component
    private float displayTime = 3.0f;

    void Start()
    {
        if (controlText != null)
        {
            controlText.text = "Due to certain limitations the architecture uses a modern house instead of a medieval wooden house, this will be fixed in future versions of the game.";
            StartCoroutine(HideTextAfterDelay(displayTime));
        }
        else
        {
            Debug.LogError("ControlText TMP element is not assigned in the Inspector.");
        }
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (controlText != null)
        {
            controlText.gameObject.SetActive(false);
        }
    }
}
