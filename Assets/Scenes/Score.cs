using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;

    public static int coinA = 0;
    public static int storedCoin = 0;

    public static int maxCoin = 10;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text =
            "Coin: " + coinA + "/" + maxCoin +
            "\nStored: " + storedCoin;
    }
}