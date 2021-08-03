using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    private Repository rep = Repository.GetInstance();

    public Text MoneyUI; // отоброжаем кол-во монет
    public Image Bar; // бар для отоброжения прогресcа.
    public Image paintings; // для замены картинки 

    public Sprite[] Sprites = new Sprite[3]; //ещё не работал с файлами, поэтому пока так.
    public byte NumberSprite { get; private set; } //выбирает какой спрайт сейчас будет отоброжаться 

    public int NumbersOfClicks { get; private set; } = 30; //количество кликов нужных для замены картинки
    public int Increments { get; private set; } = 1; // прибыль за клик 

    private void Start()
    {
        Bar.fillAmount = 0f;
    }

    public void OnClick()
    {
        Click();
    }

    private void Click() // 
    {
        rep.PlusMoney(Increments);

        Bar.fillAmount += (float)1 / NumbersOfClicks;
        if (Bar.fillAmount >= 1.0f)
        {
            Bar.fillAmount = 0f;
            NextSprite();
        }
    }

    private void NextSprite()
    {
        NumberSprite++;
        if (NumberSprite >= Sprites.Length) NumberSprite = 0;

        paintings.sprite = Sprites[NumberSprite];
    }

    private void Update() // обновляем ui объекты
    {
        MoneyUI.text = Rounding.FormatNum(rep.Money);
    }
}
