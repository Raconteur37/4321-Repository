using System.Collections;
using System.Collections.Generic;
using Classes.Plants;
using UnityEngine;

public class Orchid : PlantClass
{
    public Orchid()
    {
            
        setPlantName("Orchid");
            
        setWaterDrainMultiplier(.6); // Needs decent amount of water
            
        setSunDrainMultiplier(.6); // Needs a lot of sun
            
        setSunMinRange(50); 
        setWaterMinRange(50);
            
        setSunDecayThresh(getSunMinRange() * .5);
        setWaterDecayThresh(getWaterMinRange() * .5);
            
        setSunMaxRange(100);
        setWaterMaxRange(100);
            
        setSunlightAmount(60); // Default: 50
        setWaterAmount(55); // Default: 50
            
        setGrowing(true);
            
        setStatus(0.01);
        setStatusCap(1f);
            
        setState("Seedling");
            
        setPerferedSoil("Clay");
            
        setHealthString("Healthy");
            
    }
}
