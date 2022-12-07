using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetector : MonoBehaviour
{
    private IEnumerator coroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "uncolor")
        {
           
            coroutine = WaitAndGameOver(1f);
            StartCoroutine(coroutine);

        }
    }



    private IEnumerator WaitAndGameOver(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("gameOver2");
        }
    }
}
