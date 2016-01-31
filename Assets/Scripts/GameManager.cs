using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public enum GameState { Menu, Started, Dead, Win }
    [SerializeField]
    // Game State
    private GameState currentGameState;
    public GameState CurrentGameState
    {
        get { return this.currentGameState; }
        set { this.currentGameState = value; }
    }

    // GUI Panels
    public GameObject Menu, InGame, LoseScreen, WinScreen;

    [SerializeField]
    private GameObject[] LevelPrefabs;
    public enum GameLevel { Level1, Level2, Level3 }
    public GameLevel CurrentLevel = GameLevel.Level1;

    private GameObject currentLevel;

    private bool gameRunning = false;

    public Material[] backgroundMaterials;

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
        CurrentLevel = GameLevel.Level1;
    }

    //! Function to spawn a level
    private void SpawnLevel(GameLevel newLevel)
    {

        // If there is currently a level in play then destroy it
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        // Instantiate the desired level prefab
        currentLevel = Instantiate(LevelPrefabs[(int)newLevel], transform.position, transform.rotation) as GameObject;
    }

    //! Start Level
    private void RestartPlay()
    {
        ThePlayer.GetComponent<PlayerProperties>().ResetPlayer();
        SpawnLevel(CurrentLevel);
       // ThePlayer.transform.FindChild ("Backdrop").GetComponent<MeshRenderer>().materials[0] = backgroundMaterials[(int)CurrentLevel];
    }

    //! Check game state
    private void CheckGameState()
    {
        switch (currentGameState)
        {
            case GameState.Menu:
                // Check that the menu is active
                if (!Menu.activeInHierarchy)
                {
                    Menu.gameObject.SetActive(true);
                    if (AudioManager.Instance.GetComponent<AudioSource>().clip != AudioManager.Instance.MusicFiles[0])
                    {
                        AudioManager.Instance.GetComponent<AudioSource>().clip = AudioManager.Instance.MusicFiles[0];
                        AudioManager.Instance.GetComponent<AudioSource>().volume = 0.5f;
                        AudioManager.Instance.GetComponent<AudioSource>().Play();
                    }
                }
                break;
            case GameState.Started:
                // Check that the menu is notactive
                if (Menu.activeInHierarchy)
                {
                    Menu.gameObject.SetActive(false);
                }
                // Check if the level and player should get reset
                if (!gameRunning)
                {
                    RestartPlay();
                    gameRunning = true;


                    if (AudioManager.Instance.GetComponent<AudioSource>().clip != AudioManager.Instance.MusicFiles[1])
                    {
                        AudioManager.Instance.GetComponent<AudioSource>().clip = AudioManager.Instance.MusicFiles[1];
                        AudioManager.Instance.GetComponent<AudioSource>().volume = 1.0f;
                        AudioManager.Instance.GetComponent<AudioSource>().Play();
                    }

                }
                // Check that the death screen is inactive
                if (LoseScreen.activeInHierarchy)
                {
                    LoseScreen.gameObject.SetActive(false);
                }
                // Check that the death screen is inactive
                if (WinScreen.activeInHierarchy)
                {
                    WinScreen.gameObject.SetActive(false);
                }
                break;
            case GameState.Dead:
                // Check that the menu is active
                if (!LoseScreen.activeInHierarchy)
                {
                    LoseScreen.gameObject.SetActive(true);
                    gameRunning = false;
                }
                break;
            case GameState.Win:
                if (gameRunning)
                {
                    // Stop the game
                    gameRunning = false;
                    // If the game isn't at the last level already 
                    if ((int)CurrentLevel < LevelPrefabs.Length -1)
                    {
                        // Increment level counter
                        CurrentLevel++;
                        // Change finishing text
                        WinScreen.transform.FindChild("You Win").gameObject.GetComponent<Text>().text = "Level  " + ((int)CurrentLevel + 1);
                    }
                    else
                    {
                        // Change finishing text
                        WinScreen.transform.FindChild("You Win").gameObject.GetComponent<Text>().text = "You Win";
                        // Change finishing keypress text 
                        WinScreen.transform.FindChild("Play Again").gameObject.GetComponent<Text>().text = "ANY BUTTON TO PLAY AGAIN";
                        // Reset the level counter
                        CurrentLevel = GameLevel.Level1;
                    }
                    // Check that the death screen is inactive
                    if (!WinScreen.activeInHierarchy)
                    {
                        WinScreen.gameObject.SetActive(true);
                    }
                }
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
