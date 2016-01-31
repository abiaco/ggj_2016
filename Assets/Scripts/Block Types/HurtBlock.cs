using UnityEngine;
using System.Collections;

public class HurtBlock : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    //! Upon collision with Player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == GameManager.Instance.ThePlayer)
        {
            // Tell the player to lose health
            GameManager.Instance.ThePlayer.GetComponent<PlayerProperties>().LoseHealth(1000f);
            AudioManager.Instance.TriggerDeathSound();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
