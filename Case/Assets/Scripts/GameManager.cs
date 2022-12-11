using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;
    
    public bool isGameStart;
    public bool isNewLevel;
  
    public  GameObject GameStartPanel;
    public   GameObject GameOverPanel;
    [SerializeField] private  GameObject NextLevelPanel;
    [SerializeField] private  GameObject LevelsPanel;
   

    // [SerializeField] private  GameObject  WinPanel;

    public bool isRestartLevel;
    public GameObject confetti;
    [HideInInspector] public UnityEvent<bool> EndGameEvent = new UnityEvent<bool>();
    public GameObject winText;

    public TMP_Text PercentText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


        //set frameRate to 60 because it has to be run any kind of Android device.
        Application.targetFrameRate = 60;



        //!!! I know if i use Object Pool optimi 
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
    

        if(isNewLevel)
        {
            NextLevelPanel.SetActive(false);
            confetti.SetActive(false);
            isNewLevel = false;
        }

        if(isGameOver)
        {
            
            GameOverPanel.SetActive(true);
           
            isGameOver = false;
        }
    }

   

    public void EndGame(bool status)
    {

       
        EndGameEvent.Invoke(true);        
        NextLevelPanel.SetActive(true);
    }

 


}
    
