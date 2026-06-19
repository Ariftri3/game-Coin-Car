using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadLevel2()
    {
        Time.timeScale = 1;

        Score.coinA = 0;
        Score.storedCoin = 0;
        Timer.timeLeft = 90;

        SceneManager.LoadScene("level 2");
    }
}