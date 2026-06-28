using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MobileInput.Brake = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MobileInput.Brake = false;
    }
}