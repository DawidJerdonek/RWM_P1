using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.IonicZip;
using UnityEngine;

public class TutorialTimedEvents : MonoBehaviour
{
    public List<string> events = new List<string>();
    public List<float> timeBetweenEvents = new List<float>();
    private int activeEvent;
    float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        while (timeBetweenEvents.Count < events.Count)
        {
            timeBetweenEvents.Add(10.0f);
        }
        activeEvent = 0;
        timePassed = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if time passed from start ot previous event is more than timeBetweenEvents
        if(0.0f >= timeBetweenEvents[activeEvent])
        {
            //Enable corresponding tutorialEvent
        }
    }
}
