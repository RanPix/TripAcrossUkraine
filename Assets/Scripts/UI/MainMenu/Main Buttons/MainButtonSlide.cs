using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MainButtonSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float slideValue;
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOMoveX(transform.parent.position.x + slideValue, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOMoveX(transform.parent.position.x, 0.1f);
    }
}
