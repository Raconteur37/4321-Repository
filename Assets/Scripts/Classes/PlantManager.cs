using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlantManager : MonoBehaviour
{

    public Plant plant;
    public Soil soil;

    

    public Plant getPlant()
    {
        return plant;
    }

    public Soil getSoil()
    {
        return soil;
    }

    public void Update()
    {
        
    }
    public void SubtractWater(double amount)
    {

        plant.setWaterAmount(plant.getWaterAmount() - amount);

        // The method that detracts water based on the tick rate
    }
}
