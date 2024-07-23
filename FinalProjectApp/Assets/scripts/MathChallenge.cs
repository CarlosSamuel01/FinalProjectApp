using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathChallenge : MonoBehaviour
{
    public Text questionText;
    public InputField answerInput;
    public Text timerText;
    public Text attemptsText;
    public Text scoreText;
    public GameObject gameOverPanel;
    private AudioSource audioSource;
    public AudioClip correcto;
    public AudioClip incorrecto;

    private int score = 0;
    private int attempts = 3;
    private float timeLimit = 30f;
    private float timeRemaining;
    private int currentAnswer;
    private bool isPlaying = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        NewQuestion();
        timeRemaining = timeLimit;
        UpdateUI();
    }

    void Update()
    {
        if (isPlaying)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                CheckAnswer();
            }
            UpdateUI();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnSubmitAnswer();
        }
    }

    void NewQuestion()
    {
        int num1 = Random.Range(1, 50);
        int num2 = Random.Range(1, 50);
        bool isAddition = Random.value > 0.5f;

        if (isAddition)
        {
            currentAnswer = num1 + num2;
            questionText.text = num1 + " + " + num2;
        }
        else
        {
            // Asegurarse de que num1 sea mayor o igual que num2
            if (num1 < num2)
            {
                int temp = num1;
                num1 = num2;
                num2 = temp;
            }
            currentAnswer = num1 - num2;
            questionText.text = num1 + " - " + num2;
        }

        timeRemaining = timeLimit;
        answerInput.text = "";
    }

    public void CheckAnswer()
    {
        int playerAnswer;
        if (int.TryParse(answerInput.text, out playerAnswer))
        {
            if (playerAnswer == currentAnswer)
            {
                audioSource.PlayOneShot(correcto);
                score++;
                if (score % 5 == 0 && timeLimit > 10)
                {
                    timeLimit -= 5f;
                }
                NewQuestion();
            }
            else
            {
                attempts--;
                audioSource.PlayOneShot(incorrecto);
                if (attempts <= 0)
                {
                    GameOver();
                }
                else
                {
                    answerInput.text = "";
                }
            }
        }
        else
        {
            attempts--;
            if (attempts <= 0)
            {
                GameOver();
            }
            else
            {
                answerInput.text = "";
            }
        }
        UpdateUI();
        answerInput.ActivateInputField();
    }

    void UpdateUI()
    {
        timerText.text = "" + Mathf.Round(timeRemaining);
        attemptsText.text = "" + attempts;
        scoreText.text = "" + score;
    }

    void GameOver()
    {
        isPlaying = false;
        gameOverPanel.SetActive(true);
    }

    public void OnSubmitAnswer()
    {
        if (isPlaying)
        {
            CheckAnswer();
        }
    }
}
