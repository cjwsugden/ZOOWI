using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartQuest : MonoBehaviour
{
    public GameObject gameObjects;
    public GameObject gameGUI;
    public GameObject Globals;

    public void Update(){
    gameObjects.SetActive(true);
    gameGUI.SetActive(true);
    Globals.SetActive(true);

}

}
