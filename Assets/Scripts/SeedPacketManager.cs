using System.Collections;
using System.Collections.Generic;
using Classes.Plants;
using UnityEngine;

public class SeedPacketManager : MonoBehaviour
{
    public SeedPacket seedPacket;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pot"))
        {
            //Debug.Log("Collider time");

            PotManager potManager = other.GetComponent<PotManager>();

            switch (seedPacket.getDisplayName())
            {

                case ("Aloe Vera"):
                    AloeVera aloe = new AloeVera();
                    potManager.setPlant(aloe);
                    //Debug.Log("setting aloe");
                    if (potManager.getPlant().getPerferedSoil() == potManager.getSoil().getType())
                    {
                        potManager.getPlant().setIsInPerferedSoil(true);
                    }
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}
