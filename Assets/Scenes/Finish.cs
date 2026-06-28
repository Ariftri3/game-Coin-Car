using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winPanel;
    public int targetCoin = 20;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Score.storedCoin >= targetCoin)
            {
                Debug.Log("MENANG!");

                winPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Debug.Log("Coin belum cukup!");
                Debug.Log("Coin sekarang: " + Score.storedCoin + "/" + targetCoin);
            }
        }
    }
}