using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class NewMonoBehaviourScript : MonoBehaviour
{
    String[][] dialogueBank = Dialogue.questionBank;
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private Button[] answerButtons;
    private TextMeshProUGUI[] answerTexts = new TextMeshProUGUI[4];
    string correctAnswer;
    int round = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize the array of answerTexts
        for (int i = 0; i < 4; i++)
        {
            answerTexts[i] = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        }
        newQuestion();

        // add a listener to each button and get its text when it's clicked
        foreach (Button button in answerButtons)
        {
            string buttonTextValue = button.GetComponentInChildren<TMP_Text>().text;

            button.onClick.AddListener(() => OnAnswerSelected(button, buttonTextValue));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Generates a new question with randomized answer choices
    public void newQuestion()
    {
        //reset color of buttons
        foreach (Button button in answerButtons)
        {
            button.GetComponent<Image>().color = Color.white; 
        }

        // update question + correct answer
        question.text = dialogueBank[round][0];
        correctAnswer = dialogueBank[round][1];
        
        // setup new array to store the answers based on the current round
        ArrayList possibleAnswers = new ArrayList();
        for (int i = 1; i < 5; i++)
        {
            possibleAnswers.Add(dialogueBank[round][i]);
            Debug.Log(dialogueBank[round][i]);
        }

        // choose a random index from possible answers, put the text into the answerBox text,
        // then remove that index from possible answers
        System.Random rand = new System.Random();
        for (int i = 0; i < 4; i++)
        {
            int randIndex = rand.Next(0, possibleAnswers.Count);
            Debug.Log( (string) possibleAnswers[randIndex]);
            answerTexts[i].text = (string) possibleAnswers[randIndex];
            possibleAnswers.RemoveAt(randIndex);
        }

        round++;
    }

    // called when player clicks a button
    void OnAnswerSelected(Button answerButton, string answerClicked)
    {
        //change button color to see if correct or not
        if (answerClicked.Equals(correctAnswer))
        {
            answerButton.GetComponent<Image>().color = Color.green;
        } else
        {
            answerButton.GetComponent<Image>().color = Color.red;
        }

        // change to a new question after 2 seconds
        Invoke(nameof(newQuestion), 2f);
    }

    // remove listeners cuz gemini says it'll avoid memory leaks
    private void OnDisable()
    {
        foreach (Button button in answerButtons)
        {
            string buttonTextValue = button.GetComponentInChildren<TMP_Text>().text;

            button.onClick.RemoveAllListeners();
        }
    }
}
