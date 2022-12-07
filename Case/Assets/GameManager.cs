using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;
    public bool isNextLevel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject NextLevelPanel;
   

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(isGameOver)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            
        }

        if(isNextLevel)
        {
            Time.timeScale = 0;
            NextLevelPanel.SetActive(true);
        }
    }
}
