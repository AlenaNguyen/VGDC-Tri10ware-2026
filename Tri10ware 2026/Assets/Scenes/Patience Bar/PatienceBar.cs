using UnityEngine;

public class PatienceBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float barMoveSpeed;
    public float barMoveSpeedMultiplier;
    private int numBarsLostA;
    private int numBarsLostB;
    public GameObject movingBar;
    private Rigidbody2D movingBarRigidBody;
    public GameObject patienceBarA1;
    public GameObject patienceBarA2;
    public GameObject patienceBarA3;
    public GameObject patienceBarB1;
    public GameObject patienceBarB2;
    public GameObject patienceBarB3;
    public float patienceBarBlockSize;
    private bool paused;
    private bool startedGame;
    private Vector3 startPosMovingBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startedGame = false;
        paused = false;

        startPosMovingBar = movingBar.transform.position;

        movingBarRigidBody = movingBar.GetComponent<Rigidbody2D>();
        movingBarRigidBody.linearVelocityX = 0;

        numBarsLostA = 0;
        numBarsLostB = 0;
    }

    // Update is called once per frame
    void Update()
    {
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

                RestartBUtton();
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

                RestartBUtton();
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
 
    public void RestartBUtton()
    {
        if (startedGame == true) {
            startedGame = false;

            movingBar.transform.position = startPosMovingBar;
            movingBarRigidBody.linearVelocityX = 0;

            patienceBarA1.SetActive(true);
            patienceBarA2.SetActive(true);
            patienceBarA3.SetActive(true);
            patienceBarB1.SetActive(true);
            patienceBarB2.SetActive(true);
            patienceBarB3.SetActive(true);

            numBarsLostA = 0;
            numBarsLostB = 0;
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
        }
    }

    public void WrongAnswer()
    {
        if (startedGame == true & paused == false) {
            movingBarRigidBody.linearVelocityX *= barMoveSpeedMultiplier;
        }
    }

    public void SwapDate()
    {
        movingBarRigidBody.linearVelocityX *= -1;
    }
}
