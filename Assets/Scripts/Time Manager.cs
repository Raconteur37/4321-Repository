using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Texture2D skyboxNight;
    [SerializeField] private Texture2D skyboxSunrise;
    [SerializeField] private Texture2D skyboxSunset;
    [SerializeField] private Texture2D skyboxDayTime;

    private int minutes;
    private int hours;
    private int days;

    private float tempSecs;

    /*public int Minutes { get { return minutes; } set { minutes = value; onMinuteChange(value); } }
    public int Hours { get { return hours; } set { hours = value; onHourChange(value); } }

    public int Days { get { return days; } set { days = value; } }*/
    public void updateTime()
    {
        DateTime time = DateTime.Now;
        int hour = time.Hour;
        if (hour <= 8 && hour >=7)
        {
            RenderSettings.skybox.SetTexture("_Texture1", skyboxSunrise);
            Debug.Log("Displaying Sunrise");
        }
        else if ( hour >= 9 && hour <= 18)
        {
            RenderSettings.skybox.SetTexture("_Texture1", skyboxDayTime);
            Debug.Log("Displaying DayTime");
        }
        else if ( hour >= 19 && hour <= 20)
        {
            RenderSettings.skybox.SetTexture("_Texture1", skyboxSunset);
            Debug.Log("Displaying Sunset");
        }
        else
        {
            RenderSettings.skybox.SetTexture("_Texture1", skyboxNight);
            Debug.Log("Displaying Night time");
        }
    }
    void Start()
    {
        updateTime();
    }

    // Update is called once per frame
    void Update()
    {
        /*tempSecs += Time.deltaTime;
        tempSecs = 7;
        if(tempSecs >= 1)
        {
            minutes += 1;
            tempSecs = 0;
        }*/
    }
    /*private void onMinuteChange(int value)
    {
        if (value >= 60)
        {
            Hours++;
            minutes = 0;
        }
        if (Hours >= 24)
        {
            Hours = 0;
            Days++;
        }
    }

    private void onHourChange(int value)
    {
        if (value == 7)
        {
            StartCoroutine(LerpSkybox(skyboxNight, skyboxSunrise, 10f));
        }
        else if (value == 9)
        {
            StartCoroutine(LerpSkybox(skyboxSunrise, skyboxDayTime, 10f));
        }
        else if (value == 19)
        {
            StartCoroutine(LerpSkybox(skyboxDayTime, skyboxSunset, 10f));
        }
        else if (value == 21)
        {
            StartCoroutine(LerpSkybox(skyboxSunset, skyboxNight, 10f));
        }

    }

    private IEnumerator LerpSkybox(Texture2D a, Texture2D b, float time)
    {
        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", b);
        RenderSettings.skybox.SetFloat("_Blend", 0);
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            RenderSettings.skybox.SetFloat("_Blend", i / time);
            yield return null;
        }
        RenderSettings.skybox.SetTexture("_Texture1", b);

    }*/
}
