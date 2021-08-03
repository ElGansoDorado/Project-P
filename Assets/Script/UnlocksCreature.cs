using UnityEngine;
using UnityEngine.UI;

public class UnlocksCreature : MonoBehaviour
{
    private Repository rep = Repository.GetInstance();

    private Text CostUI;
    private Creatures creature;

    private int cost;

    private void Start()
    {
        creature = GetComponentInParent<Creatures>();
        cost = creature.CostCreature;

        CostUI = GetComponentInChildren<Text>();
        CostUI.text = Rounding.FormatNum(cost);
    }

    public void Unlock()
    {
        if (rep.CheckMoney(cost))
        {
            creature.StartCoroutine(creature.GrindCorutine());

            rep.MinusMoney(cost);
            gameObject.SetActive(false);
        }
    }
}
