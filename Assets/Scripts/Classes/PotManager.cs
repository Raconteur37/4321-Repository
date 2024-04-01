using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotManager : MonoBehaviour
{

    [SerializeField] private Pot pot;
    [SerializeField] private Canvas plantstatsUI;
    [SerializeField] private Soil soil;
    [SerializeField] private Plant plant;

    private GameObject soilGO = null;
    private GameObject plantGO = null;
    
    private void Start()
    {
        
        GameObject soilGO = GameObject.Find("Soil_Physical");
        GameObject plantGO = GameObject.Find("Plant_Physical");
        
        if (soilGO != null)
        {
            soilGO.SetActive(false);
        }
        
        if (plantGO != null)
        {
            plantGO.SetActive(false);
        }
        
        if (plant != null)
        {
            Slider[] sliders = plantstatsUI.GetComponentsInChildren<Slider>();
            foreach (Slider slider in sliders)
            {
                if (slider.name == "WaterSlider")
                {
                    PlantStatsUI statsUI = slider.GetComponent<PlantStatsUI>();
                    if (statsUI != null)
                    {
                        double waterAmount = plant.getWaterAmount();
                        float waterAmountFloat = (float)waterAmount;
                        statsUI.SetProgress(waterAmountFloat);
                    }
                }
                else if (slider.name == "SunlightSlider")
                {
                    PlantStatsUI statsUI = slider.GetComponent<PlantStatsUI>();
                    if (statsUI != null)
                    {
                        double sunlightAmount = plant.getSunlightAmount();
                        float sunlightAmountFloat = (float)sunlightAmount;
                        statsUI.SetProgress(sunlightAmountFloat);
                    }
                }
            }
        }

    }

    public void updateSoilGO()
    {
        if (soil != null) 
        {
            soilGO.SetActive(true); // Change based on the type of soil
        } 
    }

    public GameObject getPotObject()
    {
        return pot.getGameObject();
    }

    public Soil getSoil()
    {
        return soil;
    }

    public void setSoil(Soil soil)
    {
        this.soil = soil;
    }

    public void setPlant(Plant plant)
    {
        this.plant = plant;
    }


    
}
