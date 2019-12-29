using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    bool selected = false;
     Vector3 previousPosition; 
     bool elementCurrentlyInUse = false;
     private static System.Random randomGenerator2 = new System.Random();
    
    void Update()
    {
        
        
        if(selected)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;

        }
    }

    private void Start()
    {
        previousPosition = transform.position;
     
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!elementCurrentlyInUse)
            {
                selected = true;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("stopped??");

        if (!elementCurrentlyInUse)
        {
            elementCurrentlyInUse = true;
            PythagorasHandler.numOfDroppedElements = PythagorasHandler.numOfDroppedElements+1;
            RegenerateElement();
            elementCurrentlyInUse = false;
            if (PythagorasHandler.numOfDroppedElements >= 2)
            {
                PythagorasHandler.numOfDroppedElements = 0;
                Debug.Log("Attempt to generate numbers");
                PythagorasHandler.GenerateNewNumbers();
                Debug.Log(PythagorasHandler.firstNum.ToString());
                Debug.Log("----------------------------------------------------");
                Debug.Log("----------------------------------------------------");
                Debug.Log("----------------------------------------------------");
                Debug.Log("----------------------------------------------------");
                Debug.Log("----------------------------------------------------");
                
                SetQuestionAndAnswerOptions();
                
            }
        }
    }

  


    private void RegenerateElement()
    {
        
        GameObject currentElementContainer = GameObject.Find(name + "Container");
        GameObject currentElement = GameObject.Find(name);
        GameObject instantiate = Instantiate(currentElement, new Vector3(previousPosition.x,previousPosition.y), currentElementContainer.transform.rotation);
        
        /// store new elements to be deleted later and old element to be returned
        if (PythagorasHandler.numOfDroppedElements == 1)
        {
            PythagorasHandler.selectedElement1 = instantiate;
            PythagorasHandler.oldElement1 = currentElement;
            PythagorasHandler.oldElement1Position = previousPosition;
        }
        else
        {
            PythagorasHandler.selectedElement2 = instantiate;
            PythagorasHandler.oldElement2 = currentElement;

            PythagorasHandler.oldElement2Position = previousPosition;


        }
        
        
        if (PythagorasHandler.gameObjectsInUse != null) PythagorasHandler.gameObjectsInUse.Add(instantiate);
    }

    private void ResetPlayArea()
    {
        
    }
    
    private void SetQuestionAndAnswerOptions()
    {

        AnswerOptionScreenHandler.ShowPopUp(true);
        
        
      //  currentElementContainer.SetActive(true);
     
       Debug.Log( "current state: "+PythagorasHandler.showAnswerBox);
        
        double answerNumber1 = PythagorasHandler.answer + 1.2;
        double answerNumber2 = PythagorasHandler.answer - 1.5;
        double answerNumber3 = PythagorasHandler.answer;
        
        int randomAnswerSlot1 = randomGenerator2.Next(1, 3); 
        int randomAnswerSlot2, randomAnswerSlot3;
        
        if (randomAnswerSlot1 == 1) { randomAnswerSlot2 = 3;randomAnswerSlot3 = 2; }
        else if (randomAnswerSlot1 == 2) { randomAnswerSlot2 = 1;randomAnswerSlot3 = 3; }
        else { randomAnswerSlot2 = 2;randomAnswerSlot3 = 1; }

        Debug.Log("testing:"+randomAnswerSlot1+randomAnswerSlot2+randomAnswerSlot3);
        GameObject.Find("AnswerOption"+randomAnswerSlot1+"Text").GetComponent<Text>().text = answerNumber1.ToString();
        GameObject.Find("AnswerOption"+randomAnswerSlot2+"Text").GetComponent<Text>().text = answerNumber2.ToString();
        GameObject.Find("AnswerOption"+randomAnswerSlot3+"Text").GetComponent<Text>().text = answerNumber3.ToString();
        GameObject.Find("Question").GetComponent<Text>().text = PythagorasHandler.firstNum.ToString()+" ² + "+
                                                                PythagorasHandler.secondNum.ToString()+" ² = ?";

    }
    
}