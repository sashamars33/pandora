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
    public string torchID;
    public GameObject torchMask;

    private SpriteRenderer spriteRenderer;
 


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


        // Load the persisted state
        illuminated = PlayerPrefs.GetInt(torchID, 0) == 1;
        UpdateVisuals();
        // Ensure mask starts inactive
    }


    // Call this to light the torch
    public void illuminate()
    {
        if (!illuminated)
        {
            illuminated = true;
            UpdateVisuals();

            
            // Activate mask when lit
            if (torchMask != null) torchMask.SetActive(true);

            // Save state
            PlayerPrefs.SetInt(torchID, 1);
            PlayerPrefs.Save();

            Debug.Log($"Torch {torchID} Lit");
        }
    }
    
      private void UpdateVisuals()
    {

        if (spriteRenderer != null)
        {
            spriteRenderer.color = illuminated ? litColor : unlitColor;
        }

        // Enable or disable the mask depending on illumination
        if (torchMask != null)
        {
            torchMask.SetActive(illuminated);
        }

    }


}
