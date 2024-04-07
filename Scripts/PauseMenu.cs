using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] RectTransform pausePanelRect, pauseButtonRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuration;
    [SerializeField] CanvasGroup canvasGroup;

    private Tween pausePanelTween, pauseButtonTween;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        PausePanelIntro();
    }

    public void Home()
    {
        Debug.Log("Home button clicked");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public async void Resume()
    {
        await PausePanelOutro();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    void PausePanelIntro()
    {
        canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
        pausePanelTween = pausePanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
        pauseButtonTween = pauseButtonRect.DOAnchorPosX(1178, tweenDuration).SetUpdate(true);
    }

    async Task PausePanelOutro()
    {
        canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);
        await pausePanelTween.AsyncWaitForCompletion();
        pauseButtonTween = pauseButtonRect.DOAnchorPosX(806.09f, tweenDuration).SetUpdate(true);
    }

    private void OnDestroy()
    {
        pausePanelTween?.Kill(); // Modify this line
        pauseButtonTween?.Kill(); // Modify this line
    }
}
