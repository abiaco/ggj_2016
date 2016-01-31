using UnityEngine;
using System.Collections;

public class TrapTriggerBox : MonoBehaviour {

    // Variable declarations
    public GameObject[] MoveBlocks;
    public int TriggerUses = 999;

	// Use this for initialization
	void Start () {
	    
	}

	//! Function to trigger the moveblocks
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && TriggerUses > 0)
        {
            // Decrement remaining trigger uses
            TriggerUses--;
            for (int i = 0; i < MoveBlocks.Length; i++)
            {
                MoveBlocks[i].GetComponent<MoveBlock>().StartBlockMovement();
            }
        }
    }

	// Update is called once per frame
	void Update () {
	    
	}
}
