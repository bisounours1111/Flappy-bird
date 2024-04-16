using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;


    public Rigidbody2D rb;

    public float delay = 0.5f;
    public float time = 0.0f;

    public GameObject[] Score;
    public Sprite[] PrefabScore;
    public int score = 20;

    public GameObject restartButton;

    public bool isGameOver = false;

    public AudioListener audioListener;

    public AudioClip[] soundEffects;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        SetScore();
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && time > delay)
        {
            GetComponent<AudioSource>().PlayOneShot(soundEffects[2]);
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * speed);
            time = 0.0f;
        }
    }

    public void SetScore()
    {
        ClearScore();
        string scoreString = score.ToString();
        for (int i = 4-scoreString.Length; i < 4; i++)
        {
            Debug.Log((i));
            Score[i].GetComponent<SpriteRenderer>().sprite = PrefabScore[int.Parse(scoreString[i-4+scoreString.Length].ToString())];
        }
    }

    void ClearScore()
    {
        for (int i = 0; i < Score.Length; i++)
        {
            Score[i].GetComponent<SpriteRenderer>().sprite = PrefabScore[0];
        }
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void GameOver()
    {
        isGameOver = true;
        restartButton.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(soundEffects[0]);
        GetComponent<BoxCollider2D>().enabled = false;
        rb.AddForce(transform.up * speed);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        rb.AddTorque(rotationSpeed);


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            GameOver();
        }
    }
}
