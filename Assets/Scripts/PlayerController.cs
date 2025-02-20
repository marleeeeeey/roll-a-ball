using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject capsule;
    public float moveSpeed = 0;
    
    private Rigidbody rb;
    private int counter;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        counter = 0;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            var targetColor = other.gameObject.GetComponent<Renderer>().material.color;
            capsule.GetComponent<Renderer>().material.color = targetColor;
            other.gameObject.SetActive(false);
            counter++;
        }
    }
}
