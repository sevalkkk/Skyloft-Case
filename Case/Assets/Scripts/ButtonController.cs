using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    
    public void TapToRestart()
    {
        //load scene again.(everything will back to first version)
        SceneManager.LoadScene("MainScene");
      

    }

    public void RetryStage()
    {
        
    }

    public void SkipLevel()
    {

        //if i clicked the skip level button , show ads.
        AdsManager.instance.ShowRewardedAds();
     

    }

    public void TapToNextLevel()
    {
        //spawn ball.
        SpawnBalls.instance.RunSpawningOnce();
        LevelManager.instance.LoadNextLevel();
       
      

    }
    
    public void TapToStartGame()
    {
        SpawnBalls.instance.RunSpawningOnce();
        GameManager.instance.isGameStart = true;
        print(GameManager.instance.isGameStart);
       
       
    }


    //if i click the sound turn on/off button once, turn off the sound effects and if i click again turn on sound effects.
    public void SoundEffects()
    {
        if(!SoundEfectManager.instance.isSoundOff)
        {
            SoundEfectManager.instance.audioSource.Pause();
            SoundEfectManager.instance.isSoundOff = true;
        }
        else
        {
            SoundEfectManager.instance.audioSource.UnPause(); 
            SoundEfectManager.instance.isSoundOff = false;
        }

    }

 
}
