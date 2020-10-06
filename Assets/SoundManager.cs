using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour

{

    public static AudioClip jumpSound, coinSound, gameOverSound, bigJumpSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip> ("jump_01");
        coinSound = Resources.Load<AudioClip> ("coin_23");
        bigJumpSound = Resources.Load<AudioClip> ("jump_25");
        gameOverSound = Resources.Load<AudioClip> ("game_over_23");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        switch (clip) {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "gameOver":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "bigJump":
                audioSrc.PlayOneShot(bigJumpSound);
                break;
        }
    }
}
