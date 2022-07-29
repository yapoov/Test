using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public PlayerInput playerInput;
    public Rigidbody rb;
    public float runSpeed;
    public float walkSpeed;
    private Transform child;
    // public Rigidbody childRb;

    Vector3 groundNormal;
    Vector3 prevVel;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = playerInput.state.direction; ;

        float speed = playerInput.state.isRunning ? runSpeed : walkSpeed;
        if (dir.magnitude > 1)
            dir = dir.normalized;

        var vel = rb.velocity;

        float vertical = vel.y;
        vel = Vector3.ProjectOnPlane(Camera.main.transform.TransformDirection(dir) * speed, Vector3.up);
        vel.y = vertical;
        // rb.rotation = Quaternion.LookRotation(Camera.main.transform.TransformDirection(dir));
        rb.velocity = vel;


        Vector3 forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        // forward.y = -vel.y;
        if (dir.magnitude > 0.1f)
            child.rotation = Quaternion.Slerp(child.rotation, Quaternion.LookRotation(forward), Time.deltaTime * 5);

        // if (dir.magnitude > 0.1f)
        // {
        // Quaternion targetRotation = Quaternion.LookRotation(rb.velocity);
        // child.rotation = Quaternion.Slerp(child.rotation, targetRotation, Time.deltaTime * 5);
        // }
        // Vector3 acceleration = (vel - prevVel) / Time.deltaTime;
        // if (acceleration.magnitude > 1f)
        //     child.rotation = Quaternion.Euler(Mathf.Clamp(acceleration.magnitude * Vector3.Dot(acceleration, child.forward) * 0.1f, 0, 30), 0, 0) * child.rotation;
        prevVel = vel;
    }


    // void CheckGround()
    // {
    //     RaycastHit hit;
    //     if (Physics.SphereCast(transform.position, 0.2f, Vector3.down, out hit, 10, 1 << 7))
    //     {
    //         groundNormal = hit.normal;
    //     }
    // }
}
