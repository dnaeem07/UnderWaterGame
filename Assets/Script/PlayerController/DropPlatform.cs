using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : MonoBehaviour
{
    public bool isDestroyedCalled = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && isDestroyedCalled == false)
        {
            isDestroyedCalled = true;
            Destroy(this.gameObject, 3f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isDestroyedCalled == false)
        {
            isDestroyedCalled = true;
            Destroy(this.gameObject, 3f);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player" && isDestroyedCalled == false)
        {
            isDestroyedCalled = true;
            Destroy(this.gameObject, 3f);
        }
    }
}
