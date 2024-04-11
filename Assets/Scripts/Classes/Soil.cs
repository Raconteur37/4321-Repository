using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil
{
    private string type, status = "Moist"; // The type of soil, Sandy, Loam, or Clay as well as the status of the soil, Dry or Moist.
    
    public Soil(string type)
    {
        this.type = type;
    }

    public string getType()
    {
        return type;
    }
    
    
}
