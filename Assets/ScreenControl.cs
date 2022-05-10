using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private Image _pivot;
    private Vector2 _touchPoint;
    public Vector2 _direction;

    private void Awake()
    {
        _pivot.enabled = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 vecDif = eventData.position - _touchPoint;
        _direction = vecDif.normalized;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPoint = eventData.position;
        _pivot.enabled = true;
        _pivot.transform.position = _touchPoint;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _direction = Vector2.zero;
        _pivot.enabled = false;
    }
}
