using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float JumpForce = 0f, RotateSpeed = 0f;
    [SerializeField] private int SilverMedalScore = 0, GoldMedalScore = 0;

    private Rigidbody2D rigidBody;

    private bool rotateForward = false, rotateBack = true, newHighScore = false, silverMedal, goldMedal;

    private int score = 0;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!UIManager.instance.GameIsPaused)
        {
            rigidBody.simulated = true;
            Movement();
        }
        else if (UIManager.instance.GameIsPaused && UIManager.instance.GetReadyMenuUI.activeSelf && Input.GetMouseButtonDown(0))
        {
            UIManager.instance.GetReadyMenuUI.SetActive(false);
            UIManager.instance.GameIsPaused = false;
            UIManager.instance.InGameMenuUI.SetActive(true);

            rigidBody.simulated = true;
            Movement();
        }
        else if (UIManager.instance.GameIsPaused)
        {
            rigidBody.simulated = false;
        }
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            rotateForward = true;
            rotateBack = false;
        }

        if (rotateForward)
        {
            if (transform.rotation.z >= 0.2f)
            {
                rotateForward = false;
                rotateBack = true;
            }
            else
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * RotateSpeed);
            }
        }
        else if (rotateBack)
        {
            if (transform.rotation.z <= -0.25f)
            {
                rotateBack = false;
            }
            else
            {
                transform.Rotate(Vector3.back * Time.deltaTime * RotateSpeed / 5.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;

        UIManager.instance.scoreText.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
                newHighScore = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
            newHighScore = true;
        }

        if (score >= SilverMedalScore && score < GoldMedalScore)
        {
            silverMedal = true;
        }
        else if (score >= GoldMedalScore)
        {
            goldMedal = true;
        }

        UIManager.instance.GameOver(newHighScore, silverMedal, goldMedal);
    }
}
