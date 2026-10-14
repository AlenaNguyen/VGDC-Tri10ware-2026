using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    String[][] dialogueBank;

    public TextMeshProUGUI question;
    [SerializeField] Button[] answerButtons;
    private TextMeshProUGUI[] answerTexts = new TextMeshProUGUI[4];
    string correctAnswer;
    int round = 0;
    public bool isDog;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize dialogueBank based on the date
        if (isDog)
        {
            dialogueBank = Dialogue.dogQuestionBank;
        } else
        {
            dialogueBank = Dialogue.catQuestionBank;
        }
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

            button.onClick.AddListener(() => OnAnswerSelected(button));
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
        }

        // choose a random index from possible answers, put the text into the answerBox text,
        // then remove that index from possible answers
        System.Random rand = new System.Random();
        for (int i = 0; i < 4; i++)
        {
            int randIndex = rand.Next(0, possibleAnswers.Count);
            answerTexts[i].text = (string) possibleAnswers[randIndex];
            possibleAnswers.RemoveAt(randIndex);
        }

        // if we're at the end of the dialogue choices
        if (round + 1 == dialogueBank.Length)
        {
           // TODO: uhh end the game 
        } else
        {
            round++;
        }
    }

    // called when player clicks a button
    void OnAnswerSelected(Button answerButton)
    {
        string answerClicked = answerButton.GetComponentInChildren<TextMeshProUGUI>().text;
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
