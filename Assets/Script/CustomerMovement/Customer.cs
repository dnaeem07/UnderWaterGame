using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Customer : MonoBehaviour
{
    public NavMeshAgent nav;
    public GameObject Target;
    private Animator anim;
    public bool IsSofaSit;
    private bool isstarted = false;
    // Start is calle
    // d before the first frame update
    void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
    }

    public void GotoPosition(Transform pos)
    {

        Target = new GameObject();
        Destroy(Target, 5f);
        Target.transform.position = pos.position;
        Target.transform.rotation = pos.rotation;
        Target.transform.localScale = pos.localScale;
        isstarted = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Entrance")
        {
            FindObjectOfType<CustomerManager>().AddCustomerAgain(this.gameObject);
        }
    }
    public void RotateTowardsTarget()
    {
        Vector3 targetDirection = Target.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = 100f * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        //newDirection = new Vector3(transform.position.x, newDirection.y, transform.position.z);
        //newDirection = new Vector3(this.transform.position.x, newDirection.y, newDirection.z);
        transform.rotation = Quaternion.LookRotation(-newDirection);
        //  transform.LookAt((Target.transform));
    }
    // Update is called once per frame

    public void AFRAID()
    {
        isstarted = false;
        nav.speed = 0;
        anim.SetTrigger("Afaraid");
       
    }
    public void DIE()
    {
        isstarted = false;
        nav.speed = 0;
        anim.SetTrigger("Dead");
    }
    void Update()
    {
  
        if (isstarted==true && Target!=null)
        {
            float d = Vector3.Distance(Target.transform.position, transform.position);
  
            if (d > 2)
            {
                nav.speed = 5;
                nav.SetDestination(Target.transform.position);
                anim.SetBool("isWalking", true);
                anim.SetBool("isSofaSit", false);
                //if (IsSofaSit==false)
                //    anim.SetBool("isWalking", true);
                //else
                //    anim.SetBool("isSofaSit", true);
            }
            else
            {
                isstarted = false;

                if(IsSofaSit)
                {
                    RotateTowardsTarget();
                }

                if (IsSofaSit == false)
                    anim.SetBool("isWalking", false);
                else
                    anim.SetBool("isSofaSit", true);
                IsSofaSit = false;
              
            }
         
        }
        
    }
}
