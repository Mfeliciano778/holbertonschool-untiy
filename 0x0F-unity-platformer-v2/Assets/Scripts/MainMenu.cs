using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // To use the back button in the options menu
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
    }

    public void LevelSelect(int level)
    {
        if (level == 99)
        {
            Application.Quit();
        }
        else
            SceneManager.LoadScene("Level0" + level);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
