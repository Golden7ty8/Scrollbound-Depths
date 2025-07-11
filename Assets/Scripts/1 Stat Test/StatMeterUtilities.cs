using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMeterUtilities : MonoBehaviour
{

    [Header("Settings:")]
    [Tooltip("For example 100 max health or 140 max hunger.")]
    public int maxValue = 100;

    [Header("Refferences:")]
    public GameObject backgroundMeter;
    public GameObject foregroundMeter;

    [HideInInspector]
    public int currentValue;

    void Start()
    {
        currentValue = maxValue;
    }

    void UpdateMeterUI()
    {
        float meterPercentage = (float)currentValue / (float)maxValue;

        RectTransform foregroundMeterRectTransform = foregroundMeter.GetComponent<RectTransform>();

        foregroundMeterRectTransform.localScale = new Vector3(
            meterPercentage, foregroundMeterRectTransform.localScale.y, foregroundMeterRectTransform.localScale.z
            );
    }

    public void SetMeterValue(int newValue)
    {
        currentValue = newValue;

        if(currentValue > maxValue)
            currentValue = maxValue;

        if(currentValue < 0)
            currentValue = 0;

        UpdateMeterUI();
    }

    /// <summary>
    /// Argument can also be negative.
    /// </summary>
    /// <param name="valueAdd"></param>
    public void AddMeterValue(int valueAdd)
    {
        SetMeterValue(currentValue + valueAdd);
    }

    public int GetMeterValue()
    {
        return currentValue;
    }

    public void SetMaxMeterValue(int newValue)
    {
        maxValue = newValue;

        if(maxValue < 0)
            maxValue = 0;

        if(currentValue > maxValue)
            currentValue = maxValue;

        UpdateMeterUI();
    }

    /// <summary>
    /// Argument can also be negative.
    /// </summary>
    /// <param name="valueAdd"></param>
    public void AddMaxMeterValue(int valueAdd)
    {
        SetMaxMeterValue(maxValue + valueAdd);
    }

    public int GetMaxMeterValue()
    {
        return maxValue;
    }

}
