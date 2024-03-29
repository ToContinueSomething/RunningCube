using Movement.Source.Modules.Movement.Scripts;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; // reference to the player's Transform component
    public float smoothing; // the rate at which the camera moves towards the target position
    ShipMovement movement;
    private Vector3 offset; // the distance between the camera and the player

    void Start()
    {
        offset = transform.position - target.transform.position;
        movement = target.GetComponent<ShipMovement>();
    }

    void FixedUpdate()
    {
        // Find all player objects in the scene
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Get the player with the highest y position
        float highestY = float.NegativeInfinity;
        GameObject targetPlayer = null;
        foreach (GameObject player in players)
        {
            if (player.transform.position.y > highestY)
            {
                highestY = player.transform.position.y;
                targetPlayer = player;
            }
        }

        if (targetPlayer != null)
        {
            Vector3 targetCamPos = targetPlayer.transform.position + offset;

            // Clamp the y position of the camera to avoid showing outside of the game area
          //  targetCamPos.y = Mathf.Clamp(targetCamPos.y, -2.16f, 4.5f);
          targetCamPos.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, Time.deltaTime * smoothing);
        }
    }
}