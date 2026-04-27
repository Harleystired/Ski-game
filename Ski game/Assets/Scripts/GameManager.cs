using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public delegate void TimerEvent();

   private DateTime raceStart;
   private TimeSpan raceTime;
   private bool racing = false;
   private void OnEnable()
   {
       StartGate.StartRace += StartRace;
       FinishGate.FinishRace += FinishRace;
   }

    void FinishRace()
    {
        racing = false;
        Debug.Log("FinishRace");
    }

    void StartRace()
    {
        racing = true;
        raceStart = DateTime.Now;
       Debug.Log("StartRace"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(racing)
            raceTime = DateTime.Now - raceStart;
        Debug.Log("Race Time " + raceTime);
    }
}
