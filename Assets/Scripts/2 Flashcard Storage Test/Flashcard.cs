using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Flashcard
{
    public string title;
    public string imagePath;
    public string question;
    public AbstractQuestionAnswer answerAndOptionData;
    public Effect reward;
    public Effect punishment;

    public Flashcard(string title, string imagePath, string question, AbstractQuestionAnswer answerAndOptionData, EffectType rewardType, int rewardAmount, EffectType punishmentType, int punishmentAmount)
    {
        this.title = title;
        this.imagePath = imagePath;
        this.question = question;
        this.answerAndOptionData = answerAndOptionData;
        this.reward = new Effect(rewardType, rewardAmount);
        this.punishment = new Effect(punishmentType, punishmentAmount);
    }
}
