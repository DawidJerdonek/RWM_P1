using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.IonicZip;
using UnityEngine;

public class TutorialTimedEvents : MonoBehaviour
{
    public List<GameObject> events = new List<GameObject>();
    public List<float> timeBetweenEvents = new List<float>();
    private int activeEvent;
    public float timeToElapse;

    // Start is called before the first frame update
    void Start()
    {
        while (timeBetweenEvents.Count < events.Count)
        {
            timeBetweenEvents.Add(10.0f);
        }

        activeEvent = 0;
        timeToElapse = timeBetweenEvents[activeEvent];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeEvent < events.Count)
        {
            timeToElapse -= Time.deltaTime;


            //if time passed from start ot previous event is more than timeBetweenEvents
            if (timeToElapse <= 0)
            {
                Instantiate(events[activeEvent]);
                if (activeEvent < events.Count)
                {
                    activeEvent++;
                }
                timeToElapse = timeBetweenEvents[activeEvent];
            }
        }
    }
}
