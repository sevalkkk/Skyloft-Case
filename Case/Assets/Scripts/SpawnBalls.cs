using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public float ballCount;
    [SerializeField] private float coloredBallCount;
    [SerializeField] private float uncoloredBallCount;
   
    [SerializeField] private Transform coloredBallPlace;
    [SerializeField] private Transform uncoloredBallPlace;
   
    [SerializeField] private GameObject BallPrefab;
    public static SpawnBalls instance;

    //public float BallCount { get => ballCount; set => ballCount = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        SpawnBall();
    }
   
    private void SpawnBall()
    {
        for (int i = 0; i < coloredBallCount; i++)
        {
            GameObject obj_color = Instantiate(BallPrefab, coloredBallPlace) as GameObject;
            obj_color.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            obj_color.transform.position = coloredBallPlace.position;
            obj_color.tag = "colored";

        }

        for (int i = 0; i < uncoloredBallCount; i++)
        {

            GameObject obj_uncolor = Instantiate(BallPrefab, uncoloredBallPlace) as GameObject;
            obj_uncolor.transform.position = uncoloredBallPlace.position;
            obj_uncolor.tag = "uncolored";
        }

        ballCount = coloredBallCount + uncoloredBallCount;




    }
}
