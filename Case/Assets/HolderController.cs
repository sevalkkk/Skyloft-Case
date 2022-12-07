using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HolderController : MonoBehaviour
{
    [SerializeField] private BallDetector ballDetector;
  


   

    private void Update()
    {
        if(ballDetector.fillFraction > 0.1f )
        {
             BallHolderMoves();
        }
       
    }

    private void BallHolderMoves()
    {
        float moveDuration = 0.1f;
        if(ballDetector.fillFraction * 100 !=100)
        {
            transform.DOMoveY(transform.position.y - 0.01f, moveDuration * ballDetector.fillFraction);
        }
      
    }

  
}
