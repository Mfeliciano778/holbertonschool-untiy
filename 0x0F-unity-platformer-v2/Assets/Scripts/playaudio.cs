using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playaudio : MonoBehaviour
{
    public AudioSource hoverAudio;
    public AudioSource clickAudio;

    // Play audio clip on hover
    public void PlayOnHover()
    {
        hoverAudio.PlayOneShot(hoverAudio.clip);
    }

    // Play audio clip on click
    public void PlayOnClick()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
    }
}
