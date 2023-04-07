using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public void Advance()
    {
        AdvisingDialogue.alertZon();
        AdvisingDialogue.stage2Complete();
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(2);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(4);
    }

}
