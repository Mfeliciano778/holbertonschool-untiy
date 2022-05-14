using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleinfo : MonoBehaviour
{
    public GameObject info;
    public bool isActive = false;

    public void ToggleInfo()
    {
        if (isActive)
        {
            info.gameObject.SetActive(false);
            isActive = false;
        }
        else
        {
            info.gameObject.SetActive(true);
            isActive = true;
        }
    }
}
