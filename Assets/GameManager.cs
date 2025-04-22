using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;

    public AudioSource GlobalAudio;
    public AudioClip Flow;
    public AudioClip Impulse;
    public AudioClip Metropolis;
    public AudioClip Neon;
    public int activeAudio = 0;

    public PlayerReached playerReachedLevel2;
    public PlayerReached playerReachedLevel3;
    public PlayerReached blockFinnish;

    public PlayerReached waterLevel2;

    public Transform player1Level2;
    public Transform player2Level2;

    public CalculateRatio CR;

    public Slider slider;
    public Image bgrndImage;
    public float percentLeft = 1000.0f;
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

        if (blockFinnish.playerReached && activeAudio == 2)
        {
            GlobalAudio.clip = Neon;
            GlobalAudio.Play();
            activeAudio = 3;
        }

        if (waterLevel2.playerReached)
        {
            StartCoroutine(RestartLevel2Coroutine());
        }

        if (Mathf.Abs(50 - CR.percentPlayer1) > 3)
        {
            percentLeft -= Time.deltaTime * Mathf.Abs(50 - CR.percentPlayer1);

        }

        slider.value = percentLeft;
        if (percentLeft < 0)
        {
            // GAME OVER
        }
        else if (percentLeft < 100)
        {
            bgrndImage.color = Color.red;
        }
        else if (percentLeft < 500)
        {
            bgrndImage.color = Color.yellow;
        }
    }

    IEnumerator RestartLevel2Coroutine()
    {
        Time.timeScale = 0;

        yield return null; // wait one frame

        Animator anim1 = Player1.GetComponent<Animator>();
        Animator anim2 = Player2.GetComponent<Animator>();

        anim1.enabled = false;
        anim2.enabled = false;

        anim1.Play("Idle", 0, 0); // Replace "Idle" with your default state
        anim2.Play("Idle", 0, 0);

        Player1.transform.position = player1Level2.position;
        Player2.transform.position = player2Level2.position;

        anim1.enabled = true;
        anim2.enabled = true;

        Time.timeScale = 1;

        waterLevel2.playerReached = false;
    }
}
