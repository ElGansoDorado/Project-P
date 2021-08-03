
public class Slime : Creatures
{
    private void Awake()
    {
        CostCreature = 30;

        NameCreature = "Slimne";
        EarnedProfit = 2;
        TimeProfit = 2f;

        CostTime = 100;
        CostProfit = 100;
        CostEnergy = 100;
        CostCritical = 100;
    }

    public override void Skill()
    {
        if (Energy < 1) return;
        base.Skill();

        rep.PlusMoney(EarnedProfit * 10);
    }
    
    public override void SkillUpdate()
    {
        if (LevelSkill >= maxLevelSkill) return;
        base.SkillUpdate();

        rep.MinusMoney(100);
    }
}
