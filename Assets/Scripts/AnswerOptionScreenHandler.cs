using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerOptionScreenHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private static Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
        ShowPopUp(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ShowPopUp(bool option)
    {
        GameObject popUp = GameObject.Find("Pop-up");
        if (option)
        {
            popUp.transform.position = new Vector2(initialPosition.x, initialPosition.y);
            Time.timeScale =  0.02f;
        }
        else
        {
            popUp.transform.position = new Vector2(-200, -200);
            

        }
    }
    
}
