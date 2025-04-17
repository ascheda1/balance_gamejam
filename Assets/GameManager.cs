using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioSource GlobalAudio;
    public AudioClip Flow;
    public AudioClip Impulse;
    public AudioClip Metropolis;
    public int activeAudio = 0;

    public PlayerReached playerReachedLevel2;
    public PlayerReached playerReachedLevel3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerReachedLevel2.playerReached && activeAudio == 0)
        {
            GlobalAudio.clip = Impulse;
            GlobalAudio.Play();
            activeAudio = 1;
        }

        if (playerReachedLevel3.playerReached && activeAudio == 1)
        {
            GlobalAudio.clip = Metropolis;
            GlobalAudio.Play();
            activeAudio = 2;
        }
    }
}
