using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    public float naturalFrequency;
    public float dampingCoefficent;
    public float initialR;
    public Transform target;
    private Vector3 offset;
    private Rigidbody rb;
    private Rigidbody parentRb;
    private SecondOrderDynamics secondOrderDynamics;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parentRb = target.GetComponent<Rigidbody>();
        offset = target.position - transform.position;
        secondOrderDynamics = new SecondOrderDynamics(naturalFrequency, dampingCoefficent, initialR, target.position - offset);    // baseDist = childRb.position - transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position = secondOrderDynamics.Update(Time.fixedDeltaTime, target.position - offset, Vector3.zero);
    }

}

public class SecondOrderDynamics
{
    private Vector3 xp;
    private Vector3 y, dy;
    private float k1, k2, k3;
    private const float PI = Mathf.PI;

    public SecondOrderDynamics(float f, float z, float r, Vector3 x0)
    {
        k1 = z / (PI * f);
        k2 = 1 / ((2 * PI * f) * (2 * PI * f));
        k3 = r * z / (2 * PI * f);

        xp = x0;
        y = x0;
        dy = Vector3.zero;
    }


    public Vector3 Update(float dt, Vector3 x, Vector3 dx)
    {
        if (dx == Vector3.zero)
        {
            dx = (x - xp) / dt;
            xp = x;
        }
        float k2_stable = Mathf.Max(k2, 1.1f * (dt * dt / 4 + dt * k1 / 2));
        y = y + dt * dy;
        dy = dy + dt * (x + k3 * dx - y - k1 * dy) / k2_stable;
        return y;
    }
}
