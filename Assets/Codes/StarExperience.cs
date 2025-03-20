using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarExperience : MonoBehaviour
{
    private GameDatabase data;
    private Slider slider;
    // Start is called before the first frame update
    private void Awake()
    {
        //data.GetInitialExperience(); Oyuna tekrar girdiğinde kalan experience alacak sliderda gösterecek.
    }
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        data = GameObject.Find("GameDatabase").GetComponent<GameDatabase>();
        slider.value = 0;
        slider.maxValue = 500; //TODO: exponantial olarak level atladıgında artacak.
    }

    public void GetExp(float damage)
    {
        if(damage > slider.maxValue - slider.value)
        {
            slider.value = 0;
            //star gained.
            data.GainStar();

        } else
        {
            slider.value += damage;
            //TODO: Oyundan çıkınca şuanki experience değeri kaydedilcek.
        }
    }
}
