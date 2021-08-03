using UnityEngine;
using UnityEngine.UI;

public class Improvement : MonoBehaviour
{
    private Repository rep = Repository.GetInstance(); 
    private Creatures creature;

    public Text TimeLevelUI;
    public Text ProfitLevelUI;
    public Text KritLevelUI;
    public Text EnergiLevelUI;

    public Text CostUpdateTimeUI;
    public Text CostUpdateProfitUI;
    public Text CostUpdateCriticalUI;
    public Text CostUpdateEnergiUI;

    //максимальные уровни
    private const byte maxLevelTime = 20; // максимальное кол-во улучшений для времени
    private const byte maxLevelProfit = 20; // максимальное кол-во улучшений для прибыли
    private const byte maxLevelCritical = 20; // максимальное кол-во улучшений для шанса крита
    private const byte maxLevelEnergy = 20; // максимальное кол-во улучшений для шанса выпадения энергии


    public byte LevelTime { get; private set; } //уровень улучшения времени
    public byte LevelProfit { get; private set; } //уровень улучшения прибыли
    public byte LevelCritical { get; private set; } // уровень улучшения крита на монеты 
    public byte LevelEnergy { get; private set; } // уровень улучшения шанса выпадения энергии 

    private void Awake()
    {
        creature = GetComponent<Creatures>();
        UpdateUI();
    }

    //методы улучшений
    public void UpdateTime() // уменьшение времени
    {
        if (rep.CheckMoney(creature.CostTime) && LevelTime < maxLevelTime)
        {
            LevelTime++;

            rep.MinusMoney(creature.CostTime);
            creature.CostTime *= 2;
            creature.TimeProfit -= (creature.TimeProfit / 2) / maxLevelTime;
        }
        UpdateUI();
    }

    public void UpdateProfit() //увеличивание дохода
    {
        if (rep.CheckMoney(creature.CostProfit) && LevelProfit < maxLevelProfit)
        {
            LevelProfit++;

            rep.MinusMoney(creature.CostProfit);
            creature.CostProfit *= 2;
            creature.EarnedProfit += 2;
        }
        UpdateUI();
    }

    public void UpdateCritical() // улучшение для крита
    {
        if (rep.CheckMoney(creature.CostCritical) && LevelCritical < maxLevelCritical)
        {
            LevelCritical++;

            rep.MinusMoney(creature.CostCritical);
            creature.CostCritical *= 2;
            creature.Critical += 1;
        }
        UpdateUI();
    }

    public void UpdateEnergy() // улучшение для шанса выпадения энергии 
    {
        if (rep.CheckMoney(creature.CostEnergy) && LevelEnergy < maxLevelEnergy)
        {
            LevelEnergy++;

            rep.MinusMoney(creature.CostEnergy);
            creature.CostEnergy *= 2;
            creature.LockEnergy += 1;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        TimeLevelUI.text = $"{LevelTime}/{maxLevelTime}";
        ProfitLevelUI.text = $"{LevelProfit}/{maxLevelProfit}";
        KritLevelUI.text = $"{LevelCritical}/{maxLevelCritical}";
        EnergiLevelUI.text = $"{LevelEnergy}/{maxLevelEnergy}";

        CostUpdateTimeUI.text = Rounding.FormatNum(creature.CostTime);
        CostUpdateProfitUI.text = Rounding.FormatNum(creature.CostProfit);
        CostUpdateCriticalUI.text = Rounding.FormatNum(creature.CostCritical);
        CostUpdateEnergiUI.text = Rounding.FormatNum(creature.CostEnergy);
}
}
