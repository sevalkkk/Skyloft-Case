using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    int levelCount = 0;
    public static LevelManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        GameManager.instance.EndGameEvent.AddListener(HandleEndGameEvent);
    }

    private void OnDisable()
    {
        GameManager.instance.EndGameEvent.RemoveListener(HandleEndGameEvent);
    }

    private void HandleEndGameEvent(bool status)
    {
        levelCount++;

    }

    public void LoadNextLevel()
    {
        levels[levelCount-1].SetActive(false);
      
        if (levelCount < levels.Length)
        {
            levels[levelCount].SetActive(true);
        }
    }

    

}
