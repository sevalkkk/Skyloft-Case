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

        //if there is any value for level_count, set this value zero.
        if (!PlayerPrefs.HasKey("level_count"))
        {
            PlayerPrefs.SetInt("level_count", 0);
        }


        //keep last level in levelCount variable.
        levelCount = PlayerPrefs.GetInt("level_count");
        //play last level.
        levels[levelCount].SetActive(true);
       //set y position of camera to camPosY variable.
        float camPosY = cam.transform.position.y;

        //y position of camera always has to be last level position.
        camPosY =  levels[levelCount].transform.position.y;
        cam.transform.position = new Vector3(cam.transform.position.x, camPosY, cam.transform.position.z);
       
       
    }
    
    public void OnEnable()
    {
        //add listener to EndGameEvent.
        GameManager.instance.EndGameEvent.AddListener(HandleEndGameEvent);
        
    }

    public void OnDisable()
    {

        //remove listener from EndGameEvent.
        GameManager.instance.EndGameEvent.RemoveListener(HandleEndGameEvent);
      

    }

    private void HandleEndGameEvent(bool status)
    {
        //increase level count.
        levelCount++;
        //deactivate last level.
        levels[levelCount - 1].SetActive(false);
        DeactivateAllBalls();



    }


    public void LoadNextLevel()
    {

        if(levelCount == levels.Length)
        {
            GameManager.instance.winText.SetActive(true);
        }
        //if levelcount not bigger than length of levels.
        if (levelCount < levels.Length)
        {

            //set level_count to our new levelCount .(because we increased the levelCount variable)
            PlayerPrefs.SetInt("level_count", levelCount);
            //activate new level.
            levels[levelCount].SetActive(true);
            //move camera to new level position.
            cam.transform.DOMoveY(levels[levelCount].transform.position.y, 1.5f);
            StartCoroutine(WaitAndLoadNewLevel());
        }

    }

    IEnumerator WaitAndLoadNewLevel()
    {
        yield return new WaitForSeconds(1f); 
        GameManager.instance.isNewLevel = true;
    }


    public void DeactivateAllBalls()
    {

        //find all colored balls in scene and deactivate them.
         GameObject[] _coloredballs = GameObject.FindGameObjectsWithTag("colored");
        
         foreach (GameObject ball in _coloredballs) {
            ball.SetActive(false);
             
         }


        //find all uncolored balls in scene and deactivate them.
        GameObject[] _uncoloredballs = GameObject.FindGameObjectsWithTag("uncolored");

        foreach (GameObject ball in _uncoloredballs)
        {
            ball.SetActive(false);

        }




    }



}
