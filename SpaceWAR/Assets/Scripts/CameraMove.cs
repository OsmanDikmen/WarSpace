using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform parent; 
    [SerializeField] private float mouseSensetiviti;

    void Start()
    {
        parent = transform.parent;
        //Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        Rotate(); 
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetiviti * Time.deltaTime;
        parent.Rotate(Vector3.up, mouseX);
    }
}
