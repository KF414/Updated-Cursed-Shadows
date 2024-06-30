using UnityEngine;
using TMPro;
using System.Collections;

public class NetWithText : MonoBehaviour
{
    public GameObject player;
    public GameObject goblin;
    public float immobilizeDuration = 3f; // Updated to 3 seconds
    public TMP_Text messageText; // TextMeshPro Text for messages
    private bool goblinInside = false;
    private BarkeepDialogue barkeepDialogue;

    private void Start()
    {
        barkeepDialogue = FindObjectOfType<BarkeepDialogue>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == goblin)
        {
            if (!goblinInside)
            {
                goblinInside = true;
                StartCoroutine(ImmobilizeGoblin());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == goblin)
        {
            goblinInside = false;
        }
    }

    private IEnumerator ImmobilizeGoblin()
    {
        // Disable goblin movement
        PlayerMovement goblinMovement = goblin.GetComponent<PlayerMovement>();
        goblinMovement.enabled = false;

        // Display capture message
        yield return ShowMessage("Goblin has been captured", 5f);

        // Wait for the immobilize duration
        yield return new WaitForSeconds(immobilizeDuration);

        // Destroy goblin and net
        Destroy(goblin);
        Destroy(gameObject);

        // Switch control back to the player
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.SwitchToPlayer();

        // Ensure player and its camera are active
        player.SetActive(true);
        Camera.main.transform.SetParent(player.transform);
        Camera.main.transform.localPosition = new Vector3(0, 1.6f, 0); // Adjust the camera position if needed


        // Notify BarkeepDialogue about the quest completion
        if (barkeepDialogue != null)
        {
            barkeepDialogue.QuestCompleted = true;
        }
    }

    private IEnumerator ShowMessage(string message, float duration)
    {
        messageText.text = message;
        yield return new WaitForSeconds(duration); // Display message for the specified duration
        messageText.text = ""; // Clear dialogue text after the specified duration
    }
}
