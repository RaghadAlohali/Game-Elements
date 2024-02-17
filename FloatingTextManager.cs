using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

// FloatingTextManager class manages the creation and display of floating text in the game
public class FloatingTextManager : MonoBehaviour
{
    // Reference to the container for the floating text GameObjects
    public GameObject textContainer;

    // Reference to the prefab used for creating floating text
    public GameObject textPrefab;

    // List to keep track of active floating texts
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    // Called every frame
    private void Update()
    {
        // Update all active floating texts
        foreach (FloatingText txt in floatingTexts)
            txt.UpdateFloatingText();
    }

    // Method to show a floating text message
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        // Get a FloatingText object from the pool
        FloatingText floatingText = GetFloatingText();

        // Set text properties
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;

        // Set position in screen space
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); // Transform world space to screen space
        floatingText.motion = motion;
        floatingText.duration = duration;

        // Show the floating text
        floatingText.Show();
    }

    // Method to get a FloatingText object from the pool or create a new one if none are available
    private FloatingText GetFloatingText()
    {
        // Find the first inactive floating text in the list
        FloatingText txt = floatingTexts.Find(t => !t.active);

        // If no inactive floating text is found, create a new one
        if (txt == null)
        {
            // Instantiate a new floating text prefab
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform); // Set the parent to the text container
            txt.txt = txt.go.GetComponent<Text>();

            // Add the new floating text to the list
            floatingTexts.Add(txt);
        }
        return txt;
    }
}
