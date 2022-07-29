using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropEquipper : MonoBehaviour
{
    public Transform leftHandSlot;
    public Transform currentItem;
    // Start is called before the first frame update
    void Start()
    {
        currentItem.parent = leftHandSlot;
        currentItem.localPosition = Vector3.zero;

        currentItem.forward = leftHandSlot.forward;
        currentItem.up = leftHandSlot.right;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
