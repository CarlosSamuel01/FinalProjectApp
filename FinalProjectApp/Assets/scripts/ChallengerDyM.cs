using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengerDyM : MonoBehaviour
{
    public Text questionText;
    public InputField answerInput;
    public Text timerText;
    public Text attemptsText;
    public Text scoreText;
    public GameObject gameOverPanel;

    private int score = 0;
    private int attempts = 3;
    private float timeLimit = 60f;
    private float timeRemaining;
    private float currentAnswer;
    private bool isPlaying = true;

    void Start()
    {
        gameOverPanel.SetActive(false);
        NewQuestion();
        timeRemaining = timeLimit;
        UpdateUI();
        answerInput.ActivateInputField();
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

            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnSubmitAnswer();
            }
        }
    }

    void NewQuestion()
    {
        int num1 = Random.Range(1, 101);
        int num2 = Random.Range(1, 101);
        int operation = Random.Range(0, 2); // 0: Multiplication, 1: Division

        switch (operation)
        {
            case 0: // Multiplication
                currentAnswer = num1 * num2;
                questionText.text = num1 + " * " + num2;
                break;
            case 1: // Division
                while (num1 % num2 != 0 || num1 < num2)
                {
                    num1 = Random.Range(1, 101);
                    num2 = Random.Range(1, 101);
                }
                currentAnswer = num1 / (float)num2;
                questionText.text = num1 + " / " + num2;
                break;
        }

        timeRemaining = timeLimit;
        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    public void CheckAnswer()
    {
        float playerAnswer;
        if (float.TryParse(answerInput.text, out playerAnswer))
        {
            if (Mathf.Abs(playerAnswer - currentAnswer) < 0.01f) // Allow some tolerance for floating point comparison
            {
                score++;
                if (score % 5 == 0 && timeLimit > 30)
                {
                    timeLimit -= 5f;
                }
                NewQuestion();
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
