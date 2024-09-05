using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{

    public Questions[] categories;
    private Question selectedCategory;

    private int currentQuestionIndex = 0;

    public TMP_Text questionText;
    public Image questionImage;
    public Button[] replyButton;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
