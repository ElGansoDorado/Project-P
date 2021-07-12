using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Получение монет
/// </summary>

abstract public class GettingGold : MonoBehaviour
{
    public Repository rep;
    public byte Level { get; set; }
    private byte tapCount; //количество совершённых кликов
    public byte TapCount
    {
        get => tapCount;
        set
        {
            if (value >= CoinValueMax) tapCount = TapMax;
            else tapCount = value;

            remainingNumberOfClicksUI.text = "кликов: " + TapCount + "/" + TapMax;
        }
    }
    public byte TapMax { get; set; } //кол-во кликов, которое нужно совершить

    private int coinValue; //содержимое хранилища
    public int CoinValue
    {
        get => coinValue;
        set
        {
            if (value >= CoinValueMax) coinValue = CoinValueMax;
            else coinValue = value;

            infoUI.text = CoinValue + "/" + CoinValueMax;
        }
    }
    public int CoinValueMax { get; set; } //объём хранилища 
    public int IncreaseCoins { get; set; } // кол-во получаемых монет 

    public Text infoUI; //ui на кол-во монет в хранилище 
    public Text remainingNumberOfClicksUI; //ui на кол-во кликов до спавна новых монет 

    public void TapCheck() // метод для генерации монет 
    {
        TapCount++;

        if (TapCount >= TapMax)
        {
            TapCount = 0;
            CoinValue += IncreaseCoins;
        }
    }

    public void GoldsPlus()
    {
        rep.PlusCoin(CoinValue); //забираем монетки в общее хранилище
        CoinValue = 0;
    }
}
