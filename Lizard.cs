using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : GettingGold //ящерица.
{
    void Start()
    {
        Level = 0; //уровень.

        TapCount = 0; //кол-во совершённых кликов. 
        TapMax = 5; //количество кликов для получения монет.

        CoinValue = 0; //эти 2 параметра под вопросом. Возможно сделаю их через объект. Тип кошелёк. Но не факт.
        CoinValueMax = 100; //максемально количество сохраняемого золота в хранилище

        IncreaseCoins = 12; // прибыль, которую приносит существо 
    }
}
