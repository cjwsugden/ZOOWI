using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PigDialogue : MonoBehaviour
{

    public GameObject Ranni;
    public GameObject zacConvo2;
    public GameObject zacConvo1;
    public static bool stgg1 = false;
    public static bool stgg2 = false;
    public static bool stgg3 = false;
    public GameObject WolfWin;
    public GameObject WolfConvo1;
    public GameObject WolfConvo3;
    public GameObject WolfConvo5;
    public GameObject WolfConvo7;


    // Start is called before the first frame update
    void Start()
    {



        

    }

    // Update is called once per frame
    void Update()
    {
        if(stgg1 && !stgg2 && !stgg3)
        {
            WolfConvo1.SetActive(false);
            WolfConvo3.SetActive(true);

           // GaryOff();
           // cocoQB.SetActive(true);


        }

        if(!stgg1 && stgg2 && !stgg3)
        {
            WolfConvo1.SetActive(false);
            WolfConvo5.SetActive(true);
           // GaryOff();
           // cocoQB.SetActive(true);
        }

        if(!stgg1 && !stgg2 && stgg3)
        {
            WolfConvo1.SetActive(false);
            WolfConvo7.SetActive(true);
           // GaryOff();
           // cocoQB.SetActive(true);


        }




         stgg1 = false;
         stgg2 = false;
         stgg3 = false;

    }

    public void RanniOn()
    {
        Ranni.SetActive(true);
    }

    public void RanniOff()
    {
        Ranni.SetActive(false);
    }

    public void zacConvo2On(){
        zacConvo2.SetActive(true);
    }

    public void zacConvo2Off(){
        zacConvo2.SetActive(false);
    }


    public void zacConvo1On(){
        zacConvo1.SetActive(true);
    }

    public void zacConvo1Off(){
        zacConvo1.SetActive(false);
    }


    public void pawballOn(){
        SceneManager.LoadScene(15);
    }

        public static void winPawball()
    {
        stgg1 = true;
    }

    public static void losePawball()
    {
        stgg2 = true;
    }

    public static void drawPawball(){
        stgg3 = true;
    }



    



}
