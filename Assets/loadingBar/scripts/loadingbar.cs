using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;

    private float speed = 0.01f;

    public bool filled = false;
    private bool spawnerUpgraded = false;

    // Use this for initialization
    void Start ()
    {

        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
    }

    void Update()
    {
        if(!spawnerUpgraded)
        {
            if (imageComp.fillAmount != 1f)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("Space Pressed.");
                    imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed ;
                }              
                filled = false;
            }
            else
            {
                imageComp.fillAmount = 0.0f;
                filled = true;
            }
        }
        else
        {
            if (imageComp.fillAmount != 1f)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("Space Pressed.");
                    imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed * 2;
                }
                else
                {
                    imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
                }
                filled = false;
            }
            else
            {
                imageComp.fillAmount = 0.0f;
                filled = true;
            }
        }
        

    }

    public void ChangeSpawnRate(float spawnRate)
    {
        speed = spawnRate;
    }
    public void UpgradeSpawnRate()
    {
        if (spawnerUpgraded == true)
        {
            speed += 0.01f;
        }
            spawnerUpgraded = true;       
    }
}
