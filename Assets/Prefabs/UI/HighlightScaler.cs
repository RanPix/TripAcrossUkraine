using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class HighlightScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float scaleOnHighlight;
    [SerializeField] [Min(0.01f)] private float scaleOnHighlightTime;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(scaleOnHighlight, scaleOnHighlightTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, scaleOnHighlightTime);
    }

}
