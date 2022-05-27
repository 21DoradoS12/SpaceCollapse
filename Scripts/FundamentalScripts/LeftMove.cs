using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class LeftMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float LeftSide = 0;
    public bool LeftS = false;
    void Start()
    {

    }
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        LeftS = true;
        LeftSide = -0.5f;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        LeftS = false;
        LeftSide = 0;
    }

}