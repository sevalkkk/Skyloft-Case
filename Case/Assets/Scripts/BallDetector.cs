using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallDetector : MonoBehaviour
{
   
    float triggeredBallCount;
    [SerializeField] private TMP_Text PercentText;
    public float fillFraction;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "uncolored")
        {
                IEnumerator coroutine;
                coroutine = WaitAndGameOver(2f);
                StartCoroutine(coroutine);
            

        }
        if(other.gameObject.tag=="colored")
        {
            triggeredBallCount++;
           
            if(triggeredBallCount == SpawnBalls.instance.ballCount)
            {
                IEnumerator coroutine;
                coroutine = WaitAndNextLevel(2f);
                StartCoroutine(coroutine);
            }
        }


    }

    private void Update()
    {
        fillFraction = triggeredBallCount / SpawnBalls.instance.ballCount;
        PercentText.text = "%" + (Mathf.Min(100, fillFraction * 100)).ToString();
    }



    private IEnumerator WaitAndGameOver(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GameManager.instance.isGameOver = true;
        }
    }

    private IEnumerator WaitAndNextLevel(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GameManager.instance.isNextLevel = true;
        }
    }

   
}
