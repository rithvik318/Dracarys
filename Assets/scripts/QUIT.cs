using UnityEngine;
using UnityEngine.SceneManagement;

public class QUIT : MonoBehaviour
{
    // This function will be called when the button is pressed
    public void ReturnToMainMenu()
    {
        // Change to the "MainMenu" scene
        SceneManager.LoadSceneAsync(0);
    }
}
