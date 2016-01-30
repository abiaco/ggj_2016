using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    // The Player
    private GameObject thePlayer;
    public GameObject ThePlayer
    {
        get { return this.thePlayer; }
        set { this.thePlayer = value; }
    }

    // Game State enum
    public enum GameState { Menu, Started, Paused, Dead }

    [SerializeField]
    // Game State
    private GameState currentGameState;
    public GameState CurrentGameState
    {
        get { return this.currentGameState; }
        set { this.currentGameState = value; }
    }
    #region Singleton Check
    private static GameManager gameManagerInstance = null;

    public static GameManager Instance
    {
        get { return gameManagerInstance; }
    }

    void Awake()
    {
        if (gameManagerInstance != null && gameManagerInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else {
            gameManagerInstance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        if (thePlayer == null)
        {
            ThePlayer = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private static bool applicationIsQuitting = false;
    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    #endregion



    // Use this for initialization
    void Start()
    {

    }

    //! Check game state
    private void CheckGameState()
    {
        switch (currentGameState)
        {
            case GameState.Menu:
                // MENU CODE HERE
                break;
            case GameState.Started:
                // GAME CODE HERE
                break;
            case GameState.Dead:
                print("Player is dead");
                // Activate menu
                currentGameState = GameState.Menu;
                break;
            case GameState.Paused:
                // GAME PAUSED CODE HERE
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check the game's state
        CheckGameState();

    }
}
