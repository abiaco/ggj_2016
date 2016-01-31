using UnityEngine;
using System.Collections;

public class AnimalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.tag == "Player")
        {
            Controller.disableMove();
            Debug.Log("disable move");
            Destroy(gameObject);
        }
    }
}
