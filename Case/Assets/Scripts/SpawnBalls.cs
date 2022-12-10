using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public float ballCount;
    public float coloredBallCount;
    public float uncoloredBallCount;
   
    public Transform coloredBallPlace;
    public Transform uncoloredBallPlace;
   
    [SerializeField] private GameObject BallPrefab;
    public static SpawnBalls instance;
  
    //public float BallCount { get => ballCount; set => ballCount = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }

    public void RunSpawningOnce()
    {
        Invoke(nameof(SpawnBall), 0.1f);
    }

    public void SpawnBall()
    {
        
       
           
            for (int i = 0; i < coloredBallCount; i++)
            {
                GameObject obj_color = Instantiate(BallPrefab, coloredBallPlace) as GameObject;
                obj_color.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                obj_color.transform.position = coloredBallPlace.position;
                float random_size = Random.Range(0.5f, 0.7f);
                obj_color.transform.localScale = new Vector3(random_size, random_size, random_size);
                obj_color.tag = "colored";
               

            }

            for (int i = 0; i < uncoloredBallCount; i++)
            {

                GameObject obj_uncolor = Instantiate(BallPrefab, uncoloredBallPlace) as GameObject;
                obj_uncolor.transform.position = uncoloredBallPlace.position;
                float random_size = Random.Range(0.5f, 0.7f);
                obj_uncolor.transform.localScale = new Vector3(random_size, random_size, random_size);
                obj_uncolor.tag = "uncolored";
            }

            ballCount = coloredBallCount + uncoloredBallCount;


    }

   
}
