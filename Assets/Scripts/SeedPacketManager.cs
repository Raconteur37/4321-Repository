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


            if (potManager.getSoil() != null)
            {
                if (seedPacket.getDisplayName() == "Aloe Vera")
                {
                    AloeVera aloe = new AloeVera();
                    potManager.setPlant(aloe);
                    if (potManager.getPlant().getPerferedSoil() == potManager.getSoil().getType())
                    {
                        potManager.getPlant().setIsInPerferedSoil(true);
                    }

                }
                if (seedPacket.getDisplayName() == "Orchid")
                {
                    Orchid orchid = new Orchid();
                    potManager.setPlant(orchid);
                    if (potManager.getPlant().getPerferedSoil() == potManager.getSoil().getType())
                    {
                        potManager.getPlant().setIsInPerferedSoil(true);
                    }

                }
                if(seedPacket.getDisplayName() == "Cactus")
                {
                    Cactus cactus = new Cactus();
                    potManager.setPlant(cactus);
                    if (potManager.getPlant().getPerferedSoil() == potManager.getSoil().getType())
                    {
                        potManager.getPlant().setIsInPerferedSoil(true);
                    }
                }

                gameObject.SetActive(false);
                
                
            }
        }
    }
}
