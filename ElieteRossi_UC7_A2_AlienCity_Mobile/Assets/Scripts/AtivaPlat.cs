using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaPlat : MonoBehaviour {
    
    public GameObject p1;
    public GameObject p2;

    // Use this for initialization
    void Start()
    {

    } 	
	// Update is called once per frame
	void Update () {
      		
	}

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            p1.gameObject.GetComponent<Animation>().Play();
            p2.gameObject.GetComponent<Animation>().Play();

        }
    }
}
