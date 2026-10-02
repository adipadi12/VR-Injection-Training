using TMPro;
using UnityEngine;

public class TrainingUI : MonoBehaviour
{
    [SerializeField] private TrainingManager trainingManager;
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private TMP_Text subInstructionText;

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
                instructionText.text = "Prepare the syringe.";
                subInstructionText.text = "Go next to the tray and grab the syringe with one hand and ampoule with another such that they're aligned";
                break;

            case TrainingManager.TrainingStep.DrawMedication:
                instructionText.text = "Draw medication from the ampoule";
                subInstructionText.text = "Press V (Keyboard)/ Move Primary2DAxis along Y direction (LeftorRight XR Simulated Controller) to draw medication";
                break;

            case TrainingManager.TrainingStep.AimNeedleAtArea:
                instructionText.text = "Aim the needle at the highlighted area";
                subInstructionText.text = "Take the full syringe to the patient and hover needle above red bump on arm";
                break;

            case TrainingManager.TrainingStep.Inject:
                instructionText.text = "Inject";
                subInstructionText.text = "Press C (Keyboard)/ PrimaryButton(Left or Right XR Controller) to inject patient";
                break;

            case TrainingManager.TrainingStep.Complete:
                instructionText.text = "Injection complete!";
                subInstructionText.text = "Congratulations you completed the training. Feel free to restart by pressing B (Keyboard) / SecondaryButton(LeftHand XR Controller)";
                break;
        }
    }
}