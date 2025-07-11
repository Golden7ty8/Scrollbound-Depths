using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1ActiveScript : MonoBehaviour
{

    public GameObject hungerMeterGroup;
    public GameObject healthMeterGroup;

    // Start is called before the first frame update
    void Start()
    {
        hungerMeterGroup.GetComponent<StatMeterUtilities>().SetMeterValue(75);
        healthMeterGroup.GetComponent<StatMeterUtilities>().SetMeterValue(40);

        hungerMeterGroup.GetComponent<StatMeterUtilities>().SetMaxMeterValue(200);
        healthMeterGroup.GetComponent<StatMeterUtilities>().SetMaxMeterValue(250);

        Debug.Log(hungerMeterGroup.GetComponent<StatMeterUtilities>().GetMeterValue());
        Debug.Log(healthMeterGroup.GetComponent<StatMeterUtilities>().GetMeterValue());

        Debug.Log(hungerMeterGroup.GetComponent<StatMeterUtilities>().GetMaxMeterValue());
        Debug.Log(healthMeterGroup.GetComponent<StatMeterUtilities>().GetMaxMeterValue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
