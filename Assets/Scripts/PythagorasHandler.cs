using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PythagorasHandler : MonoBehaviour
{
    public static double firstNum, secondNum, answer, numOfDroppedElements;
    private static System.Random randomGenerator = new System.Random();
    [CanBeNull] public static ArrayList gameObjectsInUse;
    
    public static int numberOfElementsCreated;
    public static int numberOfHealthLeft;
    
    [CanBeNull] private static GameObject popUp;
    public static bool showAnswerBox = false;

    public static GameObject selectedElement1;
    public static GameObject selectedElement2;
    
    public static GameObject oldElement1;
    public static GameObject oldElement2;
    public static Vector3 oldElement1Position;
    public static Vector3 oldElement2Position;
    public static bool elementCurrentlyInUse = false;
    
    



    // Start is called before the first frame update
    void Start()
    {
        ResetGameArea();

    }

    private void ResetGameArea()
    {
        numberOfElementsCreated = 0;
        numberOfHealthLeft = 4;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void DeleteOldElementsInGameArea()
    {
        Destroy(selectedElement1);
        Destroy(selectedElement2);
        
        oldElement1.transform.position = new Vector3(oldElement1Position.x,oldElement1Position.y);
        oldElement2.transform.position = new Vector3(oldElement2Position.x,oldElement2Position.y);

        firstNum = 0.00;
        secondNum = 0.00;
        answer = 0.00;

    }
    public static void GenerateNewNumbers()
    {
        Debug.Log(numOfDroppedElements);
       
        firstNum = double.Parse(randomGenerator.Next(4, 50).ToString());
        secondNum = double.Parse(randomGenerator.Next(4, 50).ToString());
        answer = Math.Round(Math.Sqrt(firstNum * firstNum + secondNum * secondNum),2);

    }

    public static bool IsSubmittedAnswerCorrect(string submittedAnswer)
    {
        return submittedAnswer == answer.ToString();
    }

    public static bool GameIsNotOver()
    {
        return numberOfElementsCreated <= 4 || numberOfHealthLeft < 1;
    }

    public static void playerAnswered(string type)
    {
        if (type == "correct")
        {
            numberOfElementsCreated++;
        }
        else
        {
            numberOfHealthLeft--;
            GameObject.Find("WrongAnsText").GetComponent<Text>().text = "You gave wrong answer. You have "+numberOfHealthLeft+" tries left";

            ///// player failed
        }

        if (numberOfHealthLeft < 1)
        {
            SceneManager.LoadScene("Menu");
        }

        
        Debug.Log("Player answered: "+ type);
        Debug.Log("Player Health left: "+ numberOfHealthLeft);
        Debug.Log("Player Elements created: "+ numberOfElementsCreated);

    }
}