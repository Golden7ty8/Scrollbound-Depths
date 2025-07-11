using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3ActiveScript : MonoBehaviour
{
    public enum Test3RunModeOptions {
        RunActivateCard,
        RunStartQuizzing
    }

    [Header("Settings:")]
    public Test3RunModeOptions runModeOptions;
    public int flashcardGroupIndex;
    public int flashcardIndex;

    [Header("Refferences:")]
    public QuizMaster quizMaster;
    public FlashcardStorage flashcardStorage;

    // Start is called before the first frame update
    void Start()
    {
        flashcardStorage.FillStorageWithExampleData();

        switch(runModeOptions)
        {
            case Test3RunModeOptions.RunActivateCard:
                quizMaster.ActivateCard(flashcardStorage.GetFlashcard(flashcardGroupIndex, flashcardIndex));
                break;
            case Test3RunModeOptions.RunStartQuizzing:
                quizMaster.StartQuizzing(flashcardStorage.GetFlashcard(flashcardGroupIndex, flashcardIndex));
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
