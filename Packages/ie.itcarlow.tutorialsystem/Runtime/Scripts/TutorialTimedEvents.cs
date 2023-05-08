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

    public List<GameObject> existingEvents = new List<GameObject>();
    public List<float> timeBetweenExistingEvents = new List<float>();
    private int activeExistingEvent;
    public float timeToElapseExisting;
    //Second List


    // Start is called before the first frame update
    void Start()
    {
        while (timeBetweenEvents.Count < events.Count)
        {
            timeBetweenEvents.Add(10.0f);
        }

        activeEvent = 0;
        timeToElapse = timeBetweenEvents[activeEvent];


        while (timeBetweenExistingEvents.Count < existingEvents.Count)
        {
            timeBetweenExistingEvents.Add(10.0f);
        }

        activeExistingEvent = 0;
        timeToElapseExisting = timeBetweenExistingEvents[activeExistingEvent];
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
                GameObject newEvent = Instantiate(events[activeEvent]);
                newEvent.transform.parent = FindObjectOfType<Canvas>().gameObject.transform;
                newEvent.transform.position = new Vector3(0, -10, 0);
                newEvent.SetActive(true);
                if (activeEvent < events.Count)
                {
                    activeEvent++;
                }
                timeToElapse = timeBetweenEvents[activeEvent];
            }
        }


        if (activeExistingEvent < existingEvents.Count)
        {
            timeToElapseExisting -= Time.deltaTime;


            //if time passed from start ot previous event is more than timeBetweenEvents
            if (timeToElapseExisting <= 0)
            {
                existingEvents[activeExistingEvent].SetActive(true);

                if (activeExistingEvent < existingEvents.Count)
                {
                    activeExistingEvent++;
                }
                timeToElapseExisting = timeBetweenExistingEvents[activeExistingEvent];
            }
        }
    }
}
