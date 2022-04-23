using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public bool GameIsPaused = true;
    //public bool DestroyPipes = false;

    public GameObject MainMenuUI;
    public GameObject GameOverMenuUI;
    public GameObject GetReadyMenuUI;
    public GameObject InGameMenuUI;
    public GameObject DayBackground;
    public GameObject NightBackground;
    public GameObject PauseButton;
    public GameObject ContinueButton;
    public GameObject PausedText;
    public GameObject NewHighScoreImage;
    public GameObject SilverMedalImage;
    public GameObject GoldMedalImage;

    public Button DayBackgroundButton;
    public Button NightBackgroundButton;

    public Text scoreText;
    public Text finalScoreText;
    public Text bestScoreText;



    private void Awake()
    {
        instance = this;
        int randBG = Random.Range(0, 2);

        if (randBG == 0)
        {
            DayBackground.SetActive(true);
            DayBackgroundButton.interactable = false;
        }
        else
        {
            NightBackground.SetActive(true);
            NightBackgroundButton.interactable = false;
        }
    }

    public void LoadUI(GameObject ui)
    {
        ui.SetActive(!ui.activeSelf);
    }

    public void LoadDayBackground()
    {
        DayBackgroundButton.interactable = false;
        NightBackgroundButton.interactable = true;

        DayBackground.SetActive(true);
        NightBackground.SetActive(false);
    }

    public void LoadNightBackground()
    {
        DayBackgroundButton.interactable = true;
        NightBackgroundButton.interactable = false;

        NightBackground.SetActive(true);
        DayBackground.SetActive(false);
    }

    public void PauseGame()
    {
        GameIsPaused = !GameIsPaused;

        if (GameIsPaused)
        {
            Time.timeScale = 0f;

            PausedText.SetActive(true);
            ContinueButton.SetActive(true);
            PauseButton.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;

            PausedText.SetActive(false);
            PauseButton.SetActive(true);
            ContinueButton.SetActive(false);
        }
    }

    public void GameOver(bool newHighScore, bool silverMedal, bool goldMedal)
    {
        Time.timeScale = 0f;
        InGameMenuUI.SetActive(false);
        GameOverMenuUI.SetActive(true);

        if (newHighScore)
        {
            NewHighScoreImage.SetActive(true);
        }

        if (silverMedal)
        {
            SilverMedalImage.SetActive(true);
        }
        else if (goldMedal)
        {
            GoldMedalImage.SetActive(true);
        }

        finalScoreText.text = scoreText.text;
        bestScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    //public void RestartGame()
    //{
    //    Time.timeScale = 1f;
    //    GameIsPaused = true;
    //    DestroyPipes = true;
    //    GameObject.Find("SpawnManager").GetComponent<SpawnManager>().StopAllCoroutines();
    //    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(-1.5f, 0f);
    //    GameOverMenuUI.SetActive(false);
    //    GetReadyMenuUI.SetActive(true);
    //}
}
