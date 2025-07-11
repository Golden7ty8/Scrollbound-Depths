using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestionAnswerType
{
    None,
    TrueOrFalse,
    MultipleChoice,
    FillTheBlank
}

public abstract class AbstractQuestionAnswer
{
    public abstract QuestionAnswerType GetQuestionAnswerType();
    public abstract string GetAnswer();
    public abstract void SetAnswer(string newAnswer);
    public abstract List<string> GetChoices();
    public abstract void SetChoices(params string[] newChoices);
}
