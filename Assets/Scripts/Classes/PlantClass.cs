using System;
using UnityEngine;

namespace Classes.Plants
{
    public class PlantClass
    {
        
        private double waterRangePercent, sunlightPercentage, status, statusCap; // All will be out of a decimal from 0-1...indicating the percentage of their respective range...status is the overall 
        // percent that they are at 0 being a seed, 1 being fully grown.
        private double waterDrainMultiplier, sunlightDrainMultiplier; // These will be case by case for each plant and determine how much sunlight and water will drain
        // every tick
        private double waterAmount, sunlightAmount; // These are int amount of water and sun you can give to a plant
        private int waterMinRange, sunlightMinRange = 0; // These are the ranges of the sunlight and the water needed to maintain the plant...
        // These will be initiated on a plant by plant basis depending on the type of plant you are trying to grow
        private int waterMaxRange, sunlightMaxRange;
        private string plantName, ownerName, healthString = "", state, description; // Basic string values...state is the current state the plant is in 
        private bool isGrowing, hasSunlight, isFullyGrown, waterIsInRange, sunlightIsInRange;

        public PlantClass()
        {
            
            
        }
        
        public void updatePlant() {
        
        healthString = "";

        if (waterAmount >= waterMinRange)
        {
            if (waterAmount <= waterMaxRange)
            {

                if (sunlightAmount >= sunlightMinRange)
                {

                    if (sunlightAmount <= sunlightMaxRange)
                    {

                        isGrowing = true;
                        healthString = "Healthy";

                        status += .1;

                        if (status >= statusCap)
                        {
                            isFullyGrown = true;
                        }

                    }
                    else
                    {
                        healthString += "Too much light! \n";
                        isGrowing = false;
                        //state += "Drying out \n";
                    }
                }
                else
                {
                    healthString += "Needs more light! \n";
                    isGrowing = false;
                }
            }
            else
            {
                healthString += "Too much water! \n";
                isGrowing = false;
            }
        }
        else
        {
            healthString += "Needs more water! \n";
            isGrowing = false;
        }
        
        double sunAmountDrain = Math.Round(1.0 * sunlightDrainMultiplier,2);
        double waterAmountDrain = Math.Round(1.0 * waterDrainMultiplier, 2);

        
        if (hasSunlight) {
            sunlightAmount += sunAmountDrain;
        } else {
            sunlightAmount -= sunAmountDrain;
        }
        
        waterAmount -= waterAmountDrain;
        
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

    public int getSunMinRange()
    {
        return sunlightMinRange;
    }
    public int getSunMaxRange()
    {
        return sunlightMaxRange;
    }
    public int getWaterMinRange()
    {
        return waterMinRange;
    }
    public int getWaterMaxRange()
    {
        return waterMaxRange;
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

    public void isPlantInSun(bool sun)
    {
        hasSunlight = sun;
    }

    public void toString()
    {
        string outString = "Health: " + healthString + "\n Sun Amount: " + sunlightAmount + "\n Water Amount: " +
                           waterAmount + "\n Sun Range: " + sunlightMinRange + "-" + sunlightMaxRange +
                           "\n Water Range: " + waterMinRange + "-" + waterMaxRange;
        Debug.Log(outString);
    }

    public double getStatus()
    {
        return status;
    }

    public bool getIsFullyGrown()
    {
        return isFullyGrown;
    }

    public void setStatusCap(float cap)
    {
        statusCap = cap;
    }
        
    }
}