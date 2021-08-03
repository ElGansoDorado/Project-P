
public class Repository 
{
    // небольшая попытка задействовать одиночку...
    private static Repository repository = null;

    private Repository() { }

    public static Repository GetInstance()
    {
        if (repository == null) repository = new Repository();

        return repository;
    }

    private int gem; //Кристаллы.
    public int Gem 
    { 
        get => gem;
        private set
        {
            if (value - gem > gem)
                GemDuringAllThisTime += value - gem;
            gem = value;
        }  
    } // кол-во кристаллов 
    public int GemDuringAllThisTime { get; private set; } //кристаллы за всё время

    private int money; // монеты
    public int Money 
    { 
        get => money; 
        private set
        {
            if (value - money > money)
                MoneyDuringAllThisTime += value - money;
            money = value;
        }
    } //кол-во монет
    public int MoneyDuringAllThisTime { get; private set; } // монеты за всё врем

    // и ещё куча различной статистики: 

    public int TapNumbers { get; set; } //количество совершённых кликов.


    // пару методов для работы с монетами..
    public void PlusMoney(int money) => Money += money;
    public void MinusMoney(int money) => Money -= money;
    public bool CheckMoney(int cost)
    {
        if (Money >= cost) return true;
        return false;
    }
}
