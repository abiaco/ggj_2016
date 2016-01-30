using UnityEngine;
using System.Collections;
using InControl;

public class PlayerInput : MonoBehaviour {

    public float speed = 20.0f;
    public float jumpSpeed = 8.0F;
    public float gravity = 0.003f;
    private float movex = 0f;
    private float movey = 0f;
    float zMove = 0f;
    private Vector3 xForceToAdd = Vector3.zero;

    private enum Control_Type { keyboard, gamepad, touch}
    [SerializeField]
    private Control_Type ControlType = Control_Type.keyboard;
    private Rigidbody PlayerRigidBody;

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
                // INSERT KEYBOARD CONTROLS HERE
                break;
            case Control_Type.gamepad:
                // Use last device which provided input.
                var inputDevice = InputManager.ActiveDevice;
                // Send horizontal movement
                PlayerHorizontalMovement(inputDevice.LeftStickX);
                // Send jump movement
                if (inputDevice.Action1.IsPressed)
                {
                    PlayerJumpMovement();
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
    private void PlayerJumpMovement()
    {
        Vector3 jumpForce = new Vector3(0, jumpSpeed, 0);
        PlayerRigidBody.AddForce(jumpForce);
    }
    
	
	// Update is called once per frame
	void Update () {

        // Call function to accept input
        AcceptInput();

    }
}
