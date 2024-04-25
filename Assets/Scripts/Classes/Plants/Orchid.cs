using System.Collections;
using System.Collections.Generic;
using Classes.Plants;
using UnityEngine;

public class Orchid : PlantClass
{
    public Orchid()
    {
            
        setPlantName("Orchid");
        setDescription("The Orchid is a very unique plant and is loved by many.\n The orchid needs a lot of sun and will consume it more than a lot of other plants. \n" +
                       "It needs a decent amount of water, and overall is a high maintenance plant.\n The preferred soil type is Clay!");
            
        setWaterDrainMultiplier(.6); // Needs decent amount of water
            
        setSunDrainMultiplier(.7); // Needs a lot of sun
            
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
