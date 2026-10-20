using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScreens : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScreen() {
        SceneManager.LoadScene("Start Screen");
    }  

    public void WinningEndScreen() {
        SceneManager.LoadScene("Winning End Screen");
    }   

    public void LosingEndScreen() {
        SceneManager.LoadScene("Losing End Screen");
    }   

    public void TutorialScreen() {
        SceneManager.LoadScene("Tutorial Screen");
    }    

    public void GameScreen() {
        Debug.Log("game");
        SceneManager.LoadScene("PatienceBar");
    }    
}
