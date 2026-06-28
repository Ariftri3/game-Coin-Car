using UnityEngine;
using UnityEngine.EventSystems;

public class GasButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MobileInput.Vertical = 1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MobileInput.Vertical = 0;
    }
}