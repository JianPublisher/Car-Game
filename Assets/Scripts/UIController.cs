using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject UIRacepanel;

    public Text UITextcurrentlap;
    public Text UITextcurrenttime;
    public Text UITextlastlaptime;
    public Text UITextbestlaptime;


    public Player UpdateUIForPlayer;


    private int currentLap = -1;
    private float currentTime;
    private float lastLapTime;
    private float bestLapTime;
    void Update()
    {
        if (UpdateUIForPlayer == null)
            return;

        if(UpdateUIForPlayer.CurrentLap != currentLap)
        {
            currentLap = UpdateUIForPlayer.CurrentLap;
            UITextcurrentlap.text = $"Lap :{currentLap} ";
        }
        if(UpdateUIForPlayer.CurrentLapTime != currentTime)
        {
            currentTime = UpdateUIForPlayer.CurrentLapTime;
            UITextcurrenttime.text = $"TIME : {(int)currentTime / 60}:{(currentTime) % 60:00.00}";

        }

        if (UpdateUIForPlayer.BestLapTime != bestLapTime)
        {
            bestLapTime = UpdateUIForPlayer.BestLapTime;
            UITextbestlaptime.text = bestLapTime < 100000 ? $"BEST : {(int)bestLapTime / 60}:{(bestLapTime) % 60:00.00}" : "BEST : NONE";

        }

        if (UpdateUIForPlayer.LastLapTime != lastLapTime)
        {
            lastLapTime = UpdateUIForPlayer.LastLapTime;
            UITextlastlaptime.text = $"LAST : {(int)lastLapTime / 60}:{(lastLapTime) % 60:00.00}";

        }

    }
}
