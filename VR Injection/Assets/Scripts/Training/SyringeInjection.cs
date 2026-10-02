using UnityEngine;
using UnityEngine.InputSystem;

public class SyringeInjection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SyringePlunger plunger;
    [SerializeField] private TrainingManager trainingManager;

    [Header("Input")]
    [SerializeField] private InputActionReference injectAction;

    private InjectionTarget currentTarget;

    private void OnEnable()
    {
        if (injectAction != null)
            injectAction.action.Enable();
    }

    private void OnDisable()
    {
        if (injectAction != null)
            injectAction.action.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        InjectionTarget target =
            other.GetComponent<InjectionTarget>();

        if (target == null)
            return;

        currentTarget = target;

        Debug.Log("SYRINGE TIP OVER INJECTION TARGET");

        TrainingManager.Instance.SetStep(
            TrainingManager.TrainingStep.Inject
        );
    }

    private void OnTriggerExit(Collider other)
    {
        InjectionTarget target =
            other.GetComponent<InjectionTarget>();

        if (target == currentTarget)
        {
            currentTarget = null;

            Debug.Log("SYRINGE TIP LEFT INJECTION TARGET");
        }
    }

    public void Inject()
    {
        if (currentTarget == null)
        {
            Debug.Log("NO INJECTION TARGET");
            return;
        }

        Debug.Log("INJECTION SUCCESSFUL");

        currentTarget.Inject();

        if (trainingManager != null)
        {
            trainingManager.CompleteStep();
        }

        TrainingManager.Instance.SetStep(
            TrainingManager.TrainingStep.Complete
        );
    }

    private void Update()
    {
        if (currentTarget == null)
            return;

        if (injectAction != null &&
            injectAction.action.WasPressedThisFrame())
        {
            Inject();
        }
    }
}