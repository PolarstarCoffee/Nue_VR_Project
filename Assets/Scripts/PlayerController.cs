using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{

    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500.0f;
    
    private Rigidbody _body;
    private XROrigin _xROrigin;
    private CapsuleCollider _collider;


    private bool IsGrounded => Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 2.0f), Vector3.down, 2.0f); //Raycast checking if player is grounded 
    // Start is called before the first frame update
    void Start()
    {
        _xROrigin = GetComponent<XROrigin>();
        _collider = GetComponent<CapsuleCollider>();
        _body = GetComponent<Rigidbody>(); //grabs players rigid body
        jumpActionReference.action.performed += OnJump; //Specifies whenever the action is performed, this function would execute
    }

    // Update is called once per frame
    void Update()
    {
        var center = _xROrigin.CameraInOriginSpacePos;
        _collider.height = Mathf.Clamp(_xROrigin.CameraInOriginSpaceHeight, 1.0f, 3.0f);
        _collider.center = new Vector3(center.x, _collider.height / 2, center.z);
    }
    private void OnJump(InputAction.CallbackContext obj)
    {

        if (!IsGrounded)
        {
            return;
        } //If the player is not grounded, the player cannot jump
        _body.AddForce(Vector3.up * jumpForce); //otherwise, add force to the player going upwards, dictated by the jump force

    }
}
