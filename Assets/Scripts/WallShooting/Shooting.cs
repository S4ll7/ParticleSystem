using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _shrapnel;
    [SerializeField] private float _sensivity;
    
    private void Update()
    {
        //float xRotation = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * _sensivity;
        //float yRotation = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensivity;

        //transform.localEulerAngles = new Vector3(xRotation, yRotation, transform.localEulerAngles.z);

        if (Input.GetMouseButtonDown(0))
        {

            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, 100f);
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<WallEffector>(out WallEffector wallEffector))
                {
                    GameObject shrapnel = Instantiate(_shrapnel);
                    shrapnel.transform.position = hit.point;
                    Debug.Log(hit.normal);
                    shrapnel.transform.rotation = Quaternion.FromToRotation(shrapnel.transform.up, hit.normal * -1);
                }
            }         
        }
    }
}
