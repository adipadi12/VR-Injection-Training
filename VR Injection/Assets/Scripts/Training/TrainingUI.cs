using TMPro;
using UnityEngine;

public class TrainingUI : MonoBehaviour
{
    [SerializeField] private TrainingManager trainingManager;
    [SerializeField] private TMP_Text instructionText;

    private TrainingManager.TrainingStep lastStep;

    private void Start()
    {
        lastStep = trainingManager.CurrentStep;
        UpdateInstruction(lastStep);
    }

    private void Update()
    {
        if (trainingManager.CurrentStep != lastStep)
        {
            lastStep = trainingManager.CurrentStep;
            UpdateInstruction(lastStep);
        }
    }

    private void UpdateInstruction(TrainingManager.TrainingStep step)
    {
        switch (step)
        {
            case TrainingManager.TrainingStep.Prepare:
                instructionText.text = "Prepare the syringe";
                break;

            case TrainingManager.TrainingStep.DrawMedication:
                instructionText.text = "Draw medication from the ampoule";
                break;

            case TrainingManager.TrainingStep.AimNeedleAtArea:
                instructionText.text = "Aim the needle at the highlighted area";
                break;

            case TrainingManager.TrainingStep.Inject:
                instructionText.text = "Inject";
                break;

            case TrainingManager.TrainingStep.Complete:
                instructionText.text = "Injection complete!";
                break;
        }
    }
}