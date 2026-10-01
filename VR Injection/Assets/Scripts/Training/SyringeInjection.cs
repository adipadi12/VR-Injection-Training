using UnityEngine;
using UnityEngine.InputSystem;

public class SyringeInjection : MonoBehaviour
{
    [SerializeField] private SyringePlunger plunger;

    private InjectionTarget currentTarget;

    private void OnTriggerEnter(Collider other)
    {
        InjectionTarget target =
            other.GetComponent<InjectionTarget>();

        if (target == null)
            return;

        currentTarget = target;

        Debug.Log("SYRINGE TIP OVER INJECTION TARGET");
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

        currentTarget.Inject();
    }

    private void Update()
    {
        if (currentTarget != null &&
            Keyboard.current.iKey.wasPressedThisFrame)
        {
            Inject();
        }
    }
}