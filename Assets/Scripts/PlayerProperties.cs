using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour
{

    private float groundDistThreshold = 0.75f;

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

    // Update is called once per frame
    void Update()
    {
    }
}
