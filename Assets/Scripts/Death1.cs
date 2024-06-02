using UnityEngine;

public class Death1 : MonoBehaviour
{
    // The position where the player will be teleported to
    public Vector3 teleportPosition;
    public GameObject Player;
    // Ensure the player GameObject is tagged as "Player"
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected. Teleporting to position: " + teleportPosition);
          //  Player.Position(teleportPosition);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.MovePosition(teleportPosition);
            }
            else
            {
                other.transform.position = teleportPosition;
            }
        }
        else
        {
            Debug.Log("Collision with non-player object.");
        }
    }
}
