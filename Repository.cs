using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Хранилище монет, аля банк
/// </summary>

public class Repository : MonoBehaviour
{
    private static long coins;
    public static long Coins
    {
        get => coins;
        set => coins = value;
    }

    public Text CoinsUI;
    public Repository() { }
    static Repository()
    {
        Coins = 0;
    }
        
    public void PlusCoin(int plusCoin)
    {
        Coins += plusCoin; //Прибавляем монетки
        CoinsUI.text = Rounding.FormatNum(Coins);
    }
}
