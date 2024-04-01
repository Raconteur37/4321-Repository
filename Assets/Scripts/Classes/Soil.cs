using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[CreateAssetMenu(fileName = "New Soil", menuName = "Soil")]
public class Soil : ScriptableObject
{
    [SerializeField] private string type, status = "Moist"; // The type of soil, Sandy, Loam, or Clay as well as the status of the soil, Dry or Moist.
    
    
    public Soil(string type)
    {
        this.type = type;
    }

    public string getType()
    {
        return type;
    }

    public void onTriggerEnter(Collider other)
    {
        
        Debug.Log("Triggered the event");
        
        if (other.CompareTag("Pot"))
        {
            PotManager potManager = other.GetComponent<PotManager>();

            switch(type)
            {
                
                case("Sandy"):
                    potManager.setSoil(new Soil("Sandy"));
                    break;
                
                case("Loam"):
                    potManager.setSoil(new Soil("Loam"));
                    break;
                
                case("Clay"):
                    potManager.setSoil(new Soil("Clay"));
                    break;
                
            }
            
            potManager.updateSoilGO();
            

        }
    }
    
    
}
