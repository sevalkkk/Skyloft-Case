using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    public int levelCount; 
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


    private void Start()
    {
        if (!PlayerPrefs.HasKey("level_count"))
        {
            PlayerPrefs.SetInt("level_count", 0);
        }

        levelCount = PlayerPrefs.GetInt("level_count");
        levels[levelCount].SetActive(true);
        print("baslangicta" + PlayerPrefs.GetInt("level_count"));
        float camPosY = cam.transform.position.y;
        camPosY = cam.transform.position.y + levels[levelCount].transform.position.y;
        cam.transform.position = new Vector3(cam.transform.position.x, camPosY, cam.transform.position.z);
        GameManager.instance.confetti.transform.position = new Vector3(0, camPosY, 0);
        // LoadLevelCount();
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
            PlayerPrefs.SetInt("level_count", levelCount);
            print("arttýrdýktan sonra" + PlayerPrefs.GetInt("level_count"));
            levels[levelCount].SetActive(true);
            print("aaaaaaaaaaaaaaaaa");

            cam.transform.DOMoveY(levels[levelCount].transform.position.y, 1.5f);


            
            
            Debug.Log(GameManager.instance.confetti.transform.position);
          
            StartCoroutine(asy());
            
            



        }

    }

    IEnumerator asy()
    {
        yield return new WaitForSeconds(1f); 
        GameManager.instance.isNewLevel = true;
    }

  

   
}
