using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCode : MonoBehaviour
{
    private GameDatabase data;
    [SerializeField]
    private float _power;

    // Start is called before the first frame update
    //comment
    public float Power { get { return _power; } }

    private void Awake()
    {
        data = GameObject.FindGameObjectWithTag("Database").GetComponent<GameDatabase>();
    }
    void Start()
    {
        _power = data.GetBallPower();
    }

    public void UpdateYourself(GameDatabase database)
    { 
        Debug.Log(database.GetBallPower());
        //databasele haberleş
        this._power = database.GetBallPower();

    }
}
