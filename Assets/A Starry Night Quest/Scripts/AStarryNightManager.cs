using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AStarryNightManager : MonoBehaviour
{
    public GameObject PlayerToMove;
    public bool moveZon = false;
    public GameObject phase1;
    CharacterController cc;
    public GameObject next;

    public bool transition = false;

    float m_TimeLoadEndGameScene;

    public float EndSceneLoadDelay = 3f;

    public CanvasGroup EndGameFadeCanvasGroup;

    public GameObject leo;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;



    void Start()
    {
        cc = PlayerToMove.GetComponent<CharacterController>();
    }

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

        if (transition)
            {
                float timeRatio = 1 - (m_TimeLoadEndGameScene - Time.time) / EndSceneLoadDelay;
                EndGameFadeCanvasGroup.alpha = timeRatio;

                // See if it's time to load the end scene (after the delay)
                if (Time.time >= m_TimeLoadEndGameScene)
                {
                    //SceneManager.LoadScene(9);
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    moveToPosition();
                    TimeController.setToDay();

                }
            }







       if(moveZon)
       {
           
           phase1.SetActive(false);
           PlayerToMove.transform.position = new Vector3(-100f, 0.1f, 177.3f);
           moveZon = false;
           cc.enabled = true;
       } 
        
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<AudioSource> ().Play ();

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        GetComponent<AudioSource> ().Pause();
    }


    public void TransitionFunc()
    {
        turnOnLeo();

           
        transition = true;
        EndGameFadeCanvasGroup.gameObject.SetActive(true);
  

        m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay; //+ DelayBeforeFadeToBlack;


    }

    public void turnOnLeo()
    {
        leo.SetActive(true);
    }

    
    public void moveToPosition()
    {
        moveZon = true;
        cc.enabled = false;
    }

    public void nextDay()
    {
        next.SetActive(true);
    }

    public void nextDayoff()
    {
        next.SetActive(false);
    }

    public void loadTelescopeScene()
    {
        SceneManager.LoadScene(12);
    }

    public void returnToMain()
    {
        SceneManager.LoadScene(1);
    }

    public void loadQuiz()
    {
        SceneManager.LoadScene(14);
    }

    public void showCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
