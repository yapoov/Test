using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public PlayerInput playerInput;

    public struct AnimState
    {
        public float forward;
        public float right;

    }
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        playerInput.state.fireEvent += () => _animator.SetTrigger("fire");
        playerInput.state.rollEvent += () => _animator.SetTrigger("roll");
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("forward", playerInput.state.direction.z);
        _animator.SetFloat("right", playerInput.state.direction.x);
        _animator.SetBool("isAiming", playerInput.state.isAiming);

        _animator.SetBool("isRunning", playerInput.state.isRunning);
        // _animator.SetFloat("turn", , -1, 1));
        // print(Input.GetAxis("Mouse X"));
    }
    private void OnAnimatorIK(int layerIndex)
    {
        //foot ik
        // RaycastHit hit;

        // if (Physics.Raycast(_animator.GetBoneTransform(HumanBodyBones.LeftFoot).position + Vector3.up, Vector3.down, out hit, 1.3f, 1 << 6))
        // {
        //     _animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0.9f);
        //     _animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + hit.normal * 0.25f);

        //     // _animator.GetBoneTransform(HumanBodyBones.LeftToes)
        //     // Vector3 forwardVector = Vector3.Cross()

        //     // _animator.SetIKRotation(AvatarIKGoal.LeftFoot,  );
        // }
        // if (Physics.Raycast(_animator.GetBoneTransform(HumanBodyBones.RightFoot).position + Vector3.up, Vector3.down, out hit, 1.3f, 1 << 6))
        // {
        //     _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0.9f);
        //     _animator.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + hit.normal * 0.25f);
        // }

    }
}
