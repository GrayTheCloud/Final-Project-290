using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
    }
    public void PlayGame()
    {
        audioSource.Stop();
        SceneManager.LoadScene("Main Terrain");
    }

    public void QuitGame()
    {
        audioSource.Stop();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

