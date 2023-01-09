using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        //if (collision.gameObject.tag == "Death")
        //{
        //    Debug.Log(collision.gameObject.name);
        //  this.transform.position = StartPosition;
        //}

        if (collision.gameObject.tag == "Player")
        {
            Manager.instance.DecrementHealth();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Manager.instance.DecrementHealth();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
