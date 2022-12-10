using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    
    public void TapToRestart()
    {
        SceneManager.LoadScene("MainScene");
      

    }

    public void RetryStage()
    {
        
    }

    public void SkipLevel()
    { 

    }

    public void TapToNextLevel()
    {
       
        LevelManager.instance.LoadNextLevel();
        SpawnBalls.instance.RunSpawningOnce();
      

    }
    
    public void TapToStartGame()
    {
        SpawnBalls.instance.RunSpawningOnce();
        GameManager.instance.isGameStart = true;
        print(GameManager.instance.isGameStart);
       
       
    }

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

  /*  public void GameMusic()
    {
        if (!SoundEfectManager.instance.isMusicOff)
        {
            SoundEfectManager.instance.sources[1].Pause();
            SoundEfectManager.instance.isSoundOff = true;
        }
        else
        {
            SoundEfectManager.instance.sources[1].UnPause();
            SoundEfectManager.instance.isMusicOff = false;
        }
    }*/
}
