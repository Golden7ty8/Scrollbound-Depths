using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3CameraMover : MonoBehaviour
{

    [Header("Settings:")]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
