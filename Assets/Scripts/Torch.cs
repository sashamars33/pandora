using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Torch : MonoBehaviour, Torches
{
    public bool illuminated = false;
    public Color unlitColor = Color.grey;
    public Color litColor = Color.yellow;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = unlitColor;
    }

    public void illuminate()
    {
        illuminated = true;
        spriteRenderer.color = litColor;

        Debug.Log("Torch Lit");
    }

}
