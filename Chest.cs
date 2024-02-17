using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Chest class inherits from the Colletable class
public class Chest : Colletable
{
    // Sprite to display when the chest is empty
    public Sprite emptyChest;

    // Amount of pesos (currency) inside the chest
    public int pesosAmount = 5;

    // Override the OnCollect method from the base class
    protected override void OnCollect()
    {
        // Check if the chest has not been collected yet
        if (!collected)
        {
            // Mark the chest as collected
            collected = true;

            // Change the sprite of the chest to the empty chest sprite
            GetComponent<SpriteRenderer>().sprite = emptyChest;

            // Display a floating text indicating the amount of coins collected
            GameManager.instance.ShowText(
                "+" + pesosAmount + " coins!",   // Text to display
                25,                              // Font size
                Color.yellow,                    // Text color
                transform.position,              // Position of the text
                Vector3.up * 25,                 // Offset to apply to the text position
                1.5f                             // Duration of the text display
            );
        }
    }
}
