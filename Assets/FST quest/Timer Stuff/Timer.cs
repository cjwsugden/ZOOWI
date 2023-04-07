using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

    public Image uiFill;
    public TMP_Text uiText;
    //public RectTransform fxHolder;
    public GameObject GameOver;
    public GameObject CoinCollector;
    public GameObject GameGUI;
    public GameObject Globals;
    public GameObject remWarning;

    //[SerializeField] [Range(0,1)] float progress = 0f;


    public int Duration;

    private int remainingDuration;

    private void Start()
    {
        Being(Duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());

    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            
                uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                //fxHolder.rotation = Quaternion.Euler (new Vector3 (0f, 0f, -remainingDuration * 360));
                remainingDuration--;
                yield return new WaitForSeconds(1f);

                 if(remainingDuration == 10){
                    remWarning.gameObject.SetActive(true);
                    Invoke("finalTimeFadeOut", 3);
                    colorChange();       
            }
        }
        OnEnd();
    }

    private void OnEnd()
    {
        failQuest();
        print("End");
    }

       public void FadeOut()
    {
        GameOver.gameObject.SetActive(false);

    }

        public void finalTimeFadeOut()
    {
        remWarning.gameObject.SetActive(false);

    }

    public void colorChange(){
        uiText = uiText.GetComponent<TMP_Text>();
        uiText.color = Color.red;
        uiFill = uiFill.GetComponent<Image>();
        uiFill.color = Color.red;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(7);

    }

    public void failQuest(){
            GameOver.gameObject.SetActive(true);
            CoinCollector.gameObject.SetActive(false);
            GameGUI.gameObject.SetActive(false);
            Globals.gameObject.SetActive(false);
            Invoke("FadeOut", 2);
            Invoke("LoadScene", 3);
            CollectionWin.coinCount = 0;

    }
}
