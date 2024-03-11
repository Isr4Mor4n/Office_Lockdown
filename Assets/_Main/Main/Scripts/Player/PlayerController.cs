using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputManager Input;
    NavMeshAgent Agent;

    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    float LookRotationSpeed = 5.0f;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();

        Input = new InputManager();
        AssignInputs();
    }

    void AssignInputs()
    {
        Input.General.Movement.performed += ctx => ClickToMove();
    }

    void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition), out hit, 100, clickableLayers))
        {
            Agent.destination = hit.point;
            if (clickEffect != null)
            { 
                Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); 
            }
        }
    }

    void OnEnable()
    {
        Input.Enable();
    }

    void OnDisable()
    {
        Input.Disable();
    }

    void Update()
    {
        FaceTarget();
    }

    void FaceTarget()
    {
        Vector3 direction = (Agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * LookRotationSpeed);
    }
}