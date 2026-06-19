using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Score.storedCoin += Score.coinA;

            Timer.timeLeft += Score.coinA * 5;

            Score.coinA = 0;
        }
    }
}