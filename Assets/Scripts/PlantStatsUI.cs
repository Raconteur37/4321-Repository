using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantStatsUI : MonoBehaviour
{
    public Slider slider;
    public float minRange; // Minimum range value for the slider
    public float maxRange; // Maximum range value for the slider

    private Image fillImage;
    private Gradient gradient;
    private GradientColorKey[] colorKeys;
    private GradientAlphaKey[] alphaKeys;

    void Start()
    {
    }

    public void setMin(float min)
    {
        minRange = min;
    }
    public void setMax(float max)
    {
        maxRange = max;
    }
    public float getMin()
    {
        return minRange;
    }
    public float getMax()
    {
        return maxRange;
    }
    public float getSliderValue()
    {
        return slider.value;
    }


    // Method to set the progress of the slider
    public void SetProgress(float value)
    {
        slider.value = value; // Ensure value is within range
        // Update the fillImage color based on the gradient
    }



    // Method to add visual markers for min and max ranges
    public void AddRangeMarkers()
    {
        // Calculate normalized positions of min and max markers based on min and max range values
        float minNormalizedPos = Mathf.InverseLerp(slider.minValue, slider.maxValue, minRange);
        float maxNormalizedPos = Mathf.InverseLerp(slider.minValue, slider.maxValue, maxRange);

        GameObject minMarker = new GameObject("MinMarker");
        minMarker.transform.SetParent(slider.transform);
        RectTransform minMarkerRect = minMarker.AddComponent<RectTransform>();
        minMarkerRect.anchorMin = new Vector2(0, 0.5f);
        minMarkerRect.anchorMax = new Vector2(0, 0.5f);
        minMarkerRect.sizeDelta = new Vector2(.02f, .1f);
        minMarkerRect.anchoredPosition3D = new Vector3(minNormalizedPos * slider.GetComponent<RectTransform>().rect.width, 0, 0); // Explicitly set Z position to 0
        minMarker.AddComponent<Image>().color = Color.red; // Adjust color as needed

        // Instantiate max range marker
        GameObject maxMarker = new GameObject("MaxMarker");
        maxMarker.transform.SetParent(slider.transform);
        RectTransform maxMarkerRect = maxMarker.AddComponent<RectTransform>();
        maxMarkerRect.anchorMin = new Vector2(0, 0.5f);
        maxMarkerRect.anchorMax = new Vector2(0, 0.5f);
        maxMarkerRect.sizeDelta = new Vector2(.02f, .1f);
        maxMarkerRect.anchoredPosition3D = new Vector3(maxNormalizedPos * slider.GetComponent<RectTransform>().rect.width, 0, 0); // Explicitly set Z position to 0
        maxMarker.AddComponent<Image>().color = Color.red; // Adjust color as needed
    }
}
