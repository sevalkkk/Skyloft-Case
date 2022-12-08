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
  
    [SerializeField] private GameObject GameStartPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject NextLevelPanel;
    [SerializeField] private GameObject LevelsPanel;
    public bool isRestartLevel;
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

       /* if (isNextLevel)
        {

            NextLevelPanel.SetActive(true);
           
           

        }*/

    }



   public void EndGame(bool status)
    {
        EndGameEvent.Invoke(true);
        NextLevelPanel.SetActive(true);
    }


}
    
