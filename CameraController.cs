using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform followTf;
    public float smoothTime;
    Vector3 _velocity;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position-followTf.position;
    }



    // Update is called once per frame
    void LateUpdate()
    {

        if(!followTf) return;


        float mouseX =  Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        

        transform.GetChild(0).localRotation=Quaternion.Euler(-mouseY,0,0)* transform.GetChild(0).localRotation;
        transform.rotation = Quaternion.Euler(0,mouseX,0)*transform.rotation;
        transform.position = followTf.position + transform.rotation*offset;

        // transform.position = Vector3.SmoothDamp(transform.position,followTf.position + offset,ref _velocity,smoothTime);
    }
}
