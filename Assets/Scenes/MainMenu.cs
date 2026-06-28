using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject tutorialPanel;

    void Start()
    {
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
    }

    public void StartGame()
    {
        Score.coinA = 0;
        Score.storedCoin = 0;
        Timer.timeLeft = 90;

        SceneManager.LoadScene("level 1");
    }

    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Keluar Game");
    }
}