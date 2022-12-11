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

        //if bomb touchs balls , game over.
        if(collision.gameObject.tag =="colored" || collision.gameObject.tag=="uncolored")
        {
          
            gameEnd = true;
            ExplosionMethod();

        }
        //if bomb touches another bomb , nothing happens.
        if (collision.gameObject.tag == "bomb")
        {
            
            ExplosionMethod();
        } 

    }

   private void OnTriggerExit(Collider other)
    {
        //if ball touches ball detector, game over.
        if(other.gameObject.tag=="ballDetector")
        {
            gameEnd = true;
            ExplosionMethod();
        }
    }

    void ExplosionMethod()
    {
       
        bombPosition = transform.position;
        //set bombs childs count to childCount variable.
        int childCount = gameObject.transform.childCount;
        //deactivate bomb collider. 
        gameObject.GetComponent<SphereCollider>().enabled = false;
        //deactivate all bomb childs mesh.(so it can be visible)
        for (int i = 0; i < childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<MeshFilter>().mesh = null;
        }
        //set explosion active.
        Explosion.SetActive(true);

        //set explosion position to bomb position.(so it can look like real.)
        Explosion.transform.position = bombPosition + new Vector3(1.9f, 0, 0);
        
        StartCoroutine(WaitAndDeactivateBomb(1.7f));

    }


    private IEnumerator WaitAndDeactivateBomb(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //deactivate explosion because it finished.
        Explosion.SetActive(false);
        gameObject.SetActive(false);
        //if there is a explosion and game is over.
        if(gameEnd)
        {

            SoundEfectManager.instance.PlayAudioClip(SoundEfectManager.instance.clips[2]);
            GameManager.instance.isGameOver = true;
            gameEnd = false;
        }
       
       
    }

    
}
