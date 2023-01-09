using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bubble : MonoBehaviour
{
    public Vector3 StartPosition;
    public float speed = 2f;
    public Vector3 EndPosition;
    public bool hasplayedentered = false;
    public GameObject Player;

    public Text Obj;
    void Start()
    {
        Obj.text = "Jump Into Bubble to escape";
    }
    private void Awake()
    {
        StartPosition = this.transform.position;
        EndPosition = this.transform.position + new Vector3(0, 8f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, speed*Time.deltaTime, 0);
        if(Vector3.Distance(this.transform.position,EndPosition)<0.1f && hasplayedentered==false)
        {
            this.transform.position = StartPosition;
        }
        if(hasplayedentered)
        {
            Player.transform.position+= new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            speed += 5;
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            hasplayedentered = true;
            Manager.instance.DelayComplete(4);
        }
    }
}
