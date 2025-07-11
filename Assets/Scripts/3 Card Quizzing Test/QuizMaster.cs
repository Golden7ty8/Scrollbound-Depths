using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizMaster : MonoBehaviour
{

    [Header("Refferences:")]
    public Transform mainCamera;
    public GameObject cardPrefab;
    public GameObject answerButtonPrefab;

    GameObject instantiatedflashcardPrefab = null;
    Flashcard currentFlashcardData;

    //We assume only one flashcard prefab is loaded at a time.
    void LoadFlashcardDataOntoPrefabInstance(Flashcard flashcard)
    {
        currentFlashcardData = flashcard;

        Transform cardFrontCanvas = instantiatedflashcardPrefab.transform.GetChild(0).GetChild(0);

        cardFrontCanvas.GetChild(0).GetComponent<TextMeshProUGUI>().text = flashcard.title;
        cardFrontCanvas.GetChild(1).GetComponent<TextMeshProUGUI>().text = flashcard.reward.GetDisplayText();
        cardFrontCanvas.GetChild(2).GetComponent<TextMeshProUGUI>().text = flashcard.punishment.GetDisplayText();
        cardFrontCanvas.GetChild(3).GetComponent<TextMeshProUGUI>().text = flashcard.question;

        Transform answerGroup = cardFrontCanvas.GetChild(4);

        switch(flashcard.answerAndOptionData.GetQuestionAnswerType())
        {
            case QuestionAnswerType.TrueOrFalse:
                answerGroup.GetChild(0).gameObject.SetActive(true);
                break;
            case QuestionAnswerType.FillTheBlank:
                answerGroup.GetChild(1).gameObject.SetActive(true);
                break;
            case QuestionAnswerType.MultipleChoice:
                answerGroup.GetChild(2).gameObject.SetActive(true);

                //Extra step with multiple choice: Setup the options.
                List<string> options = flashcard.answerAndOptionData.GetChoices();
                for (int i = 0; i < options.Count; i++)
                {
                    GameObject instantiatedAnswerButton = Instantiate(answerButtonPrefab, answerGroup.GetChild(2));
                    instantiatedAnswerButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = options[i];
                }

                break;
        }
    }

    /// <summary>
    /// Makes the card appear right in front of the camera, so it takes up pretty much the whole screen.
    /// At first, only the back of the card is visible, but with a click of any mouse button of keyboard press,
    /// the card will flip over and reveal it's contents, thus starting the quizzing (which is it's own function).
    /// </summary>
    public void ActivateCard(Flashcard flashcard)
    {
        instantiatedflashcardPrefab = Instantiate(cardPrefab, mainCamera, false);
        LoadFlashcardDataOntoPrefabInstance(flashcard);
        //Start with the back of the card facing the camera.
        instantiatedflashcardPrefab.transform.Rotate(0, 180, 0, Space.Self);

        //BLASH BLAH BLAH flip over, animation thing blah blah.

        instantiatedflashcardPrefab.transform.Rotate(0, -180, 0, Space.Self);

        StartQuizzing(flashcard);
    }

    /// <summary>
    /// Begin quizzing, if this function is run on it's own without the ActivateCard function, the front of the
    /// card will just appear and quizzing will start immediatly without the extra dramatics in the ActivateCard
    /// function.
    /// </summary>
    public void StartQuizzing(Flashcard flashcard)
    {
        if(instantiatedflashcardPrefab == null)
        {
            instantiatedflashcardPrefab = Instantiate(cardPrefab, mainCamera, false);
            LoadFlashcardDataOntoPrefabInstance(flashcard);
        }
    }

    //Below are the functions for when UI elements on the card are interacted with by the player to submit an answer.

    public void OnTrueOrFalseButtonPressed(bool playerAnswer)
    {
        Debug.Log(playerAnswer);

        string playerAnswerAsString = playerAnswer ? "True" : "False";

        OnAnswerGiven(playerAnswerAsString);
    }

    public void OnMultipleChoiceButtonPressed(int playerAnswer)
    {
        Debug.Log(playerAnswer);

        string playerAnswerAsString = currentFlashcardData.answerAndOptionData.GetChoices()[playerAnswer];

        OnAnswerGiven(playerAnswerAsString);
    }

    public void OnFillTheBlankInputFieldCompleted(string playerAnswer)
    {
        Debug.Log(playerAnswer);

        string playerAnswerAsString = playerAnswer;

        OnAnswerGiven(playerAnswerAsString);
    }

    //All three of the above functions call this function in order to do the final processing of a player's given answer.
    public void OnAnswerGiven(string playerAnswerAsString)
    {
        if(playerAnswerAsString == currentFlashcardData.answerAndOptionData.GetAnswer())
        {
            Debug.Log("Correct!");

            currentFlashcardData.reward.ApplyEffect();
        } else
        {
            Debug.Log("Incorrect.");

            currentFlashcardData.punishment.ApplyEffect();
        }
    }
}
