using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
   public static float timeLeft = 60f;

    public GameObject gameOverPanel;

    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        text.text = "Time : " + Mathf.Ceil(timeLeft);

        if(timeLeft <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}