using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    public float arrowEnableTimer = 2.0f; //Specify when text is enabled
    public float timeTillAttentionGrab = 5.0f;
    public GameObject gameObjectToFollow;
    public GameObject player;

    public float distanceWhenArrowDisappears = 10.0f;
    public bool disappearWhenTargetOnScreen;

    private float colourChangeDelay = 1.0f;
    private bool arrowShown = false;
    private int nextColour;

    // Start is called before the first frame update
    void Start()
    {
        arrowEnableTimer += Time.time;
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowShown == false && Time.time >= arrowEnableTimer)
        {
            gameObject.GetComponent<Image>().color = new Color(255, 221, 0, 255);
            timeTillAttentionGrab += Time.time;
            arrowShown = true;
        }
        if(arrowShown == true && Time.time >= timeTillAttentionGrab && Time.time > colourChangeDelay ) //Cycle Colours to grab attention
        {
            colourChangeDelay ++;
            nextColour++;

            if (nextColour > 5)
            {
                nextColour = 0;
            }

            switch (nextColour)
            {
                case 0:
                    gameObject.GetComponent<Image>().color = Color.yellow;
                    break;
                case 1:
                    gameObject.GetComponent<Image>().color = Color.red;
                    break;
                case 2:
                    gameObject.GetComponent<Image>().color = Color.magenta;
                    break;
                case 3:
                    gameObject.GetComponent<Image>().color = Color.blue;
                    break;
                case 4:
                    gameObject.GetComponent<Image>().color = Color.cyan;
                    break;
                case 5:
                    gameObject.GetComponent<Image>().color = Color.green;
                    break;
                default:
                    break;

            }
        }
        AimAtTarget();
        if(disappearWhenTargetOnScreen)
        {
            DisappearAppear();
        }

        if(gameObjectToFollow == null)
        {
            Destroy(gameObject);
        }
    }

    private void AimAtTarget()
    {
        if (gameObjectToFollow.transform.position.x > player.gameObject.transform.position.x)
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 0, gameObject.transform.eulerAngles.z);
        }
        else if (gameObjectToFollow.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 180, gameObject.transform.eulerAngles.z);
        }
    }

    private void DisappearAppear()
    {
        float distance = Vector3.Distance(player.gameObject.transform.position, gameObjectToFollow.transform.position);
        if(distance < distanceWhenArrowDisappears)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(255, 221, 0, 255);
        }
    }
    
}
