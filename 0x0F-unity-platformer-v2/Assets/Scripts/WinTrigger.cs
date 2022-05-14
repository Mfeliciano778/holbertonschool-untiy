using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    Timer timerScript;
    public GameObject player;
    public GameObject winCanvas;
    public GameObject TimerText;
    public GameObject backgroundMusic;
    public AudioSource victory;

    void Start()
    {
        timerScript = player.GetComponent<Timer>();
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        // Stop timer
        timerScript.enabled = false;
        // Stop timer canvas and activate win canvas
        TimerText.SetActive(false);
        winCanvas.SetActive(true);
        backgroundMusic.SetActive(false);

        // Player can't move camera or player and cursor is activated
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CameraController.turnSpeed = 0;

        // Call win function
        timerScript.Win();
        victory.PlayOneShot(victory.clip);
    }
}
