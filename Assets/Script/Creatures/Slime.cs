
public class Slime : Creatures
{
    private void Awake()
    {
        CostCreature = 50;

        NameCreature = "Slimne";
        EarnedProfit = 2;
        TimeProfit = 2f;
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
