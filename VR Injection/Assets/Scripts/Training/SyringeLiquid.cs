using UnityEngine;

public class SyringeLiquid : MonoBehaviour
{
    [SerializeField] private SyringePlunger plunger;

    [Header("Fill")]
    [SerializeField] private float minHeight = 0.01f;
    [SerializeField] private float maxHeight = 0.08f;

    private Vector3 initialScale;
    private Vector3 initialPosition;

    private void Start()
    {
        initialScale = transform.localScale;
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (plunger == null)
            return;

        float fill = plunger.PullAmount;

        float height = Mathf.Lerp(
            minHeight,
            maxHeight,
            fill
        );

        Vector3 scale = initialScale;
        scale.y = height;

        transform.localScale = scale;

        // Keep the bottom of the liquid fixed.
        float halfHeight = height * 0.5f;

        Vector3 position = initialPosition;
        position.y = initialPosition.y - (maxHeight - height) * 0.5f;

        transform.localPosition = position;
    }
}