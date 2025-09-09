using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        
    }

}
