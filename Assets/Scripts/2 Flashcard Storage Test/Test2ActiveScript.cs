using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2ActiveScript : MonoBehaviour
{

    public FlashcardStorage flashcardStorage;

    // Start is called before the first frame update
    void Start()
    {
        flashcardStorage.FillStorageWithExampleData();

        flashcardStorage.PrintAllFlashCards();

        Debug.Log("--------------------");

        flashcardStorage.PrintFlashcard(flashcardStorage.GetFlashcard(0, 0));
        flashcardStorage.PrintFlashcard(flashcardStorage.GetFlashcardGroup(0)[1]);
        flashcardStorage.PrintFlashcard(flashcardStorage.GetFlashcardGroups()[1][0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
