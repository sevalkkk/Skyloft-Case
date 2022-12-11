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


        //!!! I know if I use Object Pooling , The optimization of the game could have been higher.
        //before i used Object pool just 2-3 times so  I didn't want to take the risk in 5 days.

    }

    public void RunSpawningOnce()
    {
        Invoke(nameof(SpawnBall), 0.1f);
    }

    public void SpawnBall()
    {
        
       
           
            for (int i = 0; i < coloredBallCount; i++)
            {

                //create colorfull ball according to the number we gave.
                GameObject obj_color = Instantiate(BallPrefab, coloredBallPlace) as GameObject;
                //set color of ball.
                obj_color.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                //set ball position to place we gave.
                obj_color.transform.position = coloredBallPlace.position;

                //set size of ball randomly.
                float random_size = Random.Range(0.5f, 0.7f);
                obj_color.transform.localScale = new Vector3(random_size, random_size, random_size);
                //set ball tag to "colored".
                obj_color.tag = "colored";
               

            }

            for (int i = 0; i < uncoloredBallCount; i++)
            {
                //create colorless ball according to the number we gave.
                GameObject obj_uncolor = Instantiate(BallPrefab, uncoloredBallPlace) as GameObject;
                //set ball position to place we gave.
                obj_uncolor.transform.position = uncoloredBallPlace.position;

                //set size of ball randomly.
                float random_size = Random.Range(0.5f, 0.7f);
                obj_uncolor.transform.localScale = new Vector3(random_size, random_size, random_size);
                //set ball tag to "uncolored".
                obj_uncolor.tag = "uncolored";
            }

            //set all balls count to ballCount variable.
            ballCount = coloredBallCount + uncoloredBallCount;


    }

   
}
