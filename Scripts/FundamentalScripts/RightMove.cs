using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RightMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float RightSide = 0;
    public bool RightS = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        RightS = true;
        RightSide = 0.5f;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        RightS = false;
        RightSide = 0;
    }

}
