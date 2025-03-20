using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCreatorCode : MonoBehaviour
{
    /*public variables*/
    public GameObject loc;
    public GameObject[] spherePrefab;
    public GameObject Image;

    /*private variables*/
    private Transform locT;
    private int seconds;
    private float timer;
    private float randomForceMin = -100.0f;
    private float randomForceMax =  100.0f;
    private loadingbar _lB;

    private int spawnCount = 1;

    void Awake()
    {
        locT = loc.GetComponent<Transform>();
        _lB = Image.GetComponent<loadingbar>();

    }

    void Update()
    {
        if (_lB.filled) BallSpawn();

        if (Input.GetMouseButtonDown(0)) BallSpawn();

    }

    void BallSpawn()
    {
        /*Random prefab*/
        int x = Random.Range(0, 299);
        /*Random x point*/
        float randX = Random.Range(-3f, 3f);
        /*Instantiate ball*/
        for(int i = 0; i < spawnCount; i++)
        {
            GameObject obj = Instantiate(spherePrefab[x / 100], new Vector3(randX, locT.position.y, locT.position.z), Quaternion.identity);
            /*Spawn with force to random direction*/
            Vector3 force = new Vector3(Random.Range(randomForceMin, randomForceMax), Random.Range(randomForceMin, randomForceMax), Random.Range(randomForceMin, randomForceMax));
            obj.GetComponent<Rigidbody>().AddForce(force);
        }
        
    }

    public void UpgradeSpawnCount()
    {
        spawnCount += 1;
    }

}
