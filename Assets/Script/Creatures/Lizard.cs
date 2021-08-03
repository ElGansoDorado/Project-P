
public class Lizard : Creatures
{
    private void Awake()
    {
        CostCreature = 300;

        NameCreature = "Lizard";
        EarnedProfit = 5;
        TimeProfit = 3f;

        CostTime = 200;
        CostProfit = 200;
        CostEnergy = 200;
        CostCritical = 200;
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
