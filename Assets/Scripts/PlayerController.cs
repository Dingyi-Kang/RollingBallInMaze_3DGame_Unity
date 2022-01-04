using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public GameObject winTextObject;

    private float speed = 5;

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);
    }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            winTextObject.SetActive(true);
        }
    }

}
