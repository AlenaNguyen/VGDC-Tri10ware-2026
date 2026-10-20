using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NUnit.Framework;
using System.Diagnostics;
using Unity.VisualScripting;

public class NewMonoBehaviourScript : MonoBehaviour
{
    String[][] dialogueBank;

    public Text question;
    [SerializeField] Button[] answerButtons;
    private Text[] answerTexts = new Text[4];
    string correctAnswer;
    public int round = 0;
    public bool isDog;
    PatienceBar patienceBar;
    SwitchScreens switchScreens = new SwitchScreens();
    public float questionDelay = 1;
    bool isDialogueFinished;
    public GameObject otherDate;
    private NewMonoBehaviourScript otherDateQuestions;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        patienceBar = GameObject.FindWithTag("PatienceBar").GetComponent<PatienceBar>();
        otherDateQuestions = otherDate.GetComponent<NewMonoBehaviourScript>();

        isDialogueFinished = false;

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
            answerTexts[i] = answerButtons[i].GetComponentInChildren<Text>();
        }
        newQuestion();
    }

    void OnEnable()
    {
        // add a listener to each button and get its text when it's clicked
        foreach (Button button in answerButtons)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => OnAnswerSelected(button));
        }
        
    }

    // Generates a new question with randomized answer choices
    public void newQuestion()
    {
        // if we're at the end of the dialogue choices
        if (round == dialogueBank.Length)
        {
            isDialogueFinished = true;
            // if the other date is finished too, end the game :D
            if (otherDateQuestions.isDialogueFinished)
            {
                switchScreens.WinningEndScreen();
            } 
            // if not, set the dialogue to the ending dialogue and 
            // pause the patience bar
            else
            {
                patienceBar.OnlyPausePatienceBar();
                question.text = "Thanks for answering my questions! Hope we chat again soon!";
                for (int i = 0; i < 4; i++)
                {
                    answerTexts[i].text = ":)";
                }
            }
            return;
        }

        //reset color of buttons
        foreach (Button button in answerButtons)
        {
            Image buttonImage = button.GetComponent<Image>();
            Color tempColor = buttonImage.color;
            tempColor.a = 0f;
            buttonImage.color = tempColor;
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

        round++;
    }

    // called when player clicks a button
    public void OnAnswerSelected(Button answerButton)
    {
        // only continue if we're not finished
        // if we are finished, just set a random color i guess lol
        if (isDialogueFinished)
        {
            System.Random rand = new System.Random();
            byte randomRed = (byte) rand.Next(0, 255);
            byte randomGreen = (byte) rand.Next(0, 255);
            byte randomBlue = (byte) rand.Next(0, 255);

            answerButton.GetComponent<Image>().color = new Color32(randomRed, randomGreen, randomBlue, 100);
        } else {
            if (patienceBar.startedGame == true & patienceBar.paused == false) {
                string answerClicked = answerButton.GetComponentInChildren<Text>().text;
                //change button color to see if correct or not
                if (answerClicked.Equals(correctAnswer))
                {
                    answerButton.GetComponent<Image>().color = Color.green;
                    patienceBar.RightAnswer();
                } else
                {
                    answerButton.GetComponent<Image>().color = Color.red;
                    patienceBar.WrongAnswer();
                }

                // change to a new question after some time
                Invoke(nameof(newQuestion), questionDelay);
            }
        }
    }

    // remove listeners cuz gemini says it'll avoid memory leaks
    private void OnDisable()
    {
        foreach (Button button in answerButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
