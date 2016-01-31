using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {



    public AudioClip[] MusicFiles;
    public AudioClip JumpSound;
    public AudioClip DeathSound;
    public AudioClip TrapSound;
    public AudioClip SacrificeSound;

    #region Singleton Check
    private static AudioManager audioManagerInstance = null;

    public static AudioManager Instance
    {
        get { return audioManagerInstance; }
    }

    void Awake()
    {
        if (audioManagerInstance != null && audioManagerInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else {
            audioManagerInstance = this;
        }
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

    public void SwitchMusicTo(int musicSelection)
    {
        GetComponent<AudioSource>().clip = MusicFiles[musicSelection];
    }

    public void TriggerJumpSound()
    {
        AudioSource playerAudio = GameManager.Instance.ThePlayer.GetComponent<AudioSource>();
        playerAudio.clip = JumpSound;
        playerAudio.Play();

    }

    public void TriggerDeathSound()
    {
        AudioSource playerAudio = GameManager.Instance.ThePlayer.GetComponent<AudioSource>();
        playerAudio.clip = DeathSound;
        playerAudio.Play();

    }

    public void TriggerTrapSound()
    {
        AudioSource playerAudio = GameManager.Instance.ThePlayer.GetComponent<AudioSource>();
        playerAudio.clip = TrapSound;
        playerAudio.Play();

    }

    public void TriggerSacrificeSound()
    {
        AudioSource playerAudio = GameManager.Instance.ThePlayer.GetComponent<AudioSource>();
        playerAudio.clip = SacrificeSound;
        playerAudio.Play();

    }

    // Update is called once per frame
    void Update () {
	
	}
}
