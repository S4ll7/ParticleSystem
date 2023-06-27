using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeMotion : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _privousDirection = 1;
    private float _curentDirection;

    public UnityAction<bool> ChangedDirection;

    private void Move(float movmentPower)
    {
        if (_curentDirection > 0)
        {
            if (_privousDirection < 0)
            {
                ChangedDirection?.Invoke(true);
            }
        }
        else
        {
            if (_privousDirection > 0)
            {
                ChangedDirection?.Invoke(false);
            }
        }
        _privousDirection = movmentPower;
        transform.Translate(new Vector3(_speed * movmentPower * Time.deltaTime, 0, 0));
    }

    private void Update()
    {
        _curentDirection = Input.GetAxis("Horizontal");
        if (_curentDirection != 0)
        {
            Move(_curentDirection);
        }
    }
}
