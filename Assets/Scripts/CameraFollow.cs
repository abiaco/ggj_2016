using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private GameObject player;
    public float FollowSpeed;
    public bool FollowingPlayer = true;

	// Use this for initialization
	void Start () {
        // Locate and assign player
        player = GameManager.Instance.ThePlayer;
	}

    //! Function to follow the player
    private void FollowPlayer()
    {
        float newX = Mathf.Lerp(this.transform.position.x, player.transform.position.x, Time.deltaTime * FollowSpeed);
        float newY = Mathf.Lerp(this.transform.position.y, player.transform.position.y + 1.5f, Time.deltaTime * FollowSpeed);
        this.transform.position = new Vector3(newX, newY, this.transform.position.z);
        //print("following at: " + newX + " & " + newY);
    }
	
	// Update is called once per frame
	void Update () {
	    if (FollowingPlayer)
        {
            FollowPlayer();
        }
	}
}
