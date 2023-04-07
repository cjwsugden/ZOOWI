using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGChanger : MonoBehaviour
{

  [SerializeField] public Image image1;
 [SerializeField]  public  Image image2;
[SerializeField]  public   Image image3;
 [SerializeField]  public  Image image4;
[SerializeField]  public   Image image5;
[SerializeField]   public  Image image6;
 [SerializeField]  public  Image image7;
 [SerializeField] public   Image image8;
 [SerializeField]  public  Image image9;
  [SerializeField] public  Image image10;
 [SerializeField]  public  Image image11;
[SerializeField]   public  Image image12;


  public bool transition = false;

  float m_TimeLoadEndGameScene;

  public float EndSceneLoadDelay = 2f;

  public CanvasGroup EndGameFadeCanvasGroup;

  int randomNumber;

  public GameObject intUI;

    // Start is called before the first frame update
    void Start()
    {
        image1.enabled = true;
        image2.enabled = false;
        image3.enabled = false;
        image4.enabled = false;
       image5.enabled = false;
       image6.enabled = false;
       image7.enabled = false;
       image8.enabled = false;
       image9.enabled = false;
       image10.enabled = false;
       image11.enabled = false;
       image12.enabled = false;


        InvokeRepeating("randomPic",0,8);
    }

    // Update is called once per frame
    void Update()
    {
      if (transition)
            {
                float timeRatio = 1 - (m_TimeLoadEndGameScene - Time.time) / EndSceneLoadDelay;
                EndGameFadeCanvasGroup.alpha = timeRatio;

                // See if it's time to load the end scene (after the delay)
                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 1)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = true;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                ///////////////////////////////////////////////////////////

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 2)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = true;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 3)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = false;
                    image3.enabled = true;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 4)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = true;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 5)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = true;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 6)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = true;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 7)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = true;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 8)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = true;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 9)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = true;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 10)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = true;
                    image11.enabled = false;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 11)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = true;
                    image12.enabled = false;
                }

                if (Time.time >= m_TimeLoadEndGameScene && randomNumber == 12)
                {
                    transition = false;
                    EndGameFadeCanvasGroup.gameObject.SetActive(false);
                    image1.enabled = false;
                    image2.enabled = false;
                    image3.enabled = false;
                    image4.enabled = false;
                    image5.enabled = false;
                    image6.enabled = false;
                    image7.enabled = false;
                    image8.enabled = false;
                    image9.enabled = false;
                    image10.enabled = false;
                    image11.enabled = false;
                    image12.enabled = true;
                }


            }
        
        
    }

    int randomPic(){
        randomNumber = Random.Range(1, 13);

        if(randomNumber == 1){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 2){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 2){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 3){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 4){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 5){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 6){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 7){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 8){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 9){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 10){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 11){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }

        if(randomNumber == 12){

          transition = true;
          EndGameFadeCanvasGroup.gameObject.SetActive(true);
          m_TimeLoadEndGameScene = Time.time + EndSceneLoadDelay;          
        }
        

        


        return randomNumber;
    }

    public void showInt()
    {
      intUI.SetActive(true);
    }

    public void hideInt()
    {
      intUI.SetActive(false);
    }
}
