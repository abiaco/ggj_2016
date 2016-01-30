using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour {
    public float speed = 5.0f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private float movex = 0f;
    private float movey = 0f;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movex = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movex = 1;
        }
        else movex = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movey = 1;
        }
        else movey = 0;
    }

    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * speed, movey * speed);
    }
}
