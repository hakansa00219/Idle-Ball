using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ball" )
        {
            GameObject explosionFX = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject, 0.01f);
            Destroy(explosionFX, 5f);
            //TODO: explosion effect or some sort. need after death effect.
        }
    }
}
