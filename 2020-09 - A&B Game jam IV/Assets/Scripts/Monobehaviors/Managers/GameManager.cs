﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : SingletonBehaviour<GameManager>
{
    public List<GameObject> towers;
    public List<Sprite> spriteTowers;

    public SpriteRenderer spriteRenderer;

    private int currentIndex = -1;

    public GameEventInt selectedTower;
    public GameEvent startStage;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);

        startStage.Raise();
    }

    public void ChangeMouseIcon(int value)
    {
        currentIndex = value;

        if (currentIndex < 0)
            spriteRenderer.sprite = null;
        else
        {
            spriteRenderer.sprite = spriteTowers[currentIndex];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            selectedTower.Raise(-1);

        if (currentIndex < 0)
            return;

        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteRenderer.transform.position = (Vector2)worldPos;
    }

    public Sprite GetSprite()
        => spriteRenderer.sprite;
}
