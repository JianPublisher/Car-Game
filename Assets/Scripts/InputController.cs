using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public string inputsteeraxis = "Horizontal";
    public string inputthrottle = "Vertical";

    public float throttleinput { get; private set; }
    public float Steerinput { get; private set; }
    void Start()
    {
        
    }

    void Update()
    {
        Steerinput = Input.GetAxis(inputsteeraxis);
        throttleinput = Input.GetAxis(inputthrottle);
    }
}
