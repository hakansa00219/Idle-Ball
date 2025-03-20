using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameDatabase data;
    public BallCode ballCode;
    public BallCreatorCode ballSpawner;
    public loadingbar loadingbar;
    public Button[] buttons;

    private int _currentStar;
    private void Update()
    {
        //Check buttons if money is enough to buy.
        ButtonConfig();          
    }

    public void UpgradeBallPower()
    {
        //updatedatabase
        data.UpgradeBallPower();
        //inform ballcode
        /*
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        if(balls.Length > 0)
        {
            foreach (GameObject ball in balls)
            {
                ball.GetComponent<BallCode>().UpdateYourself(data);

            }
        }*/
    }
    public void UpgradeSpawnRate()
    {
        //updatedatabase
        data.UpgradeSpawnRate();
        //informballspawner
        loadingbar.UpgradeSpawnRate();
    }
    public void UpgradeSpawnCount()
    {
        //updatedatabase
        data.UpgradeBallSpawnCount();
        //informballspawner
        ballSpawner.UpgradeSpawnCount();
    }
    private void ButtonConfig()
    {
        _currentStar = data.GetStar();
        if (_currentStar < 1)
        {
            buttons[0].interactable = false;
        }
        else
        {
            buttons[0].interactable = true;
        }

        if (_currentStar < 1)
        {
            buttons[1].interactable = false;
        }
        else
        {
            buttons[1].interactable = true;
        }
        if (_currentStar < 5)
        {
            buttons[2].interactable = false;
        }
        else
        {
            buttons[2].interactable = true;
        }
        if (_currentStar < 500)
        {
            buttons[3].interactable = false;
        }
        else
        {
            buttons[3].interactable = true;
        }

    }
}
