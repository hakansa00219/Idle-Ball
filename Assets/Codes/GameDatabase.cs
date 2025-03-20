using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameDatabase : MonoBehaviour
{
    /*Ball data*/
    private float _ballPower;
    /*Spawner data*/
    private float _spawnRate;
    private int _ballSpawnCount;
    /*Player data*/
    private float _experience;
    private int _star;
    private int _currentLevel;
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI[] _textArr;


    private void Update()
    {
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        moneyText.text = "$: " + _star;
        _textArr[0].text = System.String.Format("{0:0.##}", _ballPower);
        _textArr[2].text = System.String.Format("{0:0.##}", _spawnRate);
        _textArr[3].text = _ballSpawnCount.ToString();
    }
    private void Awake()
    {
        InitializeLevelInfo();
    }
    private void Start()
    {
        //TODO: if save dosyası yoksa varsa neyse.
        /*Initialize datas*/
   
        InitializeBallInfo();
        InitializeSpawnerInfo();
        InitializeExperienceInfo();
        InitializeStarInfo();
        
    }
    
    /*Initializers*/
    void InitializeStarInfo()
    {
        _star = 0;
    }
    void InitializeExperienceInfo()
    {
        _experience = 0f;
    }
    void InitializeLevelInfo()
    {
        _currentLevel = 1;
    }
    void InitializeBallInfo()
    {
        
        _ballPower = 1.0f;
    }

    void InitializeSpawnerInfo()
    {
        _spawnRate = 0.01f;
        _ballSpawnCount = 1;
    }

    /*Setters*/
    public void UpgradeBallPower(){ _ballPower += 0.1f; _star -= 1; }
    public void UpgradeSpawnRate() { _spawnRate += 0.01f; _star -= 5; }
    public void UpgradeBallSpawnCount() { _ballSpawnCount += 1; _star -= 500; }
    public void GainExperience(float experience) { _experience += experience; }
    public void GainStar() { _star++; }
    public void UpgradeLevel(int level) { _currentLevel = level; }
    /*Getters*/
    public float GetBallPower() { return _ballPower; }
    public float GetSpawnRate() { return _spawnRate; }
    public int GetBallSpawnCount() { return _ballSpawnCount; }
    public int GetStar() { return _star; }
    public int GetCurrentLevel() { return _currentLevel; }
}
