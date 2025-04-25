using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public Transform player1Level3;
    public Transform player2Level3;

    public PlayerReached waterLevel3;

    public CalculateRatio CR;

    public Slider slider;
    public Image bgrndImage;
    public float percentLeft = 100.0f;
    public GameObject GameOverScreen;
    public GameObject VictoryScreen;
    public TextMeshProUGUI percentText;

    bool restart = false;
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
            Time.timeScale = 0;
            percentText.text = "With " + percentLeft + "% left";
            VictoryScreen.SetActive(true);
        }

        if (waterLevel2.playerReached)
        {
            StartCoroutine(RestartLevel2Coroutine());
        }

        if (waterLevel3.playerReached)
        {
            StartCoroutine(RestartLevel3Coroutine());
        }

        if (Mathf.Abs(50 - CR.percentPlayer1) > 3)
        {
            percentLeft -= Time.deltaTime / 5 * Mathf.Pow(Mathf.Abs(50 - CR.percentPlayer1), 1.2f);

        }

        slider.value = percentLeft;
        if (percentLeft <= 0 && Time.timeScale != 0)
        {
            // GAME OVER
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
        else if (percentLeft < 10)
        {
            bgrndImage.color = Color.red;
        }
        else if (percentLeft < 50)
        {
            bgrndImage.color = Color.yellow;
        }

        if (restart) // Old Input System
        {
            Time.timeScale = 1f; // Reset in case game was paused
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RestartGame()
    {
        restart = true;
    }

    IEnumerator RestartLevel2Coroutine()
    {
        Time.timeScale = 0;

        yield return null; // wait one frame

        Animator anim1 = Player1.GetComponent<Animator>();
        Animator anim2 = Player2.GetComponent<Animator>();

        anim1.enabled = false;
        anim2.enabled = false;

        anim1.Play("Idle Walk Run Blend", 0, 0);
        anim2.Play("Idle Walk Run Blend", 0, 0);

        Player1.transform.position = player1Level2.position;
        Player2.transform.position = player2Level2.position;

        anim1.enabled = true;
        anim2.enabled = true;

        Time.timeScale = 1;

        waterLevel2.playerReached = false;
    }
    IEnumerator RestartLevel3Coroutine()
    {
        Time.timeScale = 0;

        yield return null; // wait one frame

        Animator anim1 = Player1.GetComponent<Animator>();
        Animator anim2 = Player2.GetComponent<Animator>();

        anim1.enabled = false;
        anim2.enabled = false;

        anim1.Play("Idle Walk Run Blend", 0, 0);
        anim2.Play("Idle Walk Run Blend", 0, 0);

        Player1.transform.position = player1Level3.position;
        Player2.transform.position = player2Level3.position;

        anim1.enabled = true;
        anim2.enabled = true;

        Time.timeScale = 1;

        waterLevel3.playerReached = false;
    }
}
