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
    public string questionTemplate; // Plantilla de la pregunta con un espacio vacío (_)
}

public class preguntas : MonoBehaviour
{
    public TMP_Text questionText;       // Referencia al TMP_Text que muestra la pregunta
    public TMP_InputField answerInput;  // Referencia al TMP_InputField para la respuesta del jugador
    public Button submitButton;
    public TMP_Text timerText;          // Referencia al TMP_Text que muestra el temporizador

    private float elapsedTime = 0f;     // Tiempo transcurrido

    public List<Question> questions = new List<Question>(); // Lista de preguntas

    private Question currentQuestion; // Pregunta actual

    void Start()
    {
        // Agregar preguntas a la lista
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 2, questionTemplate = "2 + _ = 4" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 3, questionTemplate = "5 - _ = 2" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 4, questionTemplate = "_ * 3 = 12" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 3, questionTemplate = "15 / _ = 5" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 5, questionTemplate = "7 + _ = 12" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 2, questionTemplate = "8 - _ = 6" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 6, questionTemplate = "2 * _ = 12" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 2, questionTemplate = "_ / 5 = 2" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 9, questionTemplate = "_ + 4 = 13" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 1, questionTemplate = "6 - _ = 5" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 5, questionTemplate = "_ * 1 = 5" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 4, questionTemplate = "20 / _ = 5" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 7, questionTemplate = "3 + _ = 10" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 2, questionTemplate = "_ - 7 = 2" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 3, questionTemplate = "4 * _ = 12" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 3, questionTemplate = "21 / _ = 7" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 8, questionTemplate = "5 + _ = 13" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 3, questionTemplate = "10 - _ = 7" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 2, questionTemplate = "6 * _ = 12" });
        questions.Add(new Question { questionText = "¿Qué número falta en la siguiente ecuación?", correctAnswer = 4, questionTemplate = "_ / 4 = 1" });

        // Configurar la pregunta inicial
        SetQuestion();

        // Agregar listener al botón de enviar respuesta
        submitButton.onClick.AddListener(CheckAnswer);

        // Agregar listener para la tecla Enter
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); });

        // Seleccionar el campo de entrada automáticamente al inicio
        answerInput.ActivateInputField();
    }

    void Update()
    {
        // Actualizar el temporizador
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime - minutes * 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    void SetQuestion()
    {
        // Configurar la pregunta actual de forma aleatoria
        if (questions.Count > 0)
        {
            int randomIndex = Random.Range(0, questions.Count);
            currentQuestion = questions[randomIndex];
            questionText.text = currentQuestion.questionText + " " + currentQuestion.questionTemplate;
            questions.RemoveAt(randomIndex); // Eliminar la pregunta seleccionada de la lista
        }
        else
        {
            questionText.text = "¡Has completado todas las preguntas!";
            submitButton.interactable = false; // Desactivar el botón cuando se completen todas las preguntas
        }

        // Seleccionar automáticamente el campo de entrada
        answerInput.ActivateInputField();
    }

    void CheckAnswer()
    {
        if (currentQuestion != null)
        {
            // Obtener la respuesta del jugador
            int playerAnswer;
            if (int.TryParse(answerInput.text, out playerAnswer))
            {
                if (playerAnswer == currentQuestion.correctAnswer)
                {
                    Debug.Log("¡Correcto!");
                    questionText.text = "¡Correcto! " + currentQuestion.questionTemplate.Replace("_", playerAnswer.ToString());
                }
                else
                {
                    Debug.Log("Incorrecto, inténtalo de nuevo.");
                    questionText.text = "Incorrecto, inténtalo de nuevo. " + currentQuestion.questionTemplate;
                    answerInput.ActivateInputField(); // Seleccionar automáticamente el campo de entrada
                    return; // No pasar a la siguiente pregunta si la respuesta es incorrecta
                }
            }
            else
            {
                Debug.Log("Por favor, ingresa un número válido.");
                questionText.text = "Por favor, ingresa un número válido. " + currentQuestion.questionTemplate;
                answerInput.ActivateInputField(); // Seleccionar automáticamente el campo de entrada
                return; // No pasar a la siguiente pregunta si la entrada no es válida
            }

            // Limpiar el campo de entrada
            answerInput.text = "";

            // Configurar la siguiente pregunta
            SetQuestion();

            // Seleccionar automáticamente el campo de entrada
            answerInput.ActivateInputField();
        }
    }
}