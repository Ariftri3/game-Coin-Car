using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            int coinDisimpan = Score.coinA;

            Score.storedCoin += coinDisimpan;

            Timer.timeLeft += coinDisimpan * 5;

            Score.coinA = 0;

            Debug.Log("Coin tersimpan: " + Score.storedCoin);
        }
    }
}