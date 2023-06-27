using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFolower : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private Vector2 _curentMousePosition;
    private Vector3 _curentObjectPosition;

    private void Update()
    {
        // для ортографической камеры
        //_curentMousePosition = _mainCamera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        //_curentObjectPosition = new Vector3(_curentMousePosition.x, _curentMousePosition.y, 0);
        //transform.position = _curentObjectPosition;

        // для камеры перспективы
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        _curentObjectPosition = ray.GetPoint(10);
        transform.position = _curentObjectPosition;
    }
}
