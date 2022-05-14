using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public GameObject player;
    public GameObject TimeCanvas;
    public GameObject CutsceneControl;
    public Animator anim;
    public GameObject MainCamera;
    PlayerController playerC;

    // Start is called before the first frame update
    void Start()
    {
        playerC = player.GetComponent<PlayerController>();
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            EndAnim();
        
    }


    // Finished Animation now allow for the player to play
    void EndAnim()
    {
        TimeCanvas.SetActive(true);
        MainCamera.SetActive(true);
        playerC.enabled = true;
        CutsceneControl.gameObject.SetActive(false);   
    }
}
