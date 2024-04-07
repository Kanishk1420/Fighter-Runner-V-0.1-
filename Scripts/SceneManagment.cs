using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;
    public AudioSource backgroundMusic; // Add this line

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Start the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    public void LoadMainGameScene()
    {
        StartCoroutine(LoadScene("Main Game"));
    }

    public void LoadSampleScene()
    {
        StartCoroutine(LoadScene("Sample Scene"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("End"); // Trigger the fade-in animation

        yield return new WaitForSeconds(0.4f); // Wait for the animation duration

        SceneManager.LoadSceneAsync(sceneName); // Load the target scene

        transitionAnim.SetTrigger("Start"); // Trigger the fade-out animation
    }
}
