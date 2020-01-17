using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnLookAt(bool isLooked)
    {
        //Debug.Log("IsLook = " + isLooked);
        //MoveCtrl.isStopped = isLooked;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        MoveCtrl.isStopped = true;
    }

    public void OnPointerExit(PointerEventData data)
    {
        MoveCtrl.isStopped = false;
    }

    public void OnButtonClicked(string msg)
    {
        Debug.Log(msg + " is clicked !!!!");
    }

}
