using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotManager : MonoBehaviour
{

    [SerializeField] private Pot pot;
    [SerializeField] private Canvas plantstatsUI;

    private Plant plant;




    private void Start()
    {
        plant = pot.getPlant();
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

    public GameObject getPotObject()
    {
        return pot.getGameObject();
    }




    
}
