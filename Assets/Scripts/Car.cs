using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Transform centerofmass;
    public float motorTorque = 300f;
    public float maxSteer = 30f; 
    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rigidbody;
    private Wheels[] wheels;
   

    void Start()
    {

      
        wheels = GetComponentsInChildren<Wheels>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerofmass.localPosition;
    }

    private void Update()
    {
        foreach(var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }



}
