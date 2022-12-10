using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PencilRaycastController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float movingSpeed;
    

    private void Awake()
    {
        cam = Camera.main;   
    }

   

    public void PencilClicked()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            GameObject obj = hit.collider.gameObject;
            if (hit.collider != null )
            {
                float moveDuration = 2;
                
                obj.transform.DOMoveX(obj.transform.up.y + 100, moveDuration);
            }
        }
    }

    

}
