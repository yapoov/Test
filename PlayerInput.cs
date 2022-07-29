using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [System.Serializable]
    public struct InputState
    {
        public Vector3 direction;

        public bool isAiming;
        public bool isRunning;
        public System.Action fireEvent;
        public System.Action rollEvent;

    }
    public InputState state;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.z = Input.GetAxis("Vertical");
        dir.x = Input.GetAxis("Horizontal");

        state.direction = dir;


        state.isAiming = Input.GetMouseButton(1);


        state.isRunning = !Input.GetKey(KeyCode.LeftAlt) && !state.isAiming;

        if (state.isAiming)
        {
            if (Input.GetMouseButton(0))
            {

            }
            if (Input.GetMouseButtonUp(0))
            {
                state.fireEvent?.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state.rollEvent?.Invoke();
        }
        // if()
    }
}
