using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Camera transform position minus the player transform position
        offset = transform.position - player.transform.position;
    }

    // LateUpdate runs one per frame, but after all of the other updates are done
    // By using it, we know that the camera will not be moved until the player moves the ball
    void LateUpdate()
    {
        // Now when the player moves the sphere the camera is moved into a new position
        // alligned with the player before tddddhe frame is displayed
        transform.position = player.transform.position + offset;
    }
}
