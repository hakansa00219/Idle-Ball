using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareContainerCode : MonoBehaviour
{

    public static int squareCnt = 0;

    private void Update()
    {
        squareCnt = transform.childCount;
    }
}
