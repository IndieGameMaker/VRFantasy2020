﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public void OnLookAt(bool isLooked)
    {
        Debug.Log("IsLook = " + isLooked);
        MoveCtrl.isStopped = isLooked;
    }
}
