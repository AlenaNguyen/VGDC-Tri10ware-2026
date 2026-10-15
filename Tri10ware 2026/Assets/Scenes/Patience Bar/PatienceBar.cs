using UnityEngine;

public class PatienceBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float barMoveSpeed;
    public float barMoveSpeedMultiplier;
    private float originalBarMoveSpeed;

    public GameObject cam;
    private float cameraShakeCounter;
    public float cameraShakeDuration;
    public float cameraShakeMultiplier;
    private bool cameraShaking;
    public float cameraShakeSize;
    private Transform cameraTransform;
    private float originalCameraShakeDuration;
    private float originalCameraShakeSize;
    private float shakeAngle;

    public GameObject movingBar;
    private Rigidbody2D movingBarRigidBody;
    private Vector3 startPosMovingBar;

    private bool numBarsChanged;
    private int numBarsLostA;
    private int numBarsLostB;

    public GameObject patienceBarSprite;
    private SpriteRenderer patienceBarSpriteRenderer;
    public Sprite patienceBar00;
    public Sprite patienceBar10;
    public Sprite patienceBar20;
    public Sprite patienceBar01;
    public Sprite patienceBar02;
    public Sprite patienceBar11;
    public Sprite patienceBar12;
    public Sprite patienceBar21;
    public Sprite patienceBar22;
    public float patienceBarBlockSize;
    public float patienceBarSize;

    public GameObject buttonsLayer;
    private RectTransform buttonsLayerTransform;
    public GameObject charactersLayer;
    private Vector3 charactersMovePoint;
    private float originalCharactersTransitionSpeed;
    public float charactersTransitionSpeed;
    public float charactersTransitionSpeedMultiplier;
    public GameObject eDateButtons;
    public GameObject realDateButtons;

    private bool onPhone;
    private bool paused;
    private bool startedGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalBarMoveSpeed = barMoveSpeed;

        cameraShakeCounter = 0;
        cameraShaking = false;
        cameraTransform = cam.transform;
        originalCameraShakeSize = cameraShakeSize;
        originalCameraShakeDuration = cameraShakeDuration;
        shakeAngle = 0;
        cameraShaking = false;
        cameraShakeCounter = 0;
        cameraTransform.localRotation = Quaternion.Euler(0,0,0);

        numBarsChanged = false;
        numBarsLostA = 0;
        numBarsLostB = 0;

        patienceBarSpriteRenderer = patienceBarSprite.GetComponent<SpriteRenderer>();
        patienceBarSpriteRenderer.sprite = patienceBar00;

        movingBarRigidBody = movingBar.GetComponent<Rigidbody2D>();
        movingBarRigidBody.linearVelocityX = 0;
        startPosMovingBar = movingBar.transform.position;

        buttonsLayerTransform = buttonsLayer.GetComponent<RectTransform>();
        buttonsLayerTransform.localRotation = Quaternion.Euler(0,0,0);
        charactersLayer.transform.position = new Vector3(0, 0, 0);
        charactersMovePoint = new Vector3(0, 0, 0);
        originalCharactersTransitionSpeed = charactersTransitionSpeed;
        realDateButtons.SetActive(true);
        eDateButtons.SetActive(false);

        onPhone = false;
        startedGame = false;
        paused = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(charactersLayer.transform.position, charactersMovePoint) > 0.01f) {
            charactersLayer.transform.localPosition = Vector3.MoveTowards(charactersLayer.transform.localPosition, charactersMovePoint, charactersTransitionSpeed * Time.deltaTime);
        }

        if (cameraShaking) {
            cameraShakeCounter += Time.deltaTime;

            shakeAngle = Random.Range(-cameraShakeSize, cameraShakeSize);

            cameraTransform.rotation = Quaternion.Euler(0,0,shakeAngle);
            buttonsLayerTransform.localRotation = Quaternion.Euler(0,0,-shakeAngle);

            if (cameraShakeCounter > cameraShakeDuration){
                cameraShaking = false;
                cameraShakeCounter = 0;
                cameraTransform.localRotation = Quaternion.Euler(0,0,0);
                buttonsLayerTransform.localRotation = Quaternion.Euler(0,0,0);
            }

        }

        if (movingBar.transform.position.x < -patienceBarSize - (numBarsLostA * -patienceBarBlockSize)) {
            numBarsChanged = true;
            numBarsLostA += 1;
            if (numBarsLostA == 1) {
                movingBar.transform.position = startPosMovingBar;
            } else if (numBarsLostA == 2) {
                movingBar.transform.position = startPosMovingBar;
            } else if (numBarsLostA == 3) {
                movingBar.transform.position = startPosMovingBar;

                RestartButton();
            }
        }

        if (movingBar.transform.position.x > patienceBarSize - (numBarsLostB * patienceBarBlockSize)) {
            numBarsChanged = true;
            numBarsLostB += 1;
            if (numBarsLostB == 1) {
                movingBar.transform.position = startPosMovingBar;
            } else if (numBarsLostB == 2) {
                movingBar.transform.position = startPosMovingBar;
            } else if (numBarsLostB == 3) {
                movingBar.transform.position = startPosMovingBar;

                RestartButton();
            }
        }

        if (numBarsChanged) {
            if (numBarsLostA == 0) {
                if (numBarsLostB == 0) {
                    patienceBarSpriteRenderer.sprite = patienceBar00;
                } else if (numBarsLostB == 1) {
                    patienceBarSpriteRenderer.sprite = patienceBar01;
                } else if (numBarsLostB == 2) {
                    patienceBarSpriteRenderer.sprite = patienceBar02;
                }
            } else if (numBarsLostA == 1) {
                if (numBarsLostB == 0) {
                    patienceBarSpriteRenderer.sprite = patienceBar10;
                } else if (numBarsLostB == 1) {
                    patienceBarSpriteRenderer.sprite = patienceBar11;
                } else if (numBarsLostB == 2) {
                    patienceBarSpriteRenderer.sprite = patienceBar12;
                }
            } else if (numBarsLostA == 2) {
                if (numBarsLostB == 0) {
                    patienceBarSpriteRenderer.sprite = patienceBar20;
                } else if (numBarsLostB == 1) {
                    patienceBarSpriteRenderer.sprite = patienceBar21;
                } else if (numBarsLostB == 2) {
                    patienceBarSpriteRenderer.sprite = patienceBar22;
                }
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
            barMoveSpeed = originalBarMoveSpeed;

            cameraShakeCounter = 0;
            cameraShaking = false;
            cameraTransform = cam.transform;
            originalCameraShakeSize = cameraShakeSize;
            originalCameraShakeDuration = cameraShakeDuration;
            shakeAngle = 0;
            cameraShaking = false;
            cameraShakeCounter = 0;
            cameraTransform.localRotation = Quaternion.Euler(0,0,0);
            buttonsLayerTransform.localRotation = Quaternion.Euler(0,0,0);

            movingBar.transform.position = startPosMovingBar;
            movingBarRigidBody.linearVelocityX = 0;

            numBarsChanged = false;
            numBarsLostA = 0;
            numBarsLostB = 0;

            patienceBarSpriteRenderer.sprite = patienceBar00;

            charactersLayer.transform.position = new Vector3(0, 0, 0);
            charactersMovePoint = new Vector3(0, 0, 0);
            charactersTransitionSpeed = originalCharactersTransitionSpeed;
            realDateButtons.SetActive(true);
            eDateButtons.SetActive(false);


            cameraShaking = false;
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
            charactersTransitionSpeed *= charactersTransitionSpeedMultiplier;
        }
    }

    public void WrongAnswer()
    {
        if (startedGame == true & paused == false) {
            movingBarRigidBody.linearVelocityX *= barMoveSpeedMultiplier;
            charactersTransitionSpeed *= charactersTransitionSpeedMultiplier;

            if (!cameraShaking) {
                cameraShaking = true;
            } else {
                cameraShakeCounter = 0;
            }
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
