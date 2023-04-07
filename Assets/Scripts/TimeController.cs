using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private float TimeMultiplier;

    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunlight;

    [SerializeField]
    private float sunriseHour;
    [SerializeField]
    private float sunsetHour;

    //ambient light
    [SerializeField]
    private Color dayAmbientLight;

    [SerializeField]
    private Color nightAmbientLight;

    [SerializeField]
    private AnimationCurve lightChangeCurve;

    [SerializeField]
    private float maxSunlightIntensity;

    [SerializeField]
    private Light moonlight;

    [SerializeField]
    private float maxMoonlightIntensity;

[SerializeField]
    private Material mat1;
[SerializeField]
    private Material mat2;



    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;

    public static DateTime currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        updateTimeOfDay();
        rotateSun();
        updateLightSettings();
    }

    public static void setToDay()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(12);
    }
    private void updateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * TimeMultiplier);

        if(timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    private TimeSpan calculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }

    private void rotateSun()
    {
        float sunlightRotation;

        if(currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = calculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = calculateTimeDifference(sunriseTime, currentTime.TimeOfDay);
        
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;
             RenderSettings.skybox=mat1;
            sunlightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }else
        {
            TimeSpan sunsetToSunriseDuration = calculateTimeDifference(sunsetTime,sunriseTime);
            TimeSpan timeSinceSunset = calculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;
            RenderSettings.skybox=mat2;
            sunlightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        sunlight.transform.rotation = Quaternion.AngleAxis(sunlightRotation, Vector3.right);
    }

    private void updateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunlight.transform.forward, Vector3.down);

        sunlight.intensity = Mathf.Lerp(0, maxSunlightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonlight.intensity = Mathf.Lerp(maxMoonlightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }
}
