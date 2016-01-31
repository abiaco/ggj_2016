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
    public Controller controller;
    Action action;
    // Use this for initialization
    void Start () {
        controller = new Controller();
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
                    Debug.Log("left move");
                    controller.action.setType(ActionType.moveLeft);
                    if (GameManager.Instance.ThePlayer.GetComponent<PlayerProperties>().DetectWallLeft(false))
                    {
                        xPos = Mathf.Clamp(xPos, -1f, 0f);
                    }
                    // Check that player is not against a wall to the left
                    if (GameManager.Instance.ThePlayer.GetComponent<PlayerProperties>().DetectWallLeft(true))
                    {
                        xPos = Mathf.Clamp(xPos, 0f, 1f);
                    }
                    xForceToAdd = new Vector3(xPos * speed, 0, 0);
                    controller.action.setForce(xForceToAdd);


                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    xPos = 1f;
                    Debug.Log("right move");

                    controller.action.setType(ActionType.moveRight);
                    if (GameManager.Instance.ThePlayer.GetComponent<PlayerProperties>().DetectWallLeft(false))
                    {
                        xPos = Mathf.Clamp(xPos, -1f, 0f);
                    }
                    // Check that player is not against a wall to the left
                    if (GameManager.Instance.ThePlayer.GetComponent<PlayerProperties>().DetectWallLeft(true))
                    {
                        xPos = Mathf.Clamp(xPos, 0f, 1f);
                    }
                    xForceToAdd = new Vector3(xPos * speed, 0, 0);
                    controller.action.setForce(xForceToAdd);
                }
                else xPos = 0f;
                // Send horizontal movement
              //  PlayerHorizontalMovement(xPos);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("jump");

                    controller.action.setType(ActionType.jump);
                    controller.action.setForce(new Vector3(0, jumpSpeed, 0));
                   // PlayerJumpMovement(jumpSpeed);
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    Debug.Log("save");
                    controller.action.setType(ActionType.save);
                    controller.action.setForce(Vector3.zero);
                   // GameManager.Instance.deathGod.pissOff();
                }

                if (Input.GetKeyDown(KeyCode.K))
                {
                    Debug.Log("sacrifice");
                    controller.action.setType(ActionType.sacrifice);
                    controller.action.setForce(Vector3.zero);
                   // GameManager.Instance.natureGod.pissOff();
                }
                break;
            case Control_Type.gamepad:
                // Use last device which provided input.
                var inputDevice = InputManager.ActiveDevice;
                xPos = inputDevice.LeftStickX;
                controller.action.setType(xPos > 0 ? ActionType.moveRight : ActionType.moveLeft);
                controller.action.setForce(new Vector3(xPos * speed, 0, 0));
                // Send horizontal movement
              //  PlayerHorizontalMovement(xPos);
                // Check that player is on the ground
                if (inputDevice.Action1.WasPressed)
                {
                    // Send jump movement
                    controller.action.setType(ActionType.jump);
                    controller.action.setForce(new Vector3(0, jumpSpeed, 0));
                   // PlayerJumpMovement(jumpSpeed);
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
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.Started)
        {
            // Call function to accept input
            AcceptInput();
            controller.ApplyAction(PlayerRigidBody);

            controller.action = new Action();
        }
        else
        {
            if (Input.anyKeyDown)
            {
                GameManager.Instance.CurrentGameState = GameManager.GameState.Started;
            }
        }
        
    }

}
