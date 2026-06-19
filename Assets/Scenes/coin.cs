using UnityEngine;

public class coin : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            Score.coinA++;

            Debug.Log("Coin sekarang = " + Score.coinA);

            Destroy(gameObject);
        }
    }
}