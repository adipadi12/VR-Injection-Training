using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SyringePlunger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform syringe;
    [SerializeField] private AmpouleInteraction ampoule;

    [Header("Syringe Interaction")]
    [SerializeField] private XRGrabInteractable syringeInteractable;

    [Header("Pull Settings")]
    [SerializeField] private float maxPullDistance = 0.12f;

    [Header("Input")]
    [SerializeField] private InputActionReference pullAction;

    public float PullAmount { get; private set; }

    private Vector3 startLocalPosition;

    private void Awake()
    {
        startLocalPosition = transform.localPosition;

        if (syringe == null)
            Debug.LogError("Syringe reference is missing.");

        if (syringeInteractable == null)
            Debug.LogError("Syringe XRGrabInteractable reference is missing.");
    }

    private void OnEnable()
    {
        if (pullAction != null)
            pullAction.action.Enable();
    }

    private void OnDisable()
    {
        if (pullAction != null)
            pullAction.action.Disable();
    }

    int count = 0;
    private void Update()
    {
        if (syringeInteractable == null)
            return;

        // User must be holding the SYRINGE.
        if (!syringeInteractable.isSelected)
            return;

        // Syringe tip must be inside ampoule.
        if (ampoule != null && !ampoule.IsTipInside)
            return;

        if (pullAction == null)
            return;

        float input = pullAction.action.ReadValue<float>();

        // Only pull while input is active.
        if (input <= 0.01f)
            return;

        PullAmount = Mathf.Clamp01(input);

        transform.localPosition =
            startLocalPosition +
            Vector3.up * (PullAmount * maxPullDistance);

        if (PullAmount == 1 && count == 0)
        {
            TrainingManager.Instance.SetStep(TrainingManager.TrainingStep.AimNeedleAtArea);
            count++;
        }
    }
}