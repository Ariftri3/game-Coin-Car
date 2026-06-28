using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1;

        // Reset score
        Score.coinA = 0;
        Score.storedCoin = 0;

        // Reset timer
        Timer.timeLeft = 90f; // sesuaikan dengan waktu awal level

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}