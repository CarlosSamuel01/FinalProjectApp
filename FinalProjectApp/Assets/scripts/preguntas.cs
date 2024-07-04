using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string questionText; // Texto de la pregunta
    public int correctAnswer;   // Respuesta correcta
    public string questionTemplate; // Plantilla de la pregunta con un espacio vac�o (_)
}

public class preguntas : MonoBehaviour
{
    public TMP_Text questionText;       // Referencia al TMP_Text que muestra la pregunta
    public TMP_InputField answerInput;  // Referencia al TMP_InputField para la respuesta del jugador
    public Button submitButton;

    private int currentQuestionIndex = 0; // �ndice de la pregunta actual
    public List<Question> questions = new List<Question>(); // Lista de preguntas

    void Start()
    {
        // Agregar preguntas a la lista
        questions.Add(new Question { questionText = "�Qu� n�mero falta en la siguiente ecuaci�n?", correctAnswer = 2, questionTemplate = "2 + _ = 4" });
        questions.Add(new Question { questionText = "�Qu� n�mero falta en la siguiente ecuaci�n?", correctAnswer = 3, questionTemplate = "1 + _ = 4" });
        questions.Add(new Question { questionText = "�Qu� n�mero falta en la siguiente ecuaci�n?", correctAnswer = 5, questionTemplate = "_ + 3 = 8" });
        questions.Add(new Question { questionText = "�Qu� n�mero falta en la siguiente ecuaci�n?", correctAnswer = 5, questionTemplate = "2 + 3 = _" });

        // Configurar la pregunta inicial
        SetQuestion(currentQuestionIndex);

        // Agregar listener al bot�n de enviar respuesta
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void SetQuestion(int index)
    {
        // Configurar la pregunta actual
        if (index < questions.Count)
        {
            questionText.text = questions[index].questionText + " " + questions[index].questionTemplate;
        }
        else
        {
            questionText.text = "�Has completado todas las preguntas!";
            submitButton.interactable = false; // Desactivar el bot�n cuando se completen todas las preguntas
        }
    }

    void CheckAnswer()
    {
        if (currentQuestionIndex < questions.Count)
        {
            // Obtener la respuesta del jugador
            int playerAnswer;
            if (int.TryParse(answerInput.text, out playerAnswer))
            {
                if (playerAnswer == questions[currentQuestionIndex].correctAnswer)
                {
                    Debug.Log("�Correcto!");
                    questionText.text = "�Correcto! " + questions[currentQuestionIndex].questionTemplate.Replace("_", playerAnswer.ToString());
                }
                else
                {
                    Debug.Log("Incorrecto, int�ntalo de nuevo.");
                    questionText.text = "Incorrecto, int�ntalo de nuevo. " + questions[currentQuestionIndex].questionTemplate;
                }
            }
            else
            {
                Debug.Log("Por favor, ingresa un n�mero v�lido.");
                questionText.text = "Por favor, ingresa un n�mero v�lido. " + questions[currentQuestionIndex].questionTemplate;
            }

            // Limpiar el campo de entrada
            answerInput.text = "";

            // Pasar a la siguiente pregunta si la respuesta es correcta
            if (playerAnswer == questions[currentQuestionIndex].correctAnswer)
            {
                currentQuestionIndex++;
                SetQuestion(currentQuestionIndex);
            }
        }
    }
}
