using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SyringePlunger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform syringe;
    [SerializeField] private AmpouleInteraction ampoule;

    [Header("Pull Settings")]
    [SerializeField] private float maxPullDistance = 0.12f;

    public float PullAmount { get; private set; }

    public bool IsFullyPulled =>
        PullAmount >= 0.99f;

    public bool IsFullyReleased =>
        PullAmount <= 0f;
        
    private XRBaseInteractable interactable;

    private Vector3 startLocalPosition;
    private float controllerStartY;

    private bool isGrabbed;

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();

        if (syringe == null)
            Debug.LogError("Syringe reference is missing.");

        startLocalPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnGrab);
        interactable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("PLUNGER GRABBED");

        isGrabbed = true;

        startLocalPosition = transform.localPosition;

        Transform interactor = args.interactorObject.transform;

        Vector3 localPosition =
            syringe.InverseTransformPoint(interactor.position);

        controllerStartY = localPosition.y;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("PLUNGER RELEASED");

        isGrabbed = false;
    }

    private void Update()
    {
        if (!isGrabbed)
            return;

        // Only allow actual pulling when the needle is inside the ampoule.
        if (ampoule != null && !ampoule.IsTipInside)
            return;

        if (interactable.firstInteractorSelecting == null)
            return;

        Transform interactor =
            interactable.firstInteractorSelecting.transform;

        Vector3 localPosition =
            syringe.InverseTransformPoint(interactor.position);

        float displacement =
            localPosition.y - controllerStartY;

        displacement = Mathf.Clamp(
            displacement,
            0f,
            maxPullDistance
        );

        transform.localPosition =
            startLocalPosition + Vector3.up * displacement;

        PullAmount =
            displacement / maxPullDistance;

        Debug.Log($"Pull Amount: {PullAmount:F2}");
    }
}