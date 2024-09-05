using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{

    public Questions[] categories;
    private Questions selectedCategory;

    private int currentQuestionIndex = 0;

    public TMP_Text questionText;
    public Image questionImage;
    public Button[] replyButton;

    [Header("Score")]
    public ScoreManager scoreController;
    public int correctScore = 2;
    public int wrongScore = 1;

    public
    // Start is called before the first frame update
    void Start()
    {
        categorySelect(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void categorySelect(int categoryIndex)
    {
        selectedCategory = categories[categoryIndex];
        currentQuestionIndex = 0;
        DisplayQuestion();
    }

    public void DisplayQuestion()
    {
        if (selectedCategory == null) return;
        var question = selectedCategory.questionsList[currentQuestionIndex];

        questionText.text = question.questionFormulation;

        questionImage.sprite = question.questionImage;

        for (int i = 0; i < replyButton.Length; i++)
        {
            TMP_Text buttonTexten = replyButton[i].GetComponentInChildren<TMP_Text>();
            buttonTexten.text = question.answers[i];
        }
    }

    public void OnReplySelect(int replyIndex)
    {
        if (replyIndex == selectedCategory.questionsList[currentQuestionIndex].correctAnswer)
        {
            Debug.Log("Du har svaret rigtigt!");
            scoreController.AddScore(correctScore);
        }
        else
        {
            Debug.Log("Du har svaret forkert!");
            scoreController.RemoveScore(wrongScore);
        }
        currentQuestionIndex++;

        if (currentQuestionIndex < selectedCategory.questionsList.Length)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Du har svaret på alle spørgsmål!");
        }
    }

}
