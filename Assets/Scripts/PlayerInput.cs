using UnityEngine;
using System.Collections;
using InControl;

public class PlayerInput : MonoBehaviour {

    public float speed = 20.0f;
    public float jumpSpeed = 8.0F;
    private Vector3 xForceToAdd = Vector3.zero;
    private float xPos = 0;
    private enum Control_Type { keyboard, gamepad, touch}
    [SerializeField]
    private Control_Type ControlType = Control_Type.keyboard;
    private Rigidbody PlayerRigidBody;
    private bool jumpEnabled = false;
    public float maxXVelocity = 1000f;

    // Use this for initialization
    void Start () {
        PlayerRigidBody = GameManager.Instance.ThePlayer.GetComponent<Rigidbody>();
	}

    // Function to listen for input
    private void AcceptInput()
    {
        switch (ControlType)
        {
            case Control_Type.keyboard:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    xPos = -1f;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    xPos = 1f;
                }
                else xPos = 0f;
                // Send horizontal movement
                PlayerHorizontalMovement(xPos);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PlayerJumpMovement(jumpSpeed);
                }
                break;
            case Control_Type.gamepad:
                // Use last device which provided input.
                var inputDevice = InputManager.ActiveDevice;
                xPos = inputDevice.LeftStickX;
                // Send horizontal movement
                PlayerHorizontalMovement(xPos);
                // Check that player is on the ground
                if (inputDevice.Action1.WasPressed)
                {
                    // Send jump movement
                    PlayerJumpMovement(jumpSpeed);
                }
                break;
            case Control_Type.touch:
                // INSERT TOUCH CONTROLS HERE
                break;
        }
    }

    //! Function to control horizontal velocity
    private void PlayerHorizontalMovement(float force)
    {
        xForceToAdd = new Vector3(force * speed, 0, 0);
        PlayerRigidBody.AddForce(xForceToAdd);
    }

    //! Function to control jump movement
    private void PlayerJumpMovement(float jumpPower)
    {
        // Check that player is on the ground
        if (GameManager.Instance.ThePlayer.GetComponent<PlayerProperties>().CheckGroundDist())
        {
            Vector3 jumpForce = new Vector3(0, jumpPower, 0);
            PlayerRigidBody.AddForce(jumpForce);
        }
    }
    
	
	// Update is called once per frame
	void Update () {

        // Call function to accept input
        AcceptInput();

    }
}
