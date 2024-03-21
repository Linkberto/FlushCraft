using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSwing : MonoBehaviour
{
    public float swingSpeed = 1.0f; 
    public float swingAmount = 10.0f; 

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        
        float swingAngle = Mathf.Sin(Time.time * swingSpeed) * swingAmount;
        Quaternion swingRotation = Quaternion.AngleAxis(swingAngle, transform.right);

        
        transform.rotation = initialRotation * swingRotation;
    }
}
