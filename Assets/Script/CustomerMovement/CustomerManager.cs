using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public List<GameObject> Sofas;
    
    public List<GameObject> Customers;
    public List<GameObject> SofaCustomers;

    public GameObject Entrance;
    void Start()
    {
        StartCoroutine(CUSTOMERSMOVEMENT());
    }
    public IEnumerator CUSTOMERSMOVEMENT()
    {
        while(true )
        {
            yield return new WaitForSeconds(5);
            for (int i = 1; i < Customers.Count; i++)
            {


                Customers[i].GetComponent<Customer>().GotoPosition(Customers[i - 1].transform);
            }
            if (SofaCustomers.Count !=0)
            {
                SofaCustomers[0].GetComponent<Customer>().GotoPosition(Entrance.transform);
                SofaCustomers.RemoveAt(0);
            }
            Customers[0].GetComponent<Customer>().GotoPosition(Sofas[SofaCustomers.Count].transform);

            Customers[0].GetComponent<Customer>().IsSofaSit = true;

            SofaCustomers.Add(Customers[0]);
            Customers.RemoveAt(0);
          
        }
       
       
    }
    public void MakeCustomersAfraid()
    {
        Customer[] CUS = FindObjectsOfType<Customer>();
        for (int i = 0; i < CUS.Length; i++)
        {
            CUS[i].AFRAID();
        }
        StopAllCoroutines();
    }
    public void AddCustomerAgain(GameObject C)
    {
        Customers.Add(C);
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
