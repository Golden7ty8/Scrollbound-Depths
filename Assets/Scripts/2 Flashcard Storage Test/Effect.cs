using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    None,
    Food,
    Health
}

[System.Serializable]
public class Effect
{
    public EffectType effectType;
    public int effectAmount;

    public Effect(EffectType effectType, int effectAmount)
    {
        this.effectType = effectType;
        this.effectAmount = effectAmount;
    }

    public string GetDisplayText()
    {
        return effectType.ToString() + ": " + (effectAmount > 0 ? "+" : "") + effectAmount;
    }

    public void ApplyEffect()
    {
        switch(effectType)
        {
            case EffectType.Food:
                StaticLinks.hungerStatBarScript.AddMeterValue(effectAmount);
                break;
            case EffectType.Health:
                StaticLinks.healthStatBarScript.AddMeterValue(effectAmount);
                break;
        }
    }
}
