using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    public void Delete()
	{
        Destroy(gameObject, 2f);
	}
}
