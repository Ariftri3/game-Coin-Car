using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;

        Score.coinA = 0;
        Score.storedCoin = 0;

        Timer.timeLeft = 60; // atau 90 untuk level 2

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}