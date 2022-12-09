using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;
    
    public bool isGameStart;
    public bool isNewLevel;
  
    [SerializeField] private  GameObject GameStartPanel;
    [SerializeField] private  GameObject GameOverPanel;
    [SerializeField] private  GameObject NextLevelPanel;
    [SerializeField] private  GameObject LevelsPanel;
   // [SerializeField] private  GameObject  WinPanel;

    public bool isRestartLevel;
    public GameObject confetti;
    [HideInInspector] public UnityEvent<bool> EndGameEvent = new UnityEvent<bool>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        PanelControl();
    }

    private void PanelControl()
    {
        if (isGameStart)
        {
           
            GameStartPanel.SetActive(false);
            LevelsPanel.SetActive(true);
        }
        if (isGameOver)
        {

            GameOverPanel.SetActive(true);
            

        }

        if(isNewLevel)
        {
            NextLevelPanel.SetActive(false);
            confetti.SetActive(false);
            isNewLevel = false;
        }

    }

   

    public void EndGame(bool status)
    {
        confetti.SetActive(true);
        EndGameEvent.Invoke(true);        
        NextLevelPanel.SetActive(true);
    }


}
    
