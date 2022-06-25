using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum ControlType { HumanInput, AI}
    public ControlType controlType = ControlType.HumanInput;

    public float BestLapTime { get; private set; } = Mathf.Infinity;

    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;

    public int CurrentLap { get; private set; } = 0;

    private float laptimer;

    private int lastcheckpointpassed = 0;

    private Transform checkpointsParent;
    private int checkpointCount;
    private int checkpointLayer;
    private Car car;

    void Awake()
    {
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        car = GetComponent<Car>();


    }

  void StartLap()
    {

        Debug.Log("StartLap");
        CurrentLap++;
        lastcheckpointpassed = 1;
        laptimer = Time.time;
    }


    void EndLap()
    {
        LastLapTime = Time.time - laptimer;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
        Debug.Log("EndLap - LapTime was " + LastLapTime + "seconds");
    }

     void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != checkpointLayer)
        {
            return;
        }
        if(collider.gameObject.name == "1")  // if its 1st checkpoint 
        {
            if(lastcheckpointpassed == checkpointCount)   // end lap if lap completed
            {
                EndLap();
            }
        if (CurrentLap ==0 || lastcheckpointpassed == checkpointCount)    //on first lap, or passed last, start new lap. 
            {
                StartLap();
            }
            return; 
        }

        //passed checkpoint's sequence, update the latest checkpoin
        if(collider.gameObject.name == (lastcheckpointpassed + 1).ToString())
        {
            lastcheckpointpassed++;
        }


    }


    void Update()
    {
        CurrentLapTime = laptimer > 0 ? Time.time - laptimer : 0;


        if ( controlType == ControlType.HumanInput)
        {
            car.Steer = GameManager.Instance.InputController.Steerinput;
            car.Throttle = GameManager.Instance.InputController.throttleinput;
        }
    }
}

