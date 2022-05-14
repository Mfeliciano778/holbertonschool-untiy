using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle inverToggle;

    void Start()
    {
        if (PlayerPrefs.GetInt("isInverted") == 1)
            inverToggle.isOn = true;
    }

    public void Back()
    {
        string prevScene = PlayerPrefs.GetString("lastScene");
        SceneManager.LoadScene(prevScene);
    }

    public void Apply()
    {
        if (inverToggle.isOn == true)
            PlayerPrefs.SetInt("isInverted", 1);
        else
        {
            PlayerPrefs.SetInt("isInverted", 0);
        }
        Back();
    }

    public void KeybindScreen()
    {
        SceneManager.LoadScene("Keybinds");
    }
}
