using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // References to components
    private BoxCollider2D boxCollider;
    public Animator animator;
    public Rigidbody2D rb;

    // Movement variables
    Vector2 movement;
    public float moveSpeed = 5f;

    // Called when the GameObject is initialized
    private void Start()
    {
        // Get the BoxCollider2D component attached to the GameObject
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Called every frame
    private void Update()
    {
        // Get input for movement in x and y axes
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Update animator parameters based on movement input
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // Called every fixed framerate frame
    private void FixedUpdate()
    {
        // Apply movement to the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
