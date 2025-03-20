using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SquareCode : MonoBehaviour
{
    /*public variables*/
    //...
    private float health;
    private StarExperience starExperience;

    /*private variables*/
    private GameObject _obstacleContainer;
    [SerializeField]
    private TextMeshPro _lifeText;

    public int selfNumber;

    private bool destroyed = false;

    private void Awake()
    {
        _lifeText = gameObject.GetComponentInChildren<TextMeshPro>();
        _obstacleContainer = GameObject.Find("ObstaclesContainer");
        starExperience = GameObject.FindGameObjectWithTag("EXP").GetComponent<StarExperience>();
    }

    void Start()
    {
        int myLevel = ((selfNumber-1) / 35) + 1;
        this.health = (int)Random.Range(1 * Mathf.Pow(100, myLevel - 1), 10 * Mathf.Pow(100, myLevel - 1));
        _lifeText.text = health.ToString();
        this.transform.parent = _obstacleContainer.transform;

    }

    void Update()
    {
        if (health <= 0 && !destroyed)
        {
            _obstacleContainer.GetComponentInParent<SquareCreatorCode>().IamDestroyed(selfNumber);
            Destroy(gameObject, 0.01f);
            destroyed = true;
        }
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            
            BallCode ballScript = collision.gameObject.GetComponent<BallCode>();



            if (health > ballScript.Power)
            {
                health -= ballScript.Power;
                starExperience.GetExp(ballScript.Power);
            }
            else
            {
                starExperience.GetExp(this.health);
                health = 0;                
            }           
            if (health > 0f && health < 1f)
            {
                _lifeText.text = ":(";
            }
            else if(health == 0f)
            {
                // ...
            }else
                _lifeText.text = System.Math.Floor(health).ToString();
                
        }
    }

}
