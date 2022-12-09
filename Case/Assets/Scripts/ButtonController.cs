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
}
