using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilManager : MonoBehaviour
{
    [SerializeField] private Soil soil;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Pot"))
        {
            PotManager potManager = other.GetComponent<PotManager>();

            switch (soil.getType())
            {

                case ("Sandy"):
                    potManager.setSoil(new Soil("Sandy"));
                    Debug.Log("Triggered the event");
                    break;

                case ("Loam"):
                    potManager.setSoil(new Soil("Loam"));
                    break;

                case ("Clay"):
                    potManager.setSoil(new Soil("Clay"));
                    break;

            }

            potManager.updateSoilGO();
            gameObject.SetActive(false);


        }
    }
}
