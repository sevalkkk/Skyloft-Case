using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;

public class BallDetector : MonoBehaviour
{
   
    float triggeredBallCount;
    [SerializeField] private TMP_Text PercentText;
    public float fillFraction;
    public static event Action OnPercentAge;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "uncolored")
        {
            SoundEfectManager.instance.PlayAudioClip(SoundEfectManager.instance.clips[2]);
            OnPercentAge?.Invoke();
            IEnumerator coroutine;
            coroutine = WaitAndGameOver(2f);
            StartCoroutine(coroutine);
            

        }
        if(other.gameObject.tag=="colored")
        {
            triggeredBallCount++;
            fillFraction = triggeredBallCount / SpawnBalls.instance.ballCount;
          
            fillFraction = Mathf.Min(1, fillFraction);
            PercentText.text = "%" + (fillFraction * 100).ToString("0.");
            OnPercentAge?.Invoke();
            if (triggeredBallCount == SpawnBalls.instance.ballCount)
            {
                SoundEfectManager.instance.PlayAudioClip(SoundEfectManager.instance.clips[1]);
              
             //   GameManager.instance.confetti.SetActive(true);
               
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
            fillFraction = 0;
            PercentText.text = "";
            GameManager.instance.isGameOver = true;
            

        }
    }

    private IEnumerator WaitAndNextLevel(float waitTime)
    {
        GameManager.instance.confetti.SetActive(true);

        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            
            fillFraction = 0;
            PercentText.text = "";
            
            GameManager.instance.EndGame(true);
            
         



        }
    }

    

}
