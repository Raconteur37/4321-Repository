using System.Collections;
using System.Collections.Generic;
using Classes.Plants;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotManager : MonoBehaviour
{
    
    [SerializeField] private Pot pot;
    [SerializeField] private Canvas plantstatsUI;

    [SerializeField] private Canvas plantstatsUI1;
    
    [SerializeField] private Soil soil;
    private PlantClass plant;
    
    [SerializeField] float updateTime = 20f; //timeframe variable
    
    private Vector3 offset = new Vector3(-.3f, .5f, 0f); // Adjust the offset as needed
    private Vector3 offset1 = new Vector3(1f, .5f, 0f);
    private float tempUpdateCounter = 0f; //timeframe temp variable

    private GameObject soilGO = null;
    private GameObject plantGO = null;
    
    private float xPlantScale = 0.0f;
    private float yPlantScale = 0.0f;
    private float zPlantScale = 0.0f;
    
    public void getSunStatus(string status)
    {
        if (status == "Clear")
        {
            Debug.Log("Plant will grow faster while sun is out");
            plant.isPlantInSun(true);
        }
    }

    private void Start()
    {
        
        soilGO = GameObject.Find("Soil_Physical");
        plantGO = GameObject.Find("Plant_Physical");
        
        if (soilGO != null)
        {
            soilGO.SetActive(false);
        }
        
        if (plantGO != null)
        {
            plantGO.SetActive(false);
        }

        plant = new AloeVera(); // For now



    }
    private void updatePlantStatsUI()
    {
        if (plant != null)
        {
            Slider[] sliders = plantstatsUI1.GetComponentsInChildren<Slider>();
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
    
    private float getPlantXScale()
    {
        return xPlantScale;
    }
    
    private float getPlantYScale()
    {
        return yPlantScale;
    }
    
    private float getPlantZScale()
    {
        return zPlantScale;
    }

    private GameObject getPlantGO()
    {
        return plantGO;
    }

    
    private void Update()
    {

        if (plant != null && !plant.getIsFullyGrown())  
        {
            if (tempUpdateCounter <= 0f) 
            {
                plant.updatePlant();
                
                updatePlantStatsUI();
                
                plant.toString();
                
                double status = plant.getStatus();

                Debug.Log(status);
                
                xPlantScale = (float)status;
                yPlantScale = (float)status;
                zPlantScale = (float)status;
                
                plantGO.transform.localScale = new Vector3(getPlantXScale(), getPlantYScale(), getPlantZScale());
                
                tempUpdateCounter = updateTime;  //reset the timer or cd
            }
            else {
                tempUpdateCounter -= Time.deltaTime;  //take down time 
            }   
        }
        if (Input.GetMouseButtonDown(0) && plant != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject) 
                {
                    Vector3 uiPosition = transform.position + offset;
                    plantstatsUI.transform.position = uiPosition;
                    plantstatsUI.gameObject.SetActive(!plantstatsUI.gameObject.activeSelf);
                    Vector3 uiPosition1 = transform.position + offset1;
                    plantstatsUI1.transform.position = uiPosition1;
                    plantstatsUI1.gameObject.SetActive(!plantstatsUI1.gameObject.activeSelf);
                }
            }
        }
    }
    public void VRUISelect()
    {
        Vector3 uiPosition = transform.position + offset;
        plantstatsUI.transform.position = uiPosition;
        plantstatsUI.gameObject.SetActive(!plantstatsUI.gameObject.activeSelf);
        Vector3 uiPosition1 = transform.position + offset1;
        plantstatsUI1.transform.position = uiPosition1;
        plantstatsUI1.gameObject.SetActive(!plantstatsUI1.gameObject.activeSelf);
    }

    public void updateSoilGO()
    {
        if (soil != null) 
        {
            soilGO.SetActive(true); // Change based on the type of soil
        } 
    }

    public void updatePlantGO()
    {
        if (plant != null)
        {
            plantGO.SetActive(true);
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
        updateSoilGO();
    }

    public void setPlant(PlantClass plant)
    {
        this.plant = plant;
        Debug.Log("it's set");
        if (plant != null)
        {
            updatePlantGO();
            Slider[] sliders = plantstatsUI1.GetComponentsInChildren<Slider>();
            foreach (Slider slider in sliders)
            {
                if (slider.name == "WaterSlider")
                {
                    PlantStatsUI statsUI = slider.GetComponent<PlantStatsUI>();
                    if (statsUI != null)
                    {
                        int waterMin = this.plant.getWaterMinRange();
                        Debug.Log("WaterMin: " + waterMin);
                        int waterMax = this.plant.getWaterMaxRange();
                        Debug.Log("WaterMax: " + waterMax);
                        double waterAmount = this.plant.getWaterAmount();
                        float waterAmountFloat = (float)waterAmount;
                        float waterMinFloat = (float)waterMin;
                        float waterMaxFloat = (float)waterMax;
                        statsUI.setMin(waterMinFloat);
                        statsUI.setMax(waterMaxFloat);
                        statsUI.SetProgress(waterAmountFloat);
                        statsUI.AddRangeMarkers();
                    }
                }
                else if (slider.name == "SunlightSlider")
                {
                    PlantStatsUI statsUI = slider.GetComponent<PlantStatsUI>();
                    if (statsUI != null)
                    {
                        int sunlightMin = plant.getSunMinRange();
                        int sunlightMax = plant.getSunMaxRange();
                        double sunlightAmount = plant.getSunlightAmount();
                        float sunlightAmountFloat = (float)sunlightAmount;
                        float sunlightMinFloat = (float)sunlightMin;
                        float sunlightMaxFloat = (float)sunlightMax;
                        statsUI.setMin(sunlightMinFloat);
                        statsUI.setMax(sunlightMaxFloat);
                        statsUI.SetProgress(sunlightAmountFloat);
                        statsUI.AddRangeMarkers();

                    }
                }
            }
        }
    }



}
