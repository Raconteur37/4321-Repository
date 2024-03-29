using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed Packet", menuName = "Seed Packet")]
public class SeedPacket : ScriptableObject
{
    [SerializeField] string displayName;
    [SerializeField] Plant plant;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pot")){
            Pot pot = other.GetComponent<Pot>();
            pot.setPlant(plant);
     
        }
    }
}
