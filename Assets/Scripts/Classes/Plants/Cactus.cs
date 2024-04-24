using System.Collections;
using System.Collections.Generic;
using Classes.Plants;
using UnityEngine;

public class Cactus : PlantClass
{
    
    public Cactus()
    {
            
        setPlantName("Cactus");
        setDescription("The Cactus is a very popular plant and is in usually high demand.\n The cactus needs the most sun of any plant and the least amount of water. \n" +
                       "The preferred soil type is Loam and it loves hot temperatures!");
            
        setWaterDrainMultiplier(.1); // Doesnt need that much water so it'll drain slower
            
        setSunDrainMultiplier(.7); // Needs a lot of sun
            
        setSunMinRange(60); 
        setWaterMinRange(10);
            
        setSunDecayThresh(getSunMinRange() * .3);
        setWaterDecayThresh(getWaterMinRange() * .2);
            
        setSunMaxRange(200);
        setWaterMaxRange(50);
            
        setSunlightAmount(65); // Default: 50
        setWaterAmount(30); // Default: 50
            
        setGrowing(true);
            
        setStatus(0.01);
        setStatusCap(1f);
            
        setState("Seedling");
            
        setPerferedSoil("Loam");
            
        setHealthString("Healthy");
            
    }
    
}
