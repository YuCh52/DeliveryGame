using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Improves the speed of the turn. 
    // Attributes (Writes to disk).
    [SerializeField] float steerSpeed = 220f; 
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float destroyDelay = 0.5f;

    // Start is called before the first frame updates.
    void Start()
    {
        
    }

    // Update is called once per frame.
    void Update()
    {
        // How much the player is steering every frame and speed changes when the action occurs.
        // Time.deltaTime makes the game feel the same on different types of computers 
        // (Framerate independant)
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        // How much the player is moving up and down every frame.
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Rotates (x, y, z);
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;    
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost"){
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, destroyDelay);

        }    
    }
}
