using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI plantInfoText; // Reference to the TextMeshProUGUI component for plant info
    int counter = 0;

    public void ButtonPressed()
    {
        if (counter % 2 == 0 ){
                    numberText.text = "Name: Aloe Vera\n" + 
                             "Country: Oman & U.A.E\n" +
                             "Soil: Sandy soil\n" +
                             "Water: once per week – minimal water\n" +
                             "Sun: six hours of sunlight daily – indirect sunlight\n" +
                             "Temperature: 60°F to 80°F (15°C to 27°C)";
        } else {
            numberText.text = ""; 
        }

        counter++;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize plant info text
        plantInfoText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}

