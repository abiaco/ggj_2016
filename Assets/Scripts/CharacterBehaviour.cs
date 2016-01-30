using UnityEngine;
using System.Collections;

public class CharacterBehaviour : MonoBehaviour {
    public float speed = 20.0f;
    public float jumpSpeed = 8.0F;
    public float gravity = 0.003f;
    private float movex = 0f;
    private float movey = 0f;
    float zMove = 0f;
    private Vector3 move = Vector3.zero;

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

        move = new Vector3(movex * speed, 0, zMove);
        move.z -= gravity * Time.deltaTime;

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(movex * speed, 0, zMove);
    }
}
