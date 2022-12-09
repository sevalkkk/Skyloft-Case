using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    int levelCount = 0;
    public static LevelManager instance;
    private Camera cam;
   
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        cam = Camera.main;
    }

 
    public void OnEnable()
    {
        GameManager.instance.EndGameEvent.AddListener(HandleEndGameEvent);
    }

    public void OnDisable()
    {
        GameManager.instance.EndGameEvent.RemoveListener(HandleEndGameEvent);
    }

    private void HandleEndGameEvent(bool status)
    {
        levelCount++;
        levels[levelCount - 1].SetActive(false);

    }

    public void LoadNextLevel()
    {
  
        if (levelCount < levels.Length)
        {
            levels[levelCount].SetActive(true);          
            GameManager.instance.isNewLevel = true;
            cam.transform.DOMoveY(cam.transform.position.y-50, 1.5f);
            GameManager.instance.confetti.transform.DOMoveY(GameManager.instance.confetti.transform.position.y - 50, 1.5f);
        }
    }

    

}
