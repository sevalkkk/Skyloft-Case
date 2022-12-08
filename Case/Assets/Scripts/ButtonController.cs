using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
   public void TapToRestart()
    {
        print("tap to restart");
    }

    public void RetryStage()
    {
        print("Retry stage");
    }

    public void SkipLevel()
    {
        print("Skip Level");
    }

    public void TapToNextLevel()
    {
        print("next level");
        LevelManager.instance.LoadNextLevel();
        SpawnBalls.instance.RunSpawningOnce();


    }
    
    public void TapToStartGame()
    {
        print("start game");
        SpawnBalls.instance.RunSpawningOnce();
        GameManager.instance.isGameStart = true;
       
       
    }
}
