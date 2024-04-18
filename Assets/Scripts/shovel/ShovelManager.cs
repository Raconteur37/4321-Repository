using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelManager : MonoBehaviour
{
    private bool removePlant = true; // Initially set to true to remove the plant first

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pot"))
        {
            PotManager potManager = other.GetComponent<PotManager>();
            if (potManager != null)
            {
                if (removePlant)
                {
                    if (potManager.getPlantGO() != null)
                    {
                        potManager.setPlantGOFalse();
                        Debug.Log("Plant disappeared");
                        removePlant = false; // Toggle to remove soil next time
                    }
                }
                else
                {
                    if (potManager.getSoilGO() != null)
                    {
                        potManager.setSoilGOFalse();
                        Debug.Log("Soil disappeared");
                        removePlant = true; // Toggle to remove plant next time
                    }
                }
            }
        }
    }
}
