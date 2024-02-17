using UnityEngine;

// Portal class inherits from Collidable
public class Portal : Collidable
{
    // Name of the scene to teleport the player to
    public string sceneName;

    // Called when the collider attached to this GameObject collides with another collider
    protected override void OnCollide(Collider2D coll)
    {
        // Check if the collider's name is "Player"
        if (coll.name == "Player")
        {
            // Save the game state before teleporting the player
            GameManager.instance.SaveState();

            // Load the scene specified by sceneName
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
