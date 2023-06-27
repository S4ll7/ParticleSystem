using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesRotator : MonoBehaviour
{
    [SerializeField] private ParticleSystemRenderer _PSR;
    [SerializeField] private CubeMotion _cube;

    private void OnEnable()
    {
        _cube.ChangedDirection += ChangeRotation;
    }

    private void OnDisable()
    {
        _cube.ChangedDirection -= ChangeRotation;
    }

    private void ChangeRotation(bool isLeft)
    {
        Debug.Log("lll");
        if (isLeft)
        {
            _PSR.flip = new Vector3(0, 0, 0);
        }
        else
        {
            _PSR.flip = new Vector3(1, 0, 0); 
        }
    }
}
