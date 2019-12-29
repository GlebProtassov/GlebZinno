using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find(transform.name).GetComponent<Button>();
        if (btn != null) btn.onClick.AddListener(SubmitAnswers);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitAnswers()
    {
        GameObject selectedAnswer = GameObject.Find(transform.name + "Text");
       
        
        if (PythagorasHandler.IsSubmittedAnswerCorrect(selectedAnswer.GetComponent<Text>().text))
        {
            PythagorasHandler.DeleteOldElementsInGameArea();
            AnswerOptionScreenHandler.ShowPopUp(false);
            PythagorasHandler.playerAnswered("correct");
        }
        else
        {
            /// loose a life
            PythagorasHandler.playerAnswered("wrongly");

        }
        
    }

    public void OnMouseDown()
    {
        SubmitAnswers();
    }
}
