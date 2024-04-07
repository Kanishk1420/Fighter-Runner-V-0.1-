using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main Game"); // Replace "MainGameScene" with the actual name of your main game scene
    }
}
