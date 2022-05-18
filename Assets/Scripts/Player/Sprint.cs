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
    public float speed = 3.0f;
    [SerializeField] private InputActionReference SprintButton;


    // Start is called before the first frame update
    void Start()
    {
     _XROriginRig = GetComponent<XROrigin>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Run()
    {
        if (!)
    }
}
