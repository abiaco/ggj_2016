using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour
{
    private Vector3 startingPostion;
    private float groundDistThreshold = 1.15f, startingHealth;

    [SerializeField]
    // Player Health
    private float playerHealth = 100;
    public float PlayerHealth
    {
        get { return this.playerHealth; }
        set { this.playerHealth = value; }
    }

    //! Function to lose health
    public void LoseHealth(float damage)
    {
        // Lose health
        PlayerHealth -= damage;
        // Check player's health
        CheckHealth();
    }

    //! Function to check player's health for death
    public void CheckHealth()
    {
        if (playerHealth <= 0f)
        {
            // Set the game state to dead
            GameManager.Instance.CurrentGameState = GameManager.GameState.Dead;
        }
    }

    // Use this for initialization
    void Start()
    {
        // Record starting position
        startingPostion = transform.position;
        // Record starting health
        startingHealth = playerHealth;
    }

    //! Function to check distance to ground
    public bool CheckGroundDist()
    {
        // Fire a ray downwards to detect how close the ground is
        float distanceToGround = 1000000;
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            distanceToGround = hit.distance;
        }
        // If the distance is below the threshold then return true
        if (distanceToGround < groundDistThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //! Function to check distance to ground
    public bool DetectWallLeft(bool directionLeft)
    {
        // Fire a ray downwards to detect how close the ground is
        float distanceToWall = 1000000;
        Vector3 directionVector;
        if (directionLeft == true)
        {
            directionVector = Vector3.right;
        }
        else
        {
            directionVector = Vector3.left;
        }
        RaycastHit hit = new RaycastHit();
        Vector3 rayLoc = new Vector3(transform.position.x, transform.position.y + Random.Range(-1f, 1f), transform.position.z);
        if (Physics.Raycast(rayLoc, -directionVector, out hit))
        {
            distanceToWall = hit.distance;
        }
        // If the distance is below the threshold then return true
        if (distanceToWall < 0.75f && hit.collider.tag == "Environment")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //! Function to reset player's position
    public void ResetPlayer()
    {
        PlayerHealth = startingHealth;
        transform.position = startingPostion;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
