using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public AudioSource backgroundMusic;
    public AudioClip explosionSound;

    private Tween gameOverScreenTween;
    private AudioSource audioSource;
    private bool gameOverSoundPlayed;

    private void Awake()
    {
        isGameOver = false;
        DOTween.SetTweensCapacity(500, 100);
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.volume = 0.5f; // Adjust the volume here
        gameOverSoundPlayed = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            ShowGameOverScreen();
            // backgroundMusic.Stop(); // Comment out this line
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        backgroundMusic.Play();
        gameOverSoundPlayed = false;
    }

    private void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            gameOverScreenTween = gameOverScreen.transform.DOLocalMoveX(0, 0.6f);
            if (!gameOverSoundPlayed)
            {
                audioSource.PlayOneShot(explosionSound);
                gameOverSoundPlayed = true;
            }
        }
    }

    private void OnDestroy()
    {
        gameOverScreenTween?.Kill();
    }
}
