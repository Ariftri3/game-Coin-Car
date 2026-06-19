using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject winPanel;
    public int targetCoin = 20;

    void Update()
    {
        if (Score.storedCoin >= targetCoin)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}