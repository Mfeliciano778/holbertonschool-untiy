using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTrigger : MonoBehaviour
{
    Timer timerScript;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       timerScript = player.GetComponent<Timer>();
    }
    void OnTriggerExit(Collider collider)
    {
        timerScript.enabled = true;
        gameObject.SetActive(false);
    }
}
