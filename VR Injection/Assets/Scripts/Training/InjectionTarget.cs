using UnityEngine;

public class InjectionTarget : MonoBehaviour
{
    public bool IsInjected { get; private set; }

    public void Inject()
    {
        if (IsInjected)
            return;

        IsInjected = true;

        Debug.Log("INJECTION SUCCESSFUL");

        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
            renderer.material.color = Color.green;
    }
}