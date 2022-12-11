using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject Explosion;
    Vector3 bombPosition;
    Mesh[] meshes;
    bool gameEnd;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="colored" || collision.gameObject.tag=="uncolored")
        {
            gameEnd = true;
            ExplosionMethod();

        }

        if (collision.gameObject.tag == "bomb")
        {
            
            ExplosionMethod();
        } 

    }

   private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="ballDetector")
        {
            gameEnd = true;
            ExplosionMethod();
        }
    }

    void ExplosionMethod()
    {
        bombPosition = transform.position;
        int childCount = gameObject.transform.childCount;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        for (int i = 0; i < childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<MeshFilter>().mesh = null;
        }
        Explosion.SetActive(true);

        Explosion.transform.position = bombPosition + new Vector3(1.9f, 0, 0);
        StartCoroutine(WaitAndDeactivateBomb(1.7f));

    }


    private IEnumerator WaitAndDeactivateBomb(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        Explosion.SetActive(false);
        gameObject.SetActive(false);
        if(gameEnd)
        {
            GameManager.instance.isGameOver = true;
            gameEnd = false;
        }
       
       
    }

    
}
