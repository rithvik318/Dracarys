using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackButton : MonoBehaviour
{
    // This function will be called when the button is pressed
    public void GoBackToMainMenu()
    {
        // Change to the "MainMenu" scene
        SceneManager.LoadSceneAsync(0);
    }
}
