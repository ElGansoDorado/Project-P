using System.Collections;
using UnityEngine;
using UnityEngine.UI;

abstract public class Creatures : MonoBehaviour
{
    protected Repository rep = Repository.GetInstance();

    private DrawingProgress drawProg;
    public string NameCreature { get; protected set; } // имя существа


    protected readonly byte maxLevelSkill = 20; // максимальное кол-во улучшений для умения
    public byte LevelSkill { get; protected set; } // уровень умения

    public byte Energy { get; protected set; } // кол-во энергии
    public int EarnedProfit { get; set; } // количество получаемых монет
    public float TimeProfit { get; set; } // время до получения монет

    public int CostCreature { get; protected set; } //цена существа.

    public byte Critical { get; set; } //для рандома крита.
    public byte LuckEnergy { get; set; } = 1; // для рандома энергии.

    private void Start()
    {
        drawProg = GetComponent<DrawingProgress>();
    }
    public IEnumerator GrindCorutine()
    {
        while (true)
        {
            for (int i = 0; i < 20; i++)
            {
                yield return new WaitForSeconds((float)TimeProfit  / 20);
                drawProg.BarDrawing(0.05f);
            }

            if (Critical >= Random.Range(0, 101)) rep.PlusMoney(EarnedProfit * 2); //начисление монет с критом и без.
            else rep.PlusMoney(EarnedProfit);

            if (LockEnergy >= Random.Range(0, 101) && Energy <= 3) 
            { 
                Energy++; 
                drawProg.EnergiDrawingPlus(0.35f);
            }//шанс на выпадение энергии.
        }
    }

    //методы для умения.
    public virtual void SkillUpdate() 
    {
        LevelSkill++;
    }

    public virtual void Skill() 
    {
        Energy--;
        drawProg.EnergiDrawingMinus(0.35f);
    }

}