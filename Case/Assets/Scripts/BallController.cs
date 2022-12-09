using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public static BallController instance;
    
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody>();


    }

   

    private void OnCollisionStay(Collision collision)
    {
        if (gameObject.tag == "uncolored" && collision.gameObject.tag == "colored")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            gameObject.tag = "colored";
        }
        

        if (collision.gameObject.tag == "uncolored" || collision.gameObject.tag == "colored")
        {
            Vector3 m_NewForce = new Vector3(Random.Range(-0.2f, 0.2f), 0f, 0.0f);
            rb.AddForce(m_NewForce, ForceMode.Impulse);
        }
    }
}
