using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // This method will be called to quit the game
    public void Exit()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor, so if we are in the editor, we stop playing
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application
        Application.Quit();
#endif
    }
}
