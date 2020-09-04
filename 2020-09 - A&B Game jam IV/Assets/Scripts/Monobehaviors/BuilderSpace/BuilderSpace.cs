using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuilderSpace : LazyBehavior
{
    [SerializeField, ReadOnly] private bool isEmpty = true;


    public Color possibleColor;
    public Color impossibleColor;

    private Color originalColor;

    private void Start()
    {
        originalColor = spriteRenderer.color;
    }

    public void ChangeColorBasedOnEmptyness()
    {
        spriteRenderer.color = CanInsertBuild() ? possibleColor : impossibleColor;
    }

    public void ChangeColorToOriginal()
    {
        spriteRenderer.color = originalColor;
    }

    public void MyMouseUp(BaseEventData baseEvent)
    {
        var pointerEvent = (PointerEventData)baseEvent;

        var worldPos = Camera.main.ViewportToWorldPoint(pointerEvent.position);
        
        var currentSprite = GameManager.instance.GetSprite();
        if (currentSprite)
        {
            spriteRenderer.color = possibleColor;
            spriteRenderer.sprite = currentSprite;

            isEmpty = false;
        }
    }

    private bool CanInsertBuild()
        => isEmpty;
}
