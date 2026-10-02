using UnityEngine;


public class TrainingManager : MonoBehaviour
{
    public static TrainingManager Instance { get; private set; }
    public enum TrainingStep
    {
        Prepare,
        DrawMedication,
        AimNeedleAtArea,
        Inject,
        Complete
    }

    void Awake()
    {
        if(Instance == null) Instance = this;
    }

    [Header("Current Step")]
    [SerializeField] private TrainingStep currentStep = TrainingStep.Prepare;

    public TrainingStep CurrentStep => currentStep;

    public void SetStep(TrainingStep step)
    {
        currentStep = step;

        Debug.Log("TRAINING STEP: " + currentStep);
    }

    public TrainingStep GetStep()
    {
        return currentStep;
    }

    public void CompleteStep()
    {
        switch (currentStep)
        {
            case TrainingStep.Prepare:
                SetStep(TrainingStep.DrawMedication);
                break;

            case TrainingStep.DrawMedication:
                SetStep(TrainingStep.Inject);
                break;

            case TrainingStep.AimNeedleAtArea:
                SetStep(TrainingStep.Inject);
                break;
                
            case TrainingStep.Inject:
                SetStep(TrainingStep.Complete);
                break;
        }
    }
}
