using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBallScript : MonoBehaviour
{
    public float _speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f))*_speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
