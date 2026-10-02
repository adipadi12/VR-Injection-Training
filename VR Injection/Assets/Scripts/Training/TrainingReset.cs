using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TrainingReset : MonoBehaviour
{
    [SerializeField] private InputActionReference resetAction;

    private void OnEnable()
    {
        if (resetAction != null)
            resetAction.action.Enable();
    }

    private void OnDisable()
    {
        if (resetAction != null)
            resetAction.action.Disable();
    }

    private void Update()
    {
        if (resetAction != null &&
            resetAction.action.WasPressedThisFrame())
        {
            RestartTraining();
        }
    }

    public void RestartTraining()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.buildIndex);
    }
}