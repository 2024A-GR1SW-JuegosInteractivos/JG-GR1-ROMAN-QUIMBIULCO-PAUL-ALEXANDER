using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Required for TextMeshPro

public class QuestionManager : MonoBehaviour
{
    private int vidas = 3;
    public TextMeshProUGUI vidasText;  // Updated to TextMeshProUGUI
    public TextMeshProUGUI questionText;  // Updated to TextMeshProUGUI
    public Button[] answerButtons;  // Buttons remain the same
    public string correctAnswer;  // Set this to the correct answer in Inspector
    
    void Start()
    {
        // Set the question text
        questionText.text = "¿Qué es lo primero que debes hacer en un incendio?";
        correctAnswer = "1";
        // Set the answers on the buttons
        answerButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = "Evaluar la seguridad de la \nescena antes de intervenir.";  // Updated to TextMeshProUGUI
        answerButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Administrar oxígeno a cualquier \npersona cercana al incendio.";  // Correct Answer
        answerButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = "Entrar inmediatamente al edificio \npara rescatar a las víctimas.";
        answerButtons[3].GetComponentInChildren<TextMeshProUGUI>().text = "Comunicarse con las víctimas para \ntranquilizarlas desde afuera.";

        // Assign button click events
        answerButtons[0].onClick.AddListener(() => OnAnswerSelected("1"));
        answerButtons[1].onClick.AddListener(() => OnAnswerSelected("2"));
        answerButtons[2].onClick.AddListener(() => OnAnswerSelected("3"));
        answerButtons[3].onClick.AddListener(() => OnAnswerSelected("4"));

        vidasText.GetComponentInChildren<TextMeshProUGUI>().text = "Vidas: " + vidas;
    }

    void OnAnswerSelected(string selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            Debug.Log("Correct answer selected!");
            SceneManager.LoadScene("WinScene");
            // Add logic for correct answer (e.g., load next question, show feedback, etc.)
        }
        else
        {
            vidas--;
            vidasText.GetComponentInChildren<TextMeshProUGUI>().text = "Vidas: " + vidas;
            Debug.Log("Wrong answer selected.");
            if (vidas == 0)
            {
                Debug.Log("You Lost");
                SceneManager.LoadScene("LostScene");
            }
            // Add logic for wrong answer (e.g., show feedback, retry, etc.)
        }
    }
}