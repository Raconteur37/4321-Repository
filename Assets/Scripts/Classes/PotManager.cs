using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotManager : MonoBehaviour
{

    [SerializeField] private Pot pot;
    
    private void Start()
    {
        

    }

    public GameObject getPotObject()
    {
        return pot.getGameObject();
    }
    
    
}
