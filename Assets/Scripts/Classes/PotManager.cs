using System.Collections;
using System.Collections.Generic;
using Classes.Plants;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Normal.Realtime;


public class PotManager : MonoBehaviour
{
    
    [SerializeField] private Pot pot;
    [SerializeField] private Canvas plantstatsUI;

    [SerializeField] private Canvas plantstatsUI1;
    [SerializeField] private Image AlertIcon;
    [SerializeField] private Sprite Check;
    [SerializeField] private Sprite NotCheck;
    [SerializeField] private Image AlertTextBackground;
    [SerializeField] private TextMeshProUGUI AlertText;

    [SerializeField] private Soil soil;
    private PlantClass plant;
    
    [SerializeField] float updateTime; //timeframe variable
    
    private Vector3 offset = new Vector3(-.3f, .5f, 0f); // Adjust the offset as needed
    private Vector3 offset1 = new Vector3(1f, .5f, 0f);
    private float tempUpdateCounter = 0f; //timeframe temp variable

    private GameObject soilGO = null;
    private GameObject plantGO = null;
    
    private float xPlantScale = 0.0f;
    private float yPlantScale = 0.0f;
    private float zPlantScale = 0.0f;

    public RealtimeView rtView;

    public void getSunStatus(string status)
    {
        if (status == "Clear")
        {
            //Debug.Log("Plant will grow faster while sun is out");
            plant.isPlantInSun(true);
        }

        if (status != "Rain")
        {
            plant.isPlantInSun(false);
        }
        
        
    }

    private void Start()
    {
        
        soilGO = GameObject.Find("Soil_Physical");
        plantGO = GameObject.Find("Plant_Physical");
        
        //plant = new AloeVera(); // For now // This too
        //soil = new Soil("Sandy"); // Temp, comment out when ready
        
        if (soilGO != null)
        {
            soilGO.SetActive(false); // Change to false when ready
        }
        
        if (plantGO != null)
        {
            plantGO.SetActive(false); // False when ready
        }
        

    }
    public void updatePlantStatsUI()
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
    private void UpdateAlertUI()
    {
        if (plant != null)
        {
            Slider[] sliders = plantstatsUI1.GetComponentsInChildren<Slider>();
            bool water = false;
            bool sun = true;
            foreach (Slider slider in sliders)
            {
                if (slider.name == "WaterSlider")
                {
                    PlantStatsUI statsUI = slider.GetComponent<PlantStatsUI>();
                    if (statsUI != null)
                    {
                        double waterAmount = plant.getWaterAmount();
                        float waterAmountFloat = (float)waterAmount;
                        float maxWaterRange = statsUI.getMax();
                        float minWaterRange = statsUI.getMin();
                        float currentWaterAmount = statsUI.getSliderValue();
                        if (currentWaterAmount < minWaterRange || currentWaterAmount > maxWaterRange)
                        {
                            water = false;
                        }
                        else
                        {
                            water = true;
                        }
                    }
                }
                else if (slider.name == "SunlightSlider")
                {
                    PlantStatsUI statsUI = slider.GetComponent<PlantStatsUI>();
                    if (statsUI != null)
                    {
                        double sunlightAmount = plant.getSunlightAmount();
                        float sunlightAmountFloat = (float)sunlightAmount;
                        float maxSunlightRange = statsUI.getMax();
                        float minSunlightRange = statsUI.getMin();
                        float currentSunlightAmount = statsUI.getSliderValue();
                        if (currentSunlightAmount < minSunlightRange || currentSunlightAmount > maxSunlightRange)
                        {
                            sun = false;
                        }
                        else
                        {
                            sun = true;
                        }
                    }
                }
            }
            if (sun && water)
            {
                AlertIcon.sprite = Check;
                AlertText.text = "Your Plant is Healthy!";
            }
            else if(sun && !water)
            {
                AlertIcon.sprite = NotCheck;
                AlertText.text = "Check Your Plant's Water Levels!";
            }
            else if(!sun && water)
            {
                AlertIcon.sprite = NotCheck;
                AlertText.text = "Check Your Plant's Light Levels!";
            }
            else if(!sun && !water)
            {
                AlertIcon.sprite = NotCheck;
                AlertText.text = "Check Your Plant's Water and Light Levels!";
            }
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Lamp"))
        {
            if (!plant.plantIsInSun())
            {
                plant.isPlantInSun(true);
            }
        }
    }
    
    public void ViewAlertText()
    {
        AlertTextBackground.gameObject.SetActive(!AlertTextBackground.gameObject.activeSelf);
    }

    public PlantClass getPlant()
    {
        return plant;
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

    public GameObject getPlantGO()
    {
        return plantGO;
    }

    public GameObject getSoilGO()
    {
        return soilGO;
    }
    public void setPlantGOFalse()
    {
        plantGO.SetActive(false);
        AlertIcon.gameObject.SetActive(!AlertIcon.gameObject.activeSelf);
    }

    public void setSoilGOFalse()
    {
        soilGO.SetActive(false);
    }

    private void Update()
    {
        
        if (OVRInput.Get(OVRInput.Button.Two)) // Shoot forward in time
        {
            //Debug.Log("B button pressed");
            updatePlantAndScale();
            resetTimer();
        }
        
        if (Input.GetKeyDown(KeyCode.B)) // Still forward by 1 update
        {
            //Debug.Log("B key pressed");
            updatePlantAndScale();
            resetTimer();
        }
        
        if (tempUpdateCounter <= 0f)  
        {
            if (plant != null && !plant.getIsFullyGrown())
            {

                updatePlantAndScale();

                resetTimer();
            }
        }
        
        tempUpdateCounter -= Time.deltaTime;  //take down time 
        
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

    public void updatePlantAndScale()
    {
        //Debug.Log("Called update in pot manager");

        plant.updatePlant();

        updatePlantStatsUI();
        UpdateAlertUI();

        //plant.toString();

        double status = plant.getStatus();

        //Debug.Log(status);

        xPlantScale = (float)status;
        yPlantScale = (float)status;
        zPlantScale = (float)status;

        rtView.RequestOwnershipOfSelfAndChildren();
        plantGO.transform.localScale = new Vector3(getPlantXScale(), getPlantYScale(), getPlantZScale());
    }

    public void resetTimer()
    {
        tempUpdateCounter = updateTime; //reset the timer or cd
    }
    
    public void VRUISelect()
    {
        Debug.Log("Selector");
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
        if (soil.getType() == "Sandy")
        {
            Renderer currentM = soilGO.GetComponent<Renderer>();
            Material sandMaterial = Resources.Load<Material>("Sand Material");
        }
    }

    public void setPlant(PlantClass plant)
    {
        Debug.Log("it's set");
        if (plant != null)
        {

            updatePlantGO();
            if(plant.getPlantName() == "Cactus")
            {
                this.plant = new Cactus();
                MeshFilter plantFilter = plantGO.GetComponent<MeshFilter>();
                Mesh cactusMesh = Resources.Load<Mesh>("cactus");
                plantFilter.mesh = cactusMesh;
            }
            if (plant.getPlantName() == "Orchid")
            {
                this.plant = new Orchid();
                MeshFilter plantFilter = plantGO.GetComponent<MeshFilter>();
                Mesh orchidMesh = Resources.Load<Mesh>("orchid");
                plantFilter.mesh = orchidMesh;
            }
            if(plant.getPlantName() == "Aloe Vera")
            {
                this.plant = new AloeVera();
                MeshFilter plantFilter = plantGO.GetComponent<MeshFilter>();
                Mesh aloeMesh = Resources.Load<Mesh>("aloe");
                plantFilter.mesh = aloeMesh;
            }

            AlertIcon.gameObject.SetActive(!AlertIcon.gameObject.activeSelf);
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
            UpdateAlertUI();
        }
    }



}
