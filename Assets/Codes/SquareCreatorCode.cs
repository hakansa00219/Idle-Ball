using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpawnType
{
    SPAWN_ALL = 0,
    SPAWN_RANDOM_ONE,
    NUM_OF_SPAWN_TYPES
}

enum Levels
{
    LEVEL_ONE = 1,
    LEVEL_TWO,
    LEVEL_THREE,
    LEVEL_FOUR,
    LEVEL_FIVE,
    LEVEL_SIX,
    LEVEL_SEVEN,
    LEVEL_EIGHT,
    LEVEL_NINE,
    LEVEL_TEN,
    NUM_OF_LEVELS
}

enum BlockType
{
    TRIANGLE_TYPE = 0,
    SQUARE_TYPE,
    NUM_OF_TYPES
}

public class SquareCreatorCode : MonoBehaviour
{
    /*Public variables*/
    public GameObject squareSpawnPoint;
    public GameObject[] trianglesPrefab;
    public GameObject[] squarePrefab;
    private Levels currentPlayerLevel; //TODO: globalden alinacak.
    /*Private variables*/
    private GameDatabase data;
    private Transform locT;
    private float levelYOffset = -64.7f;
    private float[] xArr = { -4.5f, -3f, -1.5f, 0 , 1.5f, 3f, 4.5f };
    private float[] yArr = { 4, 2.5f, 1, -0.5f, -2 };
                              
    public List<int> blockList;
    public int findProtectionCount = 10;

    private bool spawnCoroutineActive;
    private IEnumerator spawnCoroutine;

    private void Awake()
    {
        locT = squareSpawnPoint.GetComponent<Transform>();
        data = GameObject.FindGameObjectWithTag("Database").GetComponent<GameDatabase>();
    }
    void Start()
    {
        blockList = new List<int>();
        currentPlayerLevel = (Levels) data.GetCurrentLevel();
        spawnCoroutineActive = false;
        spawnCoroutine = SpawnNewSquare();

        for(Levels l = Levels.LEVEL_ONE; l <= currentPlayerLevel; ++l)
        SpawnBlock(SpawnType.SPAWN_ALL, l);

    }

    void Update()
    {
        /*Hysterisys between 10-20*/
        if (!spawnCoroutineActive)
        {
            if (SquareContainerCode.squareCnt < 10)
            {
                StartCoroutine(spawnCoroutine);
                spawnCoroutineActive = true;
            }
        }
        else
        {
            if (SquareContainerCode.squareCnt > 20)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutineActive = false;
            }
        }
    }

    IEnumerator SpawnNewSquare()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            /*Spawn on random point*/
            SpawnBlock(SpawnType.SPAWN_RANDOM_ONE, (Levels)Random.Range((int)Levels.LEVEL_ONE, (int)currentPlayerLevel + 1)); // TODO: player currentlevel a kadar spawn etmeli.
        }
    }

    void SpawnBlock(SpawnType type, Levels level)
    {
        int squareColCnt = xArr.Length, squareRowCnt = yArr.Length, blockNumber/*[1-35] for Level 1*/;

        
        if (type == SpawnType.SPAWN_ALL)
        {
            for (int y = 0; y < squareRowCnt; ++y)
            {
                for (int x = 0; x < squareColCnt; ++x)
                {
                    
                    blockNumber = ((y * squareColCnt) + (x + 1)) + ((int)(level-1) * (squareColCnt * squareRowCnt) );
                     
                    blockList.Add(blockNumber);
                   
                   
                    InstantiateBlock(xArr[x], yArr[y] + (((float)level-1) * levelYOffset), locT.position.z, (BlockType)Random.Range(0, (int)BlockType.NUM_OF_TYPES), blockNumber);
                }
            }
        }else if(type == SpawnType.SPAWN_RANDOM_ONE)
        {
            int x = Random.Range(0, squareColCnt);
            int y = Random.Range(0, squareRowCnt);
            blockNumber = (y * squareColCnt) + (x + 1) + ((int)(level-1) * (squareColCnt * squareRowCnt));

            /*find non existing block number*/
            int infiniteLoopProtection = 0;
            while(blockList.Contains(blockNumber) && infiniteLoopProtection < findProtectionCount)
            {
                x = Random.Range(0, squareColCnt);
                y = Random.Range(0, squareRowCnt);
                blockNumber = (y * squareColCnt) + (x + 1) + ((int)(level-1) * (squareColCnt * squareRowCnt));
                infiniteLoopProtection++;
            }

            if (infiniteLoopProtection != findProtectionCount)
            {
                blockList.Add(blockNumber);
                InstantiateBlock(xArr[x], yArr[y] + (((float)level-1) * levelYOffset), locT.position.z, (BlockType)Random.Range(0, (int)BlockType.NUM_OF_TYPES), blockNumber);
            }
        }
    }

    void InstantiateBlock(float x, float y, float z, BlockType blocktype, int blockNum)
    {
        GameObject choosenPrefab = (blocktype == BlockType.TRIANGLE_TYPE) ? trianglesPrefab[Random.Range(0, 4)] : squarePrefab[Random.Range(0, 2)];

        GameObject block = Instantiate(choosenPrefab, new Vector3(x, y, z), choosenPrefab.transform.rotation);

        block.GetComponent<SquareCode>().selfNumber = blockNum;

        Debug.Log(blockNum + " spawned.");
    }

    public void IamDestroyed(int num)
    {
        blockList.Remove(num);
        Debug.Log(num + " is destroyed.");
    }
}   
