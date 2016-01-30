using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // Variable declarations
    public GameObject ThePlayer;

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
    }

    private static bool applicationIsQuitting = false;
    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    #endregion

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
