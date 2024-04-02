using System;
using System.Collections;
using System.Collections.Generic;
using Classes.Plants;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed Packet", menuName = "Seed Packet")]
public class SeedPacket : ScriptableObject
{
    [SerializeField] string displayName;
    [SerializeField] Plant plant;
    // Start is called before the first frame update
    public string getDisplayName()
    {
        return displayName;
    }

    public Plant getPlant()
    {
        return plant;
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Pot")){
            
    //        PotManager potManager = other.GetComponent<PotManager>();

    //        switch(displayName)
    //        {
                
    //            case("Aloe Vera"):
    //                potManager.setPlant(new AloeVera());
    //                break;
                
    //            case("Loam"):
    //                potManager.setSoil(new Soil("Loam"));
    //                break;
                
    //            case("Clay"):
    //                potManager.setSoil(new Soil("Clay"));
    //                break;
                
    //        }
            
     
    //    }
    //}
}
