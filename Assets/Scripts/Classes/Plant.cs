using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
{

    [SerializeField] private double waterRangePercent, sunlightPercentage, status; // All will be out of a decimal from 0-1...indicating the percentage of their respective range...status is the overall 
        // percent that they are at 0 being a seed, 1 being fully grown.
    [SerializeField] private double waterDrainMultiplier, sunlightDrainMultiplier; // These will be case by case for each plant and determine how much sunlight and water will drain
        // every tick
    [SerializeField] private double waterAmount, sunlightAmount; // These are int amount of water and sun you can give to a plant
    [SerializeField] private int waterMinRange, sunlightMinRange = 0; // These are the ranges of the sunlight and the water needed to maintain the plant...
        // These will be initiated on a plant by plant basis depending on the type of plant you are trying to grow
    [SerializeField] private int waterMaxRange, sunlightMaxRange;
    [SerializeField] private string plantName, ownerName, healthString, state, description; // Basic string values...state is the current state the plant is in 
    [SerializeField] private Sprite plantImage; // Sprite of the image of the plant pulled from web API
    [SerializeField] private Mesh mesh;
    [SerializeField] private bool isGrowing, hasSunlight, isFullyGrown, waterIsInRange, sunlightIsInRange;

    public Plant() // Add a constructor for the persons' name
    {
        
    }

    public void updatePlant()
    {

        double sunAmountDrain = 1 * sunlightDrainMultiplier;
        double waterAmountDrain = 1 * waterDrainMultiplier;

        sunlightAmount -= sunAmountDrain;
        waterAmount -= waterAmountDrain;
        
        if (waterAmount >= waterMinRange && waterAmount <= waterMaxRange && sunlightAmount >= sunlightMinRange &&
            sunlightAmount <= sunlightMaxRange)
        {
            
            
            
            
        }
        
        
        
        
        
        
        
        
    }

    public void setPlantName(string name)
    {
        plantName = name;
    }
    
    public double getWaterRangePercent()
    {
        return 0.0;
    }

    public double getSunlightPercentage()
    {
        return 0.0;
    }

    public double getWaterAmount()
    {
        return waterAmount;
    }

    public double getSunlightAmount()
    {
        return sunlightAmount;
    }

    public bool getWaterIsInRange()
    {
        // This method will compare the water range percentage with the min and max range, and will return a boolean variable indicating as to whether it should be wilting or not.
        return waterIsInRange;
    }

    public double getWaterDrainMultiplier()
    {
        return waterDrainMultiplier;
    }

    public void setWaterDrainMultiplier(double mult) // Drain multipliers work such that the smaller the value...the less you need for them
    {
        waterDrainMultiplier = mult;
    }

    public void setSunDrainMultiplier(double mult)
    {
        sunlightDrainMultiplier = mult;
    }

    public void setWaterMinRange(int minRange)
    {
        waterMinRange = minRange;
    }

    public void setSunMinRange(int minRange)
    {
        sunlightMinRange = minRange;
    }

    public void setWaterMaxRange(int maxRange)
    {
        waterMaxRange = maxRange;
    }

    public void setSunMaxRange(int maxRange)
    {
        sunlightMaxRange = maxRange;
    }

    public void setSunlightAmount(int amount)
    {
        sunlightAmount = amount;
    }

    public void setWaterAmount(int amount)
    {
        waterAmount = amount;
    }

    public void setGrowing(bool growing)
    {
        isGrowing = growing;
    }

    public void setStatus(double status)
    {
        this.status = status;
    }

    public void setState(string state)
    {
        this.state = state;
    }

    public void setHealthString(string healthString)
    {
        this.healthString = healthString;
    }

}