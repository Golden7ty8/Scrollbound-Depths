using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Receives any button presses or other UI events and passes them on to those that need it.
/// This is needed because some elements are instantiated during runtime.
/// </summary>
public class AnswerUIPassthrough : MonoBehaviour
{

    QuizMaster quizMaster;

    void Awake()
    {
        quizMaster = GameObject.Find("Global Scripts").GetComponent<QuizMaster>();
    }

    public void OnTrueOrFalseButtonPressed(bool playerAnswer)
    {
        quizMaster.OnTrueOrFalseButtonPressed(playerAnswer);
    }

    public void OnMultipleChoiceButtonPressed()
    {
        int playerAnswer = transform.GetSiblingIndex();
        quizMaster.OnMultipleChoiceButtonPressed(playerAnswer);
    }

    public void OnFillTheBlankInputFieldCompleted(string playerAnswer)
    {
        quizMaster.OnFillTheBlankInputFieldCompleted(playerAnswer);
    }
}
