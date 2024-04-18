using System;
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
    [SerializeField] private string plantName, ownerName, healthString = "", state, description; // Basic string values...state is the current state the plant is in 
    [SerializeField] private Sprite plantImage; // Sprite of the image of the plant pulled from web API
    [SerializeField] private Mesh mesh;
    [SerializeField] private bool isGrowing, hasSunlight, isFullyGrown, waterIsInRange, sunlightIsInRange;

    public Plant() // Add a constructor for the persons' name
    {
        
    }

    

}