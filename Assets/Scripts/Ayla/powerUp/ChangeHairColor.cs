using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHairColor : MonoBehaviour
{
    public SkinnedMeshRenderer hairRenderer; // Use SkinnedMeshRenderer para personagens com animações complexas
    public Material defaultHairMaterial;
    public Material yellowHairMaterial;
    public Material blueHairMaterial;
    public Material pinkHairMaterial;

    private void Start()
    {
        hairRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public void ChangeHairToYellow()
    {
        hairRenderer.material = yellowHairMaterial;
    }

    public void ChangeHairToBlue()
    {
        hairRenderer.material = blueHairMaterial;
    }

    public void ChangeHairToPink()
    {
        hairRenderer.material = pinkHairMaterial;
    }

    public void ResetHairColor()
    {
        hairRenderer.material = defaultHairMaterial;
    }
}