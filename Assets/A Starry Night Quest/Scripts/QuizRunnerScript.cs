using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizRunnerScript : MonoBehaviour
{
    public Question[] questions;
    private List<Question> unansweredQuestions;
    private Question currentQuestion;
    private int score;

    public GameObject button1;
    public GameObject button2;

    public TextMeshProUGUI button1Reveal;
    public TextMeshProUGUI button2Reveal;

    public TextMeshProUGUI qNumText;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;
    private int questionsAnswered = 0;

    string scoreString;

    public Animator animator;

    public GameObject startScreen;
    public GameObject endScreen;
    public GameObject quizScreen;

    //public GameObject scoreContainer;
    public TextMeshProUGUI endScreenScore;
    public GameObject bronze;
    public GameObject silver;
    public GameObject gold;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    // Start is called before the first frame update
    void Start()
    {   
        Cursor.lockState = CursorLockMode.Confined;
        score = 0;
        startScreen.SetActive(true);
        endScreen.SetActive(false);
        quizScreen.SetActive(false);
    }

    public void EndGame() {
        quizScreen.SetActive(false);
        endScreen.SetActive(true);

        //scoreContainer.SetActive(true);
        endScreenScore.text = "" + score.ToString();

        bronze.SetActive(false);
        silver.SetActive(false);
        gold.SetActive(false);

        if(score >= 16)
        {
            gold.SetActive(true);
            MainManager.alertGold();
        }else if(score >= 11){
            silver.SetActive(true);
            MainManager.alertSilver();
        }else{
            bronze.SetActive(true);
            MainManager.alertBronze();
        }
    }

    void hailMary()
    {
        if(questionsAnswered <= 19)
        {
            qNumText.text = "Q" + (questionsAnswered + 1).ToString();
        }else{
            qNumText.text = "";
            EndGame();
        }
        
        
        button1Reveal.text = "";
        button2Reveal.text = "";

        animator.SetTrigger("Default");

        if(questionsAnswered != 20)
        {
            if(unansweredQuestions == null || unansweredQuestions.Count == 0)
            {
                unansweredQuestions = questions.ToList<Question>();
            }
            loadNextQuestion();
        }
    }

    void loadNextQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;

        button1Text.text = currentQuestion.response1;
        button2Text.text = currentQuestion.response2;

        transitionToNextQuestion();
    }

    IEnumerator transitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);
        hailMary();
        print(score);
    }



    public void userSelectedLeft()
    {
        animator.SetTrigger("Left Clicked");

        if(currentQuestion.correctResponse == 1)
        {
            score++;
            button1Reveal.text = "CORRECT";
            button2Reveal.text = "INCORRECT";
        }
        else{
            button1Reveal.text = "INCORRECT";
            button2Reveal.text = "CORRECT";
        }
        questionsAnswered++;
        StartCoroutine(transitionToNextQuestion());
    }
    public void userSelectedRight()
    {
        animator.SetTrigger("Right Clicked");

        if(currentQuestion.correctResponse == 2)
        {
            score++;
            button2Reveal.text = "CORRECT";
            button1Reveal.text = "INCORRECT";
        }
        else{
            button2Reveal.text = "INCORRECT";
            button1Reveal.text = "CORRECT";
        }
        questionsAnswered++;
        StartCoroutine(transitionToNextQuestion());
    }

    public void begin()
    {
        startScreen.SetActive(false);
        hailMary();
        quizScreen.SetActive(true);
    }


    public void FinishQuiz()
    {
        MainManager.alertAst();
        SceneManager.LoadScene(1);
    }
}
