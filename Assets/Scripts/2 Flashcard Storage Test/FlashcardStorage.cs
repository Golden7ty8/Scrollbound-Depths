using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashcardStorage : MonoBehaviour
{
    List<List<Flashcard>> flashcardGroups;

    public void AddFlashcard(int flashcardGroupIndex, string title, string imagePath, string question, AbstractQuestionAnswer answerAndOptionData, EffectType rewardType, int rewardAmount, EffectType punishmentType, int punishmentAmount)
    {
        //If flashcardGroupIndex does not exist in flashcardGroups, make the list longer.
        while(flashcardGroupIndex >= flashcardGroups.Count)
            flashcardGroups.Add(new List<Flashcard>());

        Flashcard newFlashcard = new Flashcard(title, imagePath, question, answerAndOptionData, rewardType, rewardAmount, punishmentType, punishmentAmount);
        flashcardGroups[flashcardGroupIndex].Add(newFlashcard);
    }

    public void RemoveFlashcard(int flashcardGroupIndex, int flashcardIndex)
    {
        flashcardGroups[flashcardGroupIndex].RemoveAt(flashcardIndex);
    }

    public void RemoveFlashcardGroup(int flashcardGroupIndex)
    {
        flashcardGroups.RemoveAt(flashcardGroupIndex);
    }

    public Flashcard GetFlashcard(int flashcardGroupIndex, int flashcardIndex)
    {
        return flashcardGroups[flashcardGroupIndex][flashcardIndex];
    }

    public List<Flashcard> GetFlashcardGroup(int flashcardGroupIndex)
    {
        return flashcardGroups[flashcardGroupIndex];
    }

    public List<List<Flashcard>> GetFlashcardGroups()
    {
        return flashcardGroups;
    }

    public void FillStorageWithExampleData()
    {
        EmptyStorage();

        AddFlashcard(0, "Example Title 1", "imagepath1", "Marshmallows are tasty.", new TrueOrFalseQuestionAnswer(false), EffectType.Food, 20, EffectType.Health, -15);
        AddFlashcard(0, "Example Title 2", "imagepath2", "Choose the most nauseating.", new MultipleChoiceQuestionAnswer(0, "Eggs", "Lettuce", "Ice Cream"), EffectType.Food, 25, EffectType.Health, -10);
        AddFlashcard(1, "Example Title 3", "imagepath3", "What is the answer to life, the universe, and everything?", new FillTheBlankQuestionAnswer("42"), EffectType.Food, 10, EffectType.Food, -15);

        AddFlashcard(1, "Example Title 4", "imagepath4", "DELETE THIS", new FillTheBlankQuestionAnswer("???"), EffectType.Food, 10, EffectType.Food, -15);
        RemoveFlashcard(1, 1);

        AddFlashcard(2, "Example Title 5", "imagepath5", "DELETE THIS", new FillTheBlankQuestionAnswer("???"), EffectType.Food, 10, EffectType.Food, -15);
        AddFlashcard(2, "Example Title 6", "imagepath6", "DELETE THIS", new FillTheBlankQuestionAnswer("???"), EffectType.Food, 10, EffectType.Food, -15);
        RemoveFlashcardGroup(2);
    }

    public void EmptyStorage()
    {
        flashcardGroups = new List<List<Flashcard>>();
    }

    public void PrintFlashcard(Flashcard flashcard)
    {
        //Extra Stuff to print if the flashcard is a multiple choice question.
        string optionString = "";
        if (flashcard.answerAndOptionData.GetQuestionAnswerType() == QuestionAnswerType.MultipleChoice)
        {
            List<string> theseOptions = flashcard.answerAndOptionData.GetChoices();
            optionString = "\nOptions:";

            for (int j = 0; j < theseOptions.Count; j++)
            {
                optionString += " '" + theseOptions[j] + "'";
            }
        }

        Debug.Log(
            ".\nTitle: " + flashcard.title +
            "\nImage Path: " + flashcard.imagePath +
            "\nQuestion: " + flashcard.question +
            optionString +
            "\nAnswer: " + flashcard.answerAndOptionData.GetAnswer() +
            "\nReward: " + flashcard.reward.GetDisplayText() +
            "\nPunishment: " + flashcard.punishment.GetDisplayText() +
            "\n\n"
            );

    }

    public void PrintAllFlashCards()
    {
        for(int i = 0; i < flashcardGroups.Count; i++)
        {
            for(int j = 0; j < flashcardGroups[i].Count; j++)
            {
                PrintFlashcard(flashcardGroups[i][j]);
            }
        }
    }

    /*public string GetInfoToPrint(int flashcardGroupIndex)
    {
        string resultingPrintableInfo = "";
        for (int i = 0; i < flashcardGroups[flashcardGroupIndex].Count; i++)
        {
            //Extra Stuff to print if the flashcard is a multiple choice question.
            string optionString = "";
            if (flashcardGroups[flashcardGroupIndex][i].answerAndOptionData.GetQuestionAnswerType() == QuestionAnswerType.MultipleChoice)
            {
                List<string> theseOptions = flashcardGroups[flashcardGroupIndex][i].answerAndOptionData.GetChoices();
                optionString = "\nOptions:";

                for (int j = 0; j < theseOptions.Count; j++)
                {
                    optionString += " '" + theseOptions[j] + "'";
                }
            }

            resultingPrintableInfo += (i + 1) +
                ".\nTitle: " + flashcardGroups[flashcardGroupIndex][i].title +
                "\nImage Path: " + flashcardGroups[flashcardGroupIndex][i].imagePath +
                "\nQuestion: " + flashcardGroups[flashcardGroupIndex][i].question +
                optionString +
                "\nAnswer: " + flashcardGroups[flashcardGroupIndex][i].answerAndOptionData.GetAnswer() +
                "\nReward: " + flashcardGroups[flashcardGroupIndex][i].reward.GetInfoToPrint() +
                "\nPunishment: " + flashcardGroups[flashcardGroupIndex][i].punishment.GetInfoToPrint() +
                "\n\n";
        }

        return resultingPrintableInfo;
    }*/

}
