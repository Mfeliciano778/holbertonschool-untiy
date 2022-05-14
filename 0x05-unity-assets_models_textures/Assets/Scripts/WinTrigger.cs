using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    Timer timerScript;
    public Text TimerText;
    public GameObject player;

    void Start()
    {
        timerScript = player.GetComponent<Timer>();
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        timerScript.enabled = false;
        TimerText.fontSize = 80;
        TimerText.color = Color.green;
    }
}
