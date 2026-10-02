using UnityEngine;

public class AmpouleInteraction : MonoBehaviour
{
    [SerializeField] private Transform opening;
    [SerializeField] private Transform syringeTip;

    [SerializeField] private float insertionDistance = 0.08f;

    public bool IsTipInside { get; private set; }
    int count = 0;
    private void Update()
    {
        if (opening == null || syringeTip == null)
            return;

        float distance = Vector3.Distance(
            opening.position,
            syringeTip.position
        );

        bool previousState = IsTipInside;

        IsTipInside = distance <= insertionDistance;

        if (IsTipInside != previousState)
        {
            Debug.Log(
                IsTipInside
                    ? "SYRINGE TIP INSERTED"
                    : "SYRINGE TIP REMOVED"
            );
        }

        if(IsTipInside && count == 0)
        {
            count++;
            TrainingManager.Instance.SetStep(TrainingManager.TrainingStep.DrawMedication);
        }
    }
}