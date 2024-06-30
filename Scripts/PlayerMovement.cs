using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float rotationSpeed = 100f; // Rotation speed
    public Vector3 startingV3;
    public bool respawn;

    private Rigidbody rb;
    public GameObject player;
    public GameObject goblin;
    private GameObject activeCharacter;

    void Start()
    {
        startingV3 = transform.position;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        rb.freezeRotation = true; // Freeze rotation to prevent falling

        // Set Rigidbody collision detection to Continuous Dynamic
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        // Initialize active character
        activeCharacter = player;
        player.SetActive(true);
        goblin.SetActive(false);
    }

    void Update()
    {
        // Switch character with "O" key
        if (Input.GetKeyDown(KeyCode.O))
        {
            SwitchCharacter();
        }

        if (activeCharacter != null && activeCharacter == player)
        {
            // Calculate rotation based on mouse movement
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, mouseX);

            // Calculate movement based on keyboard input
            float moveInput = Input.GetAxis("Vertical");
            Vector3 movement = transform.forward * moveInput;

            // Add strafing movement based on A and D keys
            float strafeInput = Input.GetAxis("Horizontal");
            movement += transform.right * strafeInput;

            // Apply movement using Rigidbody velocity
            rb.velocity = movement * moveSpeed;

            if (respawn)
            {
                transform.position = startingV3;
                respawn = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Doom")
        {
            respawn = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            Rigidbody crateRb = collision.collider.GetComponent<Rigidbody>();
            if (crateRb != null)
            {
                Vector3 pushDirection = collision.contacts[0].point - transform.position;
                pushDirection = -pushDirection.normalized;
                crateRb.AddForce(pushDirection * moveSpeed, ForceMode.Impulse);
            }
        }
    }

    public void SwitchCharacter()
    {
        if (activeCharacter == player)
        {
            activeCharacter = goblin;
            player.SetActive(false);
            goblin.SetActive(true);
        }
        else
        {
            activeCharacter = player;
            goblin.SetActive(false);
            player.SetActive(true);
        }
    }

    public void SwitchToPlayer()
    {
        activeCharacter = player;
        player.SetActive(true);
        if (goblin != null)
        {
            goblin.SetActive(false);
        }
    }
}
