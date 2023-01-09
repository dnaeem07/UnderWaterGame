using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("DEATHTRIG");
            FindObjectOfType<PlayerController>().ResetPosition();
        }
    }
   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("DEATHTCOLL   ");
            FindObjectOfType<PlayerController>().ResetPosition();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Debug.Log("DEATHTCOLL   ");
            FindObjectOfType<PlayerController>().ResetPosition();
        }
    }
}
