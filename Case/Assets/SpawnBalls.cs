using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    
    [SerializeField] private float ball_count;
    [SerializeField] private Transform ball_place_for_colors;
    [SerializeField] private Transform ball_place_for_uncolors;
   
    [SerializeField] private GameObject ball_prefab;

    public float BallCount { get => ball_count; set => ball_count = value; }
  
    
    void Start()
    {
        //can be in awake??? learn that
        SpawnBall();
    }

  

    private void SpawnBall()
    {
        for (int i = 0; i < ball_count; i++)
        {
            GameObject obj_color = Instantiate(ball_prefab, ball_place_for_colors) as GameObject;
            obj_color.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            obj_color.transform.position = ball_place_for_colors.position;
            obj_color.tag = "color";

            GameObject obj_uncolor = Instantiate(ball_prefab, ball_place_for_uncolors) as GameObject;
            obj_uncolor.transform.position = ball_place_for_uncolors.position;
            obj_uncolor.tag = "uncolor";
        }


      
       
    }
}
