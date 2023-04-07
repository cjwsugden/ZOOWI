using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
public class PBGameManager : MonoBehaviour
{

    private static int _playerScore ;
    private static int _pcScore ;
    public Ball ball;
     public TMP_Text PlayerScore;
    public TMP_Text AIScore;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    

    // Start is called before the first frame update
    void Start()
    {
       _playerScore = 0;
       _pcScore = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<AudioSource> ().Play();

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        GetComponent<AudioSource> ().Pause();
    }




        public void _playerScores(){
        _playerScore ++ ;
        this.PlayerScore.text = _playerScore.ToString();
        this.ball.ResetPosition();
        
    }

    public void _pcScores(){
        _pcScore++;
        this.AIScore.text = _pcScore.ToString();
        this.ball.ResetPosition();
        
    }


    public static int getplayerscore(){
        return _playerScore;
    }

     public static int getpcscore(){
        return _pcScore;
    }

    

    public void QuitGame ()
    {
        Application.Quit();
    }



}
