using UnityEngine;
using UnityEngine.UI;

public class Improvement : MonoBehaviour
{
    private Repository rep = Repository.GetInstance(); 
    private Text[] UpdateTextUI = new Text[12];
    public Creatures creature;

    //максимальные уровни
    private const byte maxLevelTime = 20; // максимальное кол-во улучшений для времени
    private const byte maxLevelProfit = 20; // максимальное кол-во улучшений для прибыли
    private const byte maxLevelCritical = 20; // максимальное кол-во улучшений для шанса крита
    private const byte maxLevelEnergy = 20; // максимальное кол-во улучшений для шанса выпадения энергии


    public byte LevelTime { get; private set; } //уровень улучшения времени
    public byte LevelProfit { get; private set; } //уровень улучшения прибыли
    public byte LevelCritical { get; private set; } // уровень улучшения крита на монеты 
    public byte LevelEnergy { get; private set; } // уровень улучшения шанса выпадения энергии 

    private bool GetImproveUp(ref byte level, byte levelMax)
    {
        if(!rep.ChecMoney(creature.CostCreature * Mathf.Pow(1.5, level)) || level >= levelMax) return false;

        rep.MinusMoney(creature.CostCreature * Mathf.Pow(1.5, level));
        level++;

        UpdateUI();
        return true;
    }
    private void Awake()
    {
        UpdateTextUI = GetComponentsInChildren(); 
        UpdateUI();
    }

    //методы улучшений
    public void UpdateTime() // уменьшение времени
    {
        if (GetImproveUp(ref LevelTime, maxLevelTime)) 
            creature.TimeProfit -= (creature.TimeProfit / 2) / maxLevelTime;
    }

    public void UpdateProfit() //увеличивание дохода
    {
        if (GetImproveUp(ref LevelProfit,maxLevelProfit))
            creature.EarnedProfit += 2;
    }

    public void UpdateCritical() // улучшение для крита
    {
        if (GetImproveUp(ref LevelCritical, maxLevelCritical))
            creature.Critical += 1;
    }

    public void UpdateEnergy() // улучшение для шанса выпадения энергии 
    {
        if (GetImproveUp(ref LevelEnergy, maxLevelEnergy))
            creature.LuckEnergy += 1;
    }

    private void UpdateUI()
    {
        UpdateTextUI[0].text = $"{LevelTime}/{maxLevelTime}";
        UpdateTextUI[1].text = Rounding.FormatNum(creature.CostCreature * Mathf.Pow(1.5, LevelTime));

        UpdateTextUI[3].text = $"{LevelCritical}/{maxLevelCritical}";
        UpdateTextUI[4].text = Rounding.FormatNum(creature.CostCreature * Mathf.Pow(1.5, LevelCritical));

        UpdateTextUI[6].text = $"{LevelEnergy}/{maxLevelEnergy}";
        UpdateTextUI[7].text = Rounding.FormatNum(creature.CostCreature * Mathf.Pow(1.5, LevelEnergy));

        UpdateTextUI[9].text = $"{LevelProfit}/{maxLevelProfit}";
        UpdateTextUI[10].text = Rounding.FormatNum(creature.CostCreature * Mathf.Pow(1.5, LevelProfit));
    }
}
