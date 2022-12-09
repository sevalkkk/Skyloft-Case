using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    [SerializeField] private Transform coloredBallTransform;
    [SerializeField] private Transform uncoloredBallTransform;
    [SerializeField] private float coloredBallCount;
    [SerializeField] private float uncoloredBallCount;
 


  

    private void Update()
    {
        SetNewLevelAssets();
    }


    private void SetNewLevelAssets()
    {
       
      
            SpawnBalls.instance.coloredBallPlace.position = coloredBallTransform.position;
            SpawnBalls.instance.uncoloredBallPlace.position = uncoloredBallTransform.position;
            SpawnBalls.instance.coloredBallCount = coloredBallCount;
            SpawnBalls.instance.uncoloredBallCount = uncoloredBallCount;
            SpawnBalls.instance.ballCount = coloredBallCount + uncoloredBallCount;
      
     
    }

 
}
