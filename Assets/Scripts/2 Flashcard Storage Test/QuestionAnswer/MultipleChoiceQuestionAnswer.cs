using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChoiceQuestionAnswer : AbstractQuestionAnswer
{

    public List<string> choices;
    public int answerIndex;

    public MultipleChoiceQuestionAnswer(int answerIndex, params string[] choices)
    {
        this.choices = new List<string>(choices);
        this.answerIndex = answerIndex;
    }

    public override QuestionAnswerType GetQuestionAnswerType()
    {
        return QuestionAnswerType.MultipleChoice;
    }

    public override string GetAnswer()
    {
        if (choices.Count == 0)
        {
            Debug.LogError("There are no choices!");
            return null;
        }

        if (answerIndex < 0 || answerIndex >= choices.Count)
        {
            Debug.LogError("answerIndex out of range of choices, answerIndex = " + answerIndex + " and choises.Count = " + choices.Count);
            return null;
        }

        return choices[answerIndex];
    }

    public override void SetAnswer(string newAnswer)
    {
        if (!choices.Contains(newAnswer))
        {
            Debug.LogError("newAnswer is not in choices!");
            return;
        }

        answerIndex = choices.IndexOf(newAnswer);
    }

    public override List<string> GetChoices()
    {
        return choices;
    }

    public override void SetChoices(params string[] newChoices)
    {
        choices = new List<string>(newChoices);
    }
}
