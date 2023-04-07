using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class TourQuest : MonoBehaviour
{
    public GameObject Tyler;
    public GameObject TylerQB;
    public GameObject Kris;
    public GameObject KrisQB;
    public GameObject Marcus;
    public GameObject MarcusQB;
    public GameObject Susan;
    public GameObject SusanQB;
    public GameObject Catherine;
    public GameObject CatherineQB;

    public GameObject Matthew2;
    public GameObject Matthew2QB;
    public GameObject Matthew;
    public GameObject MatthewQB;

    public GameObject NotePad;

    public GameObject xTyler;
    public GameObject xKris;
    public GameObject xMarcus;
    public GameObject xSusan;
    public GameObject xCatherine;

    public GameObject pressX;
    public GameObject pressC;

    public bool TalkedTyler = false;
    public bool TalkedKris = false;
    public bool TalkedMarcus = false;
    public bool TalkedSusan = false;
    public bool TalkedCatherine = false;

    public bool TalkedMatthew = false;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(TalkedTyler && TalkedKris && TalkedMarcus && TalkedSusan && TalkedCatherine)
        {
            Matthew2On();
        }

        if(Input.GetKey(KeyCode.X))
        {
            if(TalkedMatthew)
            {
                NotePadOn();
                //Time.timeScale = 0f;
                TurnOffPressX();
                TurnOnPressC();
            }
        }

        if(Input.GetKey(KeyCode.C))
        {
            NotePadOff();
            //Time.timeScale = 1f;
            TurnOnPressX();
            TurnOffPressC();

        }

    }

//////////////////////////////////////////////////////////////////////////////////  

    public void TylerOn()
    {
        Tyler.SetActive(true);
    }

    public void TylerQBOff()
    {
        TylerQB.SetActive(false);
    }    

    public void TylerOff()
    {
        TalkedTyler = true;
        xTyler.SetActive(true);
    }

//////////////////////////////////////////////////////////  

    public void KrisOn()
    {
        Kris.SetActive(true);
    }

    public void KrisQBOff()
    {
        KrisQB.SetActive(false);
    }   

    public void KrisOff()
    {
        TalkedKris = true;
        xKris.SetActive(true);
    }

//////////////////////////////////////////////////////////  

    public void MarcusOn()
    {
        Marcus.SetActive(true);
    }

    public void MarcusQBOff()
    {
        MarcusQB.SetActive(false);
    }   

    public void MarcusOff()
    {
        TalkedMarcus = true;
        xMarcus.SetActive(true);
    }

//////////////////////////////////////////////////////////  

    public void SusanOn()
    {
        Susan.SetActive(true);
    }

    public void SusanQBOff()
    {
        SusanQB.SetActive(false);
    }   

    public void SusanOff()
    {
        TalkedSusan = true;
        xSusan.SetActive(true);
    }

//////////////////////////////////////////////////////////  

    public void CatherineOn()
    {
        Catherine.SetActive(true);
    }

    public void CatherineQBOff()
    {
        CatherineQB.SetActive(false);
    }   

    public void CatherineOff()
    {
        TalkedCatherine = true;
        xCatherine.SetActive(true);
    }

//////////////////////////////////////////////////////////  

    public void Matthew2On()
    {
        Matthew2.SetActive(true);
    }

    public void MatthewQBOff()
    {
        MatthewQB.SetActive(false);
    }

    public void Matthew2QBOff()
    {
        Matthew2QB.SetActive(false);
    }   

    public void Matthew2Off()
    {
        Matthew2.SetActive(false);
    }

//////////////////////////////////////////////////////////  

    public void MatthewOn()
    {
        Matthew.SetActive(true);
    }

    public void MatthewOff()
    {
        Matthew.SetActive(false);
    }

//////////////////////////////////////////////////////////

    public void NotePadOn()
    {
        NotePad.SetActive(true);
    }

    public void NotePadOff()
    {
        NotePad.SetActive(false);
    }

//////////////////////////////////////////////////////////

    public void TalkedtoMatthew()
    {
        TalkedMatthew = true;
        TurnOnPressX();
    }
////////////////////////////////////////////////////////
    public void TurnOffPressC()
    {
        pressC.SetActive(false);
    }

    public void TurnOnPressC()
    {
        pressC.SetActive(true);
    }
/////////////////////////////////////////////////////////////
    public void TurnOffPressX()
    {
        pressX.SetActive(false);
    }

    public void TurnOnPressX()
    {
        pressX.SetActive(true);
    }

}