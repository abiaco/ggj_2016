using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

    public enum MoveType { None, Left, Right, Up, Down, LeftAndRight, RightAndLeft, UpAndDown, DownAndUp }
    public MoveType MovementType = MoveType.None;
    [SerializeField]
    private float moveDistance, moveDelay, moveSpeed;
    private bool triggered = false;
    public Vector3 position1, position2;

	// Use this for initialization
	void Start () {
	
	}

    //! Function to start block movement
    public void StartBlockMovement()
    {
        // Determine end point
        Vector3 EndPoint = this.transform.position + new Vector3(moveDistance, moveDistance, moveDistance);
        StartCoroutine(PerformMove());

    }

    //! Function to perform the move
    private IEnumerator PerformMove()
    {
        // Starting delay
        yield return new WaitForSeconds(moveDelay);

        // Set position 1
        position1 = transform.position;
        // Switch case for directional movement
        switch (MovementType)
        {
            case MoveType.None:
                break;
            case MoveType.Left:
                // Set position2 for left
                position2 = transform.position + new Vector3(-moveDistance, 0, 0);
                break;
            case MoveType.Right:
                // Set position2 for right
                position2 = transform.position + new Vector3(moveDistance, 0, 0);
                break;
            case MoveType.Up:
                // Set position2 for up
                position2 = transform.position + new Vector3(0, moveDistance, 0);
                break;
            case MoveType.Down:
                // Set position2 for down
                position2 = transform.position + new Vector3(0, -moveDistance, 0);
                break;
            case MoveType.LeftAndRight:
                break;
            case MoveType.RightAndLeft:
                break;
            case MoveType.UpAndDown:
                break;
            case MoveType.DownAndUp:
                break;
        }
        // Trigger the movement to start
        triggered = true;
    }

    // Fixed Update
    void FixedUpdate()
    {
        if (triggered)
        {
            // Perform move
            transform.position = Vector3.Lerp(transform.position, position2, Time.deltaTime * moveSpeed);
        }
    }
}
