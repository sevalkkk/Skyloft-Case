using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HolderController : MonoBehaviour
{
    [SerializeField] private BallDetector ballDetector;
    private void OnEnable()
    {
        BallDetector.OnPercentAge += BallHolderMoves; 
    }

    private void OnDisable()
    {
        BallDetector.OnPercentAge -= BallHolderMoves;
    }


    private void BallHolderMoves()
    {
        float moveDuration = 0.15f;
        
        if (ballDetector.fillFraction <=1)
        {
            //if fill fraction smaller than 1 or equals to 1 , move ball holder smoothly with Dotween.
            transform.DOMoveY(transform.position.y - 0.08f, moveDuration * ballDetector.fillFraction);
            
        }

       
        
      
    }

  
}
