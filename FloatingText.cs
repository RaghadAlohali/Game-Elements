using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

// FloatingText class for displaying floating text in the game
public class FloatingText
{
    // Indicates whether the floating text is active or not
    public bool active;

    // Reference to the GameObject containing the floating text
    public GameObject go;

    // Reference to the Text component for displaying text
    public Text txt;

    // Motion vector for the floating text movement
    public Vector3 motion;

    // Duration for which the floating text remains visible
    public float duration;

    // Time at which the floating text was last shown
    public float lastShown;

    // Method to show the floating text
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(true); // Activate the GameObject
    }

    // Method to hide the floating text
    public void Hide()
    {
        active = false;
        go.SetActive(false); // Deactivate the GameObject
    }

    // Method to update the floating text
    public void UpdateFloatingText()
    {
        if (!active)
            return; // If the floating text is not active, return without doing anything

        // If the time since the last shown is greater than the duration, hide the floating text
        if (Time.time - lastShown > duration)
            Hide();

        // Update the position of the floating text based on motion
        go.transform.position += motion * Time.deltaTime;
    }
}
