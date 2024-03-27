using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantStatsUI : MonoBehaviour
{
    public Slider slider;
    private Image fillImage;
    private Gradient gradient;
    private GradientColorKey[] colorKeys;
    private GradientAlphaKey[] alphaKeys;

    void Start()
    {
        fillImage = slider.fillRect.GetComponent<Image>();

        // Define your gradient here
        gradient = new Gradient();

        // Set up the color keys for the gradient
        colorKeys = new GradientColorKey[3];
        colorKeys[0].color = Color.red;
        colorKeys[0].time = 0.0f; // At the start of the gradient
        colorKeys[1].color = Color.yellow;
        colorKeys[1].time = 0.6f; // At 60% of the gradient
        colorKeys[2].color = Color.green;
        colorKeys[2].time = 1.0f; // At the end of the gradient

        // Set up the alpha keys for the gradient
        alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 1.0f;
        alphaKeys[1].time = 1.0f;

        // Apply the keys to the gradient
        gradient.SetKeys(colorKeys, alphaKeys);
    }

    public void SetProgress(float value)
    {
        slider.value = value;
        // Update the fillImage color based on the gradient
        fillImage.color = gradient.Evaluate(slider.normalizedValue);
    }
}
