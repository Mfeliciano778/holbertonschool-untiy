using System;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown("escape") && pauseCanvas.activeInHierarchy)
            Resume();
        else if (Input.GetKeyDown("escape") && !pauseCanvas.activeInHierarchy)
            Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        CameraController.turnSpeed = 0;

        if (Timer.timer != null)
        {
            Timer.timer.Stop();
        }
        pauseCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        CameraController.turnSpeed = 1;
        if (Timer.timer != null)
        {
            Timer.timer.Start();
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        CameraController.turnSpeed = 1;
        if (Timer.timer != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Options");
    }
}
