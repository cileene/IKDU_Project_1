using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class QuizManager : MonoBehaviour
{
    public Question[] categories;
    private Questions selectedCategory;

    private int currentQuestionIndex = 0;
    
    public TMP_Text questionText;
    public Image questionImage;
    public Button[] replyButton;

    // Start is called before the first frame update
    void Start()
    {
        CategorySelect(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CategorySelect(int categoryIndex)
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
        

}
