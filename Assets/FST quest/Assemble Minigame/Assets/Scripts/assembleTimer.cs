using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class assembleTimer : MonoBehaviour
{

    public TMP_Text uiText;
    //public RectTransform fxHolder;
    public GameObject GameOver;
    public GameObject UI;


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
                //uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                //fxHolder.rotation = Quaternion.Euler (new Vector3 (0f, 0f, -remainingDuration * 360));
                remainingDuration--;
                yield return new WaitForSeconds(1f);

                 if(remainingDuration == 10){
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

   public void LoadScene()
    {
        SceneManager.LoadScene(8);

    }


    public void colorChange(){
        uiText = uiText.GetComponent<TMP_Text>();
        uiText.color = Color.red;
    }


    public void failQuest(){
            GameOver.gameObject.SetActive(true);
            Invoke("FadeOut", 2);
            Invoke("LoadScene", 2);

    }
}
