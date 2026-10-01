using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SyringePlunger : MonoBehaviour
{
    [SerializeField] private Transform syringe;
    [SerializeField] private float maxPullDistance = 0.12f;

    private XRBaseInteractable interactable;

    private Vector3 startLocalPosition;
    private float controllerStartY;

    private bool isGrabbed;

    public float PullAmount { get; private set; }

    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();

        if (syringe == null)
            Debug.LogError("Syringe reference is missing on SyringePlunger.");

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
        isGrabbed = true;

        startLocalPosition = transform.localPosition;

        Transform interactor = args.interactorObject.transform;

        Vector3 localControllerPosition =
            syringe.InverseTransformPoint(interactor.position);

        controllerStartY = localControllerPosition.y;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }

    private void Update()
    {
        if (!isGrabbed || syringe == null)
            return;

        Transform interactor =
            interactable.firstInteractorSelecting.transform;

        Vector3 localControllerPosition =
            syringe.InverseTransformPoint(interactor.position);

        float displacement =
            localControllerPosition.y - controllerStartY;

        displacement = Mathf.Clamp(
            displacement,
            0f,
            maxPullDistance
        );

        transform.localPosition =
            startLocalPosition + Vector3.up * displacement;

        PullAmount = displacement / maxPullDistance;
    }
}