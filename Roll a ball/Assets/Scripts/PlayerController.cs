using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public List<GameObject> obstacles;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the value of the variable rb by getting a reference to the rigidbody component we added to the sphere
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        // Get the movement value and store it in a Vector2 variable
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        // We want to move the ball along the x and z axis only, so y axis is 0.0
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision other) { 
        // If the player collides with an obstacle it loses all the points and the PickUps are set to active again
        if (other.gameObject.CompareTag("Obstacle"))
        {
            count = 0;
            SetCountText();

            for (int i = 0; i < 12; i++)
            {
                GameObject obstacle_i = obstacles[i];
                obstacle_i.gameObject.SetActive(true);
            }
        }
    }
}
