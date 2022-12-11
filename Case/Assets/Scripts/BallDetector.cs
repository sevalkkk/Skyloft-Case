using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;

public class BallDetector : MonoBehaviour
{
   
    float triggeredBallCount;
    
    public float fillFraction;
    public static event Action OnPercentAge;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "uncolored")
        {
            
            SetConfettiPosition();
            //play game over sound effect.
            SoundEfectManager.instance.PlayAudioClip(SoundEfectManager.instance.clips[2]);
            //run OnPercentAge event.
            OnPercentAge?.Invoke();
            IEnumerator coroutine;
            coroutine = WaitAndGameOver(2f);
            StartCoroutine(coroutine);
            

        }
        if(other.gameObject.tag=="colored")
        {
            //increase ball count which touches the ball detector.
            triggeredBallCount++;
            //set ball count which touches the ball detector/acount of all balls to fillFraction variable.
            fillFraction = triggeredBallCount / SpawnBalls.instance.ballCount;          
            fillFraction = Mathf.Min(1, fillFraction);

            //set text value to fillfraction*100.(for show under ballholder)
            GameManager.instance.PercentText.text = "%" + (fillFraction * 100).ToString("0.");
            OnPercentAge?.Invoke();
            if (triggeredBallCount == SpawnBalls.instance.ballCount)
            {
                //if all colorfull balls in touches the ballDetector, player will pass the level.
                SoundEfectManager.instance.PlayAudioClip(SoundEfectManager.instance.clips[1]);
               
                GameManager.instance.confetti.SetActive(true);
                SetConfettiPosition();

                IEnumerator coroutine;
                coroutine = WaitAndNextLevel(2f);
                StartCoroutine(coroutine);
            }
        }

        

    }


    private IEnumerator WaitAndGameOver(float waitTime)
    {
        while (true)
        {

            yield return new WaitForSeconds(waitTime);
            //set zero to fillFraction , because level ended. So new level has to begin with empty percent of balls which touch the ballDetector.
            ResetPercentOfBallsText();
            GameManager.instance.isGameOver = true;
            

        }
    }

    private IEnumerator WaitAndNextLevel(float waitTime)
    {
       

        while (true)
        {
            yield return new WaitForSeconds(waitTime);


            ResetPercentOfBallsText();
            GameManager.instance.EndGame(true);
            
         



        }
    }

    void SetConfettiPosition()
    {
        GameManager.instance.confetti.transform.position = new Vector3(0, (LevelManager.instance.levelCount * -50), 0);
    }

    void ResetPercentOfBallsText()
    {
        fillFraction = 0;
        GameManager.instance.PercentText.text = "";
    }
    

}
