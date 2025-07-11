using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticLinks : MonoBehaviour
{
    public static StatMeterUtilities hungerStatBarScript;
    public static StatMeterUtilities healthStatBarScript;

    void Awake()
    {
        Transform statGroupTransform = GameObject.Find("Stat Group").transform;
        hungerStatBarScript = statGroupTransform.GetChild(0).GetComponent<StatMeterUtilities>();
        healthStatBarScript = statGroupTransform.GetChild(1).GetComponent<StatMeterUtilities>();
    }
}
