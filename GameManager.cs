using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static instance of the GameManager to allow access from other scripts
    public static GameManager instance;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        // Subscribe to the sceneLoaded event to handle state loading
        SceneManager.sceneLoaded += LoadState;

        // Make GameManager persistent across scene changes
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprite;
    public List<Sprite> weaponSprite;
    public List<int> weaponPrice;
    public List<int> xpTable;

    // References
    public Player player;
    //public weapon weapon
    public FloatingTextManager floatingTextManager;

    // Logic
    public int pesos;
    public int experience;

    // Method to display floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Save State
    /*
     * INT preferredSkin
     * INT pesos
     * INT experience
     * INT weaponLevel
     */
    public void SaveState()
    {
        string s = "";
        s += "0" + "|"; // Placeholder for preferred skin
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0"; // Placeholder for weapon level

        PlayerPrefs.SetString("SaveState", s);
    }

    // Load State
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        // Check if there's no saved state
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        // Split the saved state data and parse it
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        // Change player skin and weapon level accordingly
        Debug.Log("LoadState");
    }
}
