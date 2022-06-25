using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    public bool steer;
    public bool invertsteer;
    public bool power;

    public float SteerAngle { get; set; }
    public float Torque { get; set; }

    private WheelCollider wheelcollider;
    private Transform wheelTransform;

    void Start()
    {
        wheelcollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        wheelcollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    private void FixedUpdate()
    {
        if (steer)
        {
            wheelcollider.steerAngle = SteerAngle * (invertsteer ? -1 : 1);
        }

        if (power)
        {
            wheelcollider.motorTorque = Torque; 
        }
    }
}
