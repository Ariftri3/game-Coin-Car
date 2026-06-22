using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winPanel;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ada yang masuk Finish");

        if(other.CompareTag("Player"))
        {
            Debug.Log("Player masuk Finish");

            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}