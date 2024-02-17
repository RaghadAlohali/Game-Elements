using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletable : Collidable
{
    // Logic to track whether the collectable has been collected
    protected bool collected;

    // Method called when a collision occurs
    protected override void OnCollide(Collider2D coll)
    {
        // Check if the collider is named "Player"
        if (coll.name == "Player")
            OnCollect(); // If the collider is the player, call the OnCollect method
    }

    // Virtual method that can be overridden by derived classes
    protected virtual void OnCollect()
    {
        // Mark the collectable as collected
        collected = true;
    }
}
