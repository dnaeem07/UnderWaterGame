using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
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
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        other.transform.SetParent(this.transform);
    //    }
    //}
    //private void OnTriggerExit(Collider collision)
    //{
    //    //if (collision.gameObject.tag == "Player")
    //    //{
    //    //    collision.transform.SetParent(null);
    //    //}
    //}
    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        other.transform.SetParent(this.transform);
    //    }
    //}
    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    collision.transform.SetParent(null);
        //}
    }
}
