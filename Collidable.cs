using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Collidable class inherits from MonoBehaviour
public class Collidable : MonoBehaviour
{
    // Contact filter for collision detection
    public ContactFilter2D filter;

    // Reference to the BoxCollider2D component attached to the GameObject
    private BoxCollider2D boxCollider;

    // Array to store colliders that are detected in collisions
    private Collider2D[] hits = new Collider2D[10];

    // Called when the object is initialized
    protected virtual void Start()
    {
        // Get the BoxCollider2D component attached to the GameObject
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Called every frame
    protected virtual void Update()
    {
        // Perform collision detection using the BoxCollider2D and ContactFilter2D
        boxCollider.Overlap(filter, hits);

        // Iterate through the detected colliders
        for (int i = 0; i < hits.Length; i++)
        {
            // If the collider is null, continue to the next iteration
            if (hits[i] == null)
                continue;

            // Call the OnCollide method and pass the detected collider
            OnCollide(hits[i]);

            // Clean the hits array to prepare it for the next frame
            hits[i] = null;
        }
    }

    // Method called when a collision occurs
    protected virtual void OnCollide(Collider2D coll)
    {
        // Log the name of the collided GameObject
        Debug.Log(coll.name);
    }
}
