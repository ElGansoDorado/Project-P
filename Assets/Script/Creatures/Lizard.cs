using System.Collections;
using UnityEngine;
public class Lizard : Creatures
{
    private void Awake()
    {
        CostCreature = 250;

        NameCreature = "Lizard";
        EarnedProfit = 5;
        TimeProfit = 6f;
    }

    public override void Skill()
    {
        if (Energy < 1) return;
        base.Skill();

        rep.PlusMoney(EarnedProfit * 10);
        StartCoroutine(CriticalUp());
    }

    private IEnumerator CriticalUp() 
    {
        Debug.Log("Start");
        rep.CriticalSkill = 2;
        yield return new WaitForSeconds(60f);
        rep.CriticalSkill = 1;
        Debug.Log("End");

    }

    public override void SkillUpdate()
    {
        if (LevelSkill >= maxLevelSkill) return;
        base.SkillUpdate();

        rep.MinusMoney(100);
    }
}
