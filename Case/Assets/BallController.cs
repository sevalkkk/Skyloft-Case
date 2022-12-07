using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public static BallController instance;
   // [SerializeField] private SpawnBalls spawnBalls;
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody>();


    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "uncolor" && collision.gameObject.tag == "color")
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            gameObject.tag = "color";
        }
        

        if (collision.gameObject.tag == "uncolor" || collision.gameObject.tag == "color")
        {
            Vector3 m_NewForce = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0.0f);
            rb.AddForce(m_NewForce, ForceMode.Impulse);
        }
    }
}
