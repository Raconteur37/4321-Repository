using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Pot", menuName = "Pot")]
public class Pot : ScriptableObject
{

    [SerializeField] private Plant plant;
    [SerializeField] private GameObject potObject;
    [SerializeField] private Soil soil;

    [SerializeField] private TextMeshProUGUI potName; // Hold the name for the plant text mesh pro....potName.text

    public GameObject getGameObject()
    {
        return potObject;
    }
    
    public Plant getPlant()
    {
        return plant;
    }
}