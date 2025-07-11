using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillTheBlankQuestionAnswer : AbstractQuestionAnswer
{
    string answer;

    public FillTheBlankQuestionAnswer(string answer)
    {
        this.answer = answer;
    }

    public override QuestionAnswerType GetQuestionAnswerType()
    {
        return QuestionAnswerType.FillTheBlank;
    }

    public override string GetAnswer()
    {
        return answer;
    }

    public override void SetAnswer(string newAnswer)
    {
        answer = newAnswer;
    }

    public override List<string> GetChoices()
    {
        Debug.LogError("This function does not apply to this type of question.");
        return null;
    }

    public override void SetChoices(params string[] newChoices)
    {
        Debug.LogError("This function does not apply to this type of question.");
    }
}
