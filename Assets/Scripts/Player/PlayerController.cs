using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{

    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private InputActionReference DashReference;

    private Rigidbody _body;
    private XROrigin _xROrigin;
    private CapsuleCollider _collider;
    private Camera _camera;

    private bool IsGrounded => Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 3.0f), Vector3.down, 3.0f); //Raycast checking if player is grounded (Originally 2.0f)
    // Start is called before the first frame update
    void Start()
    {
        _xROrigin = GetComponent<XROrigin>(); //grabs player rig
        _collider = GetComponent<CapsuleCollider>(); //Grabs player capsule collider
        _body = GetComponent<Rigidbody>(); //grabs players rigid body
        _camera = GetComponent<Camera>(); //Grabs player camera

        jumpActionReference.action.performed += OnJump; //Specifies whenever the action is performed, this function would execute

        DashReference.action.performed += OnDash;
    }

    // Update is called once per frame
    void Update()
    {
       
        var center = _xROrigin.CameraInOriginSpacePos;
        _collider.height = Mathf.Clamp(_xROrigin.CameraInOriginSpaceHeight, 1.0f, 3.0f);
        _collider.center = new Vector3(center.x, _collider.height / 2, center.z);
        var camDir =  Camera.main.transform.forward;
        Vector3 dir = camDir.normalized;
    }
    private void OnJump(InputAction.CallbackContext obj)
    {

        if (!IsGrounded)
        {
            return;
        } //If the player is not grounded, the player cannot jump
        _body.AddForce(Vector3.up * jumpForce); //otherwise, add force to the player going upwards, dictated by the jump force

    }

    private void OnDash(InputAction.CallbackContext obj)
    {
        Vector3 camForward = Camera.main.transform.forward; //Grabs poisiton of the camera's forward direction
        if (!IsGrounded)
        {
            return;
        }
        _body.AddForce(camForward * jumpForce);
    }
}
