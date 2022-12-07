using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PencilRaycastController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float movingSpeed;
  //private bool isClicked ;


   //public bool Clicked { get => isClicked; set => isClicked = value; }

    private void Start()
    {
        cam = Camera.main;
        
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit,Mathf.Infinity, layer) )
        {
            GameObject obj = hit.collider.gameObject;
            if(hit.collider!=null && Input.GetMouseButtonDown(0))
            {
                float moveDuration = 2;
                obj.transform.DOMoveX(obj.transform.position.y+20, moveDuration);
                // obj.transform.position =  Vector3.Lerp(obj.transform.position, obj.transform.position + new Vector3(25,0,0), movingSpeed * Time.time);
                print("a");
               
               
            }
        }
    }

}
