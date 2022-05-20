using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


public class Sprint : MonoBehaviour
{

    private XROrigin _XROriginRig;
    public float speed = 10.0f;
    [SerializeField] private InputActionReference SprintButtonReference;
    private Rigidbody _body;




    // Start is called before the first frame update
    void Start()
    {
     _XROriginRig = GetComponent<XROrigin>(); //Grabs player rig
        _body = GetComponent<Rigidbody>(); //grabs players rigid body
        SprintButtonReference.action.performed += Run; //Specifies whenevr the action is performed, this function would execute
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Run(InputAction.CallbackContext obj)
    {
      

    }
}
