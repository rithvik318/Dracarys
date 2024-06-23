using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    // This function will be called when the button is pressed
    public void GoToHowToPlay()
    {
        // Change to the "MainMenu" scene
        SceneManager.LoadSceneAsync(2);
    }
}
