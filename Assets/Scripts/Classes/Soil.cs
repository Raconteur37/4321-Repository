using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[CreateAssetMenu(fileName = "New Soil", menuName = "Soil")]
public class Soil : ScriptableObject
{
    [SerializeField] private string type, status; // The type of soil, Sandy, Loam, or Clay as well as the status of the soil, Dry or Moist.
    
    public Soil(string type)
    {
        this.type = type;
    }

    public string getType()
    {
        return type;
    }
    
    
}
