using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : GettingGold //слайм. Можно будет сделать возможность опгрейдить его до иридьевого слайма=)
{
    void Start()
    {
        Level = 0; //уровень.

        TapCount = 0; //кол-во совершённых кликов. 
        TapMax = 4; //количество кликов для получения монет.

        CoinValue = 0; //эти 2 параметра под вопросом. Возможно сделаю их через объект. Тип кошелёк. Но не факт.
        CoinValueMax = 100; //максемально количество сохраняемого золота в хранилище

        IncreaseCoins = 10; // прибыль, которую приносит существо 
    }
}
