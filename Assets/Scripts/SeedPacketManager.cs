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
                    potManager.setPlant(new AloeVera());
                    Debug.Log("setting aloe");
                    break;
            }

        }
        }
}
