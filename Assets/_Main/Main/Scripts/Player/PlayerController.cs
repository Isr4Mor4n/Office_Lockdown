using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    InputManager input;
    NavMeshAgent agent;

    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    float lookRotationSpeed = 5.0f;
    Vector3 pausedDestination;
    bool isPaused = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        input = new InputManager();
        AssignInputs();
    }

    void AssignInputs()
    {
        input.General.Movement.performed += ctx => ClickToMove(ctx);
    }

    void ClickToMove(InputAction.CallbackContext context)
    {
        if (isPaused || EventSystem.current.IsPointerOverGameObject())
            return;

        Vector2 screenPosition = Vector2.zero;
        if (context.control.device is Touchscreen && context.control is TouchControl)
        {
            TouchControl touch = (TouchControl)context.control;
            screenPosition = touch.position.ReadValue();
        }
        else if (Mouse.current != null)
        {
            screenPosition = Mouse.current.position.ReadValue();
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayers))
        {
            agent.SetDestination(hit.point);
            pausedDestination = Vector3.zero;
            if (clickEffect != null)
            {
                var effectInstance = Instantiate(clickEffect, hit.point + Vector3.up * 0.1f, Quaternion.identity);
                Destroy(effectInstance.gameObject, 0.5f);
            }
        }
    }

    void OnEnable()
    {
        input.Enable();
        PauseManager.OnGamePaused += HandleGamePaused;
        PauseManager.OnGameResumed += HandleGameResumed;
    }

    void OnDisable()
    {
        input.Disable();
        PauseManager.OnGamePaused -= HandleGamePaused;
        PauseManager.OnGameResumed -= HandleGameResumed;
    }

    void Update()
    {
        FaceTarget();
    }

    void FaceTarget()
    {
        if (agent.hasPath)
        {
            Vector3 direction = (agent.destination - transform.position).normalized;
            if (direction.magnitude > 0.1f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
            }
        }
    }

    void HandleGamePaused()
    {
        isPaused = true;
        if (agent.pathPending || agent.hasPath)
        {
            pausedDestination = agent.destination;
            agent.ResetPath();
        }
    }

    void HandleGameResumed()
    {
        isPaused = false;
        if (pausedDestination != Vector3.zero)
        {
            agent.SetDestination(pausedDestination);
        }
    }
}