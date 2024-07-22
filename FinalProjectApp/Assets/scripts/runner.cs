using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class MathGameController : MonoBehaviour
{
    public TMP_Text questionText;       // Referencia al TMP_Text que muestra la pregunta
    public TMP_InputField answerInput;  // Referencia al TMP_InputField para la respuesta del jugador
    public Button submitButton;         // Referencia al Button para enviar la respuesta
    public TMP_Text turnCounterText;    // Referencia al TMP_Text que muestra el contador de turnos
    public Transform player;            // Referencia al objeto que representa al jugador
    public float stepDistance = 1.0f;   // Distancia que el jugador se moverá con cada paso
    public TMP_Text finalturns;

    private int currentQuestionIndex = 0; // Índice de la pregunta actual
    private int turnCounter = 0;          // Contador de turnos
    public List<Question> questions = new List<Question>(); // Lista de preguntas

    void Start()
    {
        // Agregar preguntas a la lista
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 4, questionTemplate = "2 + 2 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 3, questionTemplate = "5 - 2 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 6, questionTemplate = "_ + 4 = 10" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 5, questionTemplate = "7 - 2 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 9, questionTemplate = "4 + 5 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 2, questionTemplate = "8 - 6 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 10, questionTemplate = "6 + 4 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 4, questionTemplate = "_ - 1 = 3" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 7, questionTemplate = "3 + 4 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 5, questionTemplate = "10 - 5 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 8, questionTemplate = "_ + 2 = 10" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 1, questionTemplate = "6 - 5 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 13, questionTemplate = "8 + 5 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 2, questionTemplate = "7 - 5 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 14, questionTemplate = "9 + 5 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 3, questionTemplate = "8 - 5 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 15, questionTemplate = "10 + 5 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 2, questionTemplate = "_ - 1 = 1" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 6, questionTemplate = "2 + 4 = _" });
        questions.Add(new Question { questionText = "¿cuál es la respuesta?", correctAnswer = 3, questionTemplate = "9 - 6 = _" });

        // Mezclar las preguntas aleatoriamente
        ShuffleQuestions();

        // Configurar la pregunta inicial
        SetQuestion(currentQuestionIndex);

        // Configurar el contador de turnos inicial
        UpdateTurnCounter();

        // Agregar listener al botón de enviar respuesta
        submitButton.onClick.AddListener(CheckAnswer);

        // Agregar listener para la tecla Enter
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); });

        // Seleccionar el campo de entrada automáticamente al inicio
        answerInput.ActivateInputField();
    }

    void ShuffleQuestions()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            Question temp = questions[i];
            int randomIndex = Random.Range(i, questions.Count);
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }
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
            // Si se han completado todas las preguntas, volver a mezclar y comenzar de nuevo
            ShuffleQuestions();
            currentQuestionIndex = 0;
            SetQuestion(currentQuestionIndex);
        }

        // Seleccionar automáticamente el campo de entrada
        answerInput.ActivateInputField();
    }

    void UpdateTurnCounter()
    {
        turnCounterText.text = "Turnos: " + turnCounter;
        finalturns.text = "Turnos: " + turnCounter;
    }

    void CheckAnswer()
    {
        if (currentQuestionIndex < questions.Count)
        {
            // Obtener la respuesta del jugador
            int playerAnswer;
            if (int.TryParse(answerInput.text, out playerAnswer))
            {
                // Incrementar el contador de turnos
                turnCounter++;
                UpdateTurnCounter();

                if (playerAnswer == questions[currentQuestionIndex].correctAnswer)
                {
                    Debug.Log("¡Correcto!");
                    questionText.text = "¡Correcto! " + questions[currentQuestionIndex].questionTemplate.Replace("_", playerAnswer.ToString());

                    // Mover al jugador un paso adelante
                    player.position += Vector3.forward * stepDistance;

                    // Pasar a la siguiente pregunta
                    currentQuestionIndex++;
                    SetQuestion(currentQuestionIndex);
                }
                else
                {
                    Debug.Log("Incorrecto, inténtalo de nuevo.");
                    questionText.text = "Incorrecto, inténtalo de nuevo. " + questions[currentQuestionIndex].questionTemplate;

                    // Mover al jugador un paso hacia atrás
                    player.position += Vector3.back * stepDistance;
                }
            }
            else
            {
                Debug.Log("Por favor, ingresa un número válido.");
                questionText.text = "Por favor, ingresa un número válido. " + questions[currentQuestionIndex].questionTemplate;
            }

            // Limpiar el campo de entrada
            answerInput.text = "";

            // Seleccionar automáticamente el campo de entrada
            answerInput.ActivateInputField();
        }
    }
}