using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShark : MonoBehaviour
{
    int currentindex = 0;
    public Transform[] Positions;
    public float speed = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Positions.Length != 0 && Positions[currentindex] != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, Positions[currentindex].position, speed * Time.deltaTime);
            if (Vector3.Distance(this.transform.position, Positions[currentindex].position) < 0.1f)
            {
                currentindex++;
                if (currentindex == Positions.Length)
                    currentindex = 0;
            }
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag=="Player")
    //    {
    //        Manager.instance.DecrementHealth();
    //    }
    //}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Manager.instance.DecrementHealth();
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Manager.instance.DecrementHealth();
        }
    }
}
