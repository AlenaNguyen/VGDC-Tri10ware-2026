using UnityEngine;

public class PatienceBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float barMoveSpeed;
    public float barMoveSpeedMultiplier;

    public GameObject movingBar;
    private Rigidbody2D movingBarRigidBody;
    private Vector3 startPosMovingBar;

    private int numBarsLostA;
    private int numBarsLostB;

    public GameObject patienceBarA1;
    public GameObject patienceBarA2;
    public GameObject patienceBarA3;
    public GameObject patienceBarB1;
    public GameObject patienceBarB2;
    public GameObject patienceBarB3;
    public float patienceBarBlockSize;

    public GameObject buttonsLayer;
    public GameObject charactersLayer;
    private Vector3 charactersMovePoint;
    public float charactersTransitionSpeed;
    private float currCharactersTransitionSpeed;
    public float charactersTransitionSpeedMultiplier;
    public GameObject eDateButtons;
    public GameObject realDateButtons;

    private bool onPhone;
    private bool paused;
    private bool startedGame;
    private bool swapping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numBarsLostA = 0;
        numBarsLostB = 0;

        movingBarRigidBody = movingBar.GetComponent<Rigidbody2D>();
        movingBarRigidBody.linearVelocityX = 0;
        startPosMovingBar = movingBar.transform.position;

        patienceBarA1.SetActive(true);
        patienceBarA2.SetActive(true);
        patienceBarA3.SetActive(true);
        patienceBarB1.SetActive(true);
        patienceBarB2.SetActive(true);
        patienceBarB3.SetActive(true);

        charactersLayer.transform.position = new Vector3(0, 0, 0);
        charactersMovePoint = new Vector3(0, 0, 0);
        currCharactersTransitionSpeed = charactersTransitionSpeed;
        realDateButtons.SetActive(true);
        eDateButtons.SetActive(false);

        onPhone = false;
        startedGame = false;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (charactersLayer.transform.position != charactersMovePoint) {
            charactersLayer.transform.position = Vector3.MoveTowards(charactersLayer.transform.position, charactersMovePoint, charactersTransitionSpeed * Time.deltaTime);
        }

        if (movingBar.transform.position.x < -3.5 - (numBarsLostA * -patienceBarBlockSize)) {
            numBarsLostA += 1;
            if (numBarsLostA == 1) {
                patienceBarA1.SetActive(false);
                movingBar.transform.position = startPosMovingBar;
            } else if (numBarsLostA == 2) {
                patienceBarA2.SetActive(false);
                movingBar.transform.position = startPosMovingBar;
            } else if (numBarsLostA == 3) {
                patienceBarA3.SetActive(false);
                movingBar.transform.position = startPosMovingBar;

                RestartButton();
            }
        }

        if (movingBar.transform.position.x > 3.5 - (numBarsLostB * patienceBarBlockSize)) {
            numBarsLostB += 1;
            if (numBarsLostB == 1) {
                patienceBarB1.SetActive(false);
                movingBar.transform.position = startPosMovingBar;
            } else if (numBarsLostB == 2) {
                patienceBarB2.SetActive(false);
                movingBar.transform.position = startPosMovingBar;
            } else if (numBarsLostB == 3) {
                patienceBarB3.SetActive(false);
                movingBar.transform.position = startPosMovingBar;

                RestartButton();
            }
            
        }
    }

    public void StartButton()
    {
        if (startedGame == false) {
            startedGame = true;
            movingBarRigidBody.linearVelocityX = barMoveSpeed;
        }
    }
 
    public void RestartButton()
    {
        if (startedGame == true) {
            movingBar.transform.position = startPosMovingBar;
            movingBarRigidBody.linearVelocityX = 0;

            numBarsLostA = 0;
            numBarsLostB = 0;

            patienceBarA1.SetActive(true);
            patienceBarA2.SetActive(true);
            patienceBarA3.SetActive(true);
            patienceBarB1.SetActive(true);
            patienceBarB2.SetActive(true);
            patienceBarB3.SetActive(true);

            charactersLayer.transform.position = new Vector3(0, 0, 0);
            charactersMovePoint = new Vector3(0, 0, 0);
            currCharactersTransitionSpeed = charactersTransitionSpeed;
            realDateButtons.SetActive(true);
            eDateButtons.SetActive(false);

            onPhone = false;
            startedGame = false;
            paused = false;
        }
    }

    public void PauseButton()
    {
        if (startedGame == true) {
            if (paused == false) {
                paused = true;
                Time.timeScale = 0f;     
            } else {
                paused = false;
                Time.timeScale = 1f;  
            }
        }
    }

    public void RightAnswer()
    {
        if (startedGame == true & paused == false) {
            movingBarRigidBody.linearVelocityX *= barMoveSpeedMultiplier;
            currCharactersTransitionSpeed *= charactersTransitionSpeedMultiplier;
        }
    }

    public void WrongAnswer()
    {
        if (startedGame == true & paused == false) {
            movingBarRigidBody.linearVelocityX *= barMoveSpeedMultiplier;
            currCharactersTransitionSpeed *= charactersTransitionSpeedMultiplier;
        }
    }

    public void SwapDate()
    {
        if (startedGame == true & paused == false) {
            movingBarRigidBody.linearVelocityX *= -1;
            onPhone = !onPhone;

            if (onPhone) {
                charactersMovePoint = new Vector3(-18, 0, 0);

                realDateButtons.SetActive(false);
                eDateButtons.SetActive(true);
            } else {
                charactersMovePoint = new Vector3(0, 0, 0);

                eDateButtons.SetActive(false);
                realDateButtons.SetActive(true);
            }
        }
    }
}
