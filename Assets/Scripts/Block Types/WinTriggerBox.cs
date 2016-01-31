using UnityEngine;
using System.Collections;

public class WinTriggerBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    //! Function to trigger the moveblocks
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameManager.Instance.CurrentGameState = GameManager.GameState.Win;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
