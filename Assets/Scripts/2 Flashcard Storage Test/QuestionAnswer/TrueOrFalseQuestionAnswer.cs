using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueOrFalseQuestionAnswer : AbstractQuestionAnswer
{
    bool answer;

    public TrueOrFalseQuestionAnswer(bool answer)
    {
        this.answer = answer;
    }

    public override QuestionAnswerType GetQuestionAnswerType()
    {
        return QuestionAnswerType.TrueOrFalse;
    }

    public override string GetAnswer()
    {
        return answer ? "True" : "False";
    }

    public override void SetAnswer(string newAnswer)
    {
        if (newAnswer == "True")
            answer = true;
        else if (newAnswer == "False")
            answer = false;
        else
            Debug.LogError("Invalid argument: newAnswer = " + newAnswer);
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
