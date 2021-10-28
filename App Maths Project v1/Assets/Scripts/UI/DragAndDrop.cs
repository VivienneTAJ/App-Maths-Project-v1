using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
    }
    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y = 0;
        return mousePos;
    }
}
