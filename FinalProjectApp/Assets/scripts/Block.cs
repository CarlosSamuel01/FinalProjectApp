using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int number;
    public TextMeshPro textMesh;

    void Awake()
    {
        textMesh = GetComponentInChildren<TextMeshPro>();
        UpdateText();
    }

    void OnValidate()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        if (textMesh != null)
        {
            textMesh.text = number.ToString();
        }
    }
}
