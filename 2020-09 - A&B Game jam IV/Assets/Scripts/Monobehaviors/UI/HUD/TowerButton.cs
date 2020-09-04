using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TowerButton : MonoBehaviour
{
    public Camera mainCamera;

    public Sprite towerSprite;

    public int towerIndex;

    public void MouseDown()
    {
        
    }

    public void DragMouse(BaseEventData baseEvent)
    {
        PointerEventData pointerEvent = (PointerEventData)baseEvent;

        var actuallyPos = mainCamera.ScreenToWorldPoint(pointerEvent.position);
        Debug.Log(actuallyPos);
    }
}
