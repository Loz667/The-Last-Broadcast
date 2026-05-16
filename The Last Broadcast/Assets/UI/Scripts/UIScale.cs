using UnityEngine;
using UnityEngine.EventSystems;

public class UIScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Scale Settings")]
    [SerializeField] private float hoverScale = 1.1f;
    [SerializeField] private float animationTime = 0.15f;

    [Header("Tween Settings")]
    [SerializeField] private LeanTweenType easeType = LeanTweenType.easeOutBack;

    private Vector3 originalScale;
    private int currentTweenId = -1;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ScaleButton(originalScale * hoverScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ScaleButton(originalScale);
    }

    private void ScaleButton(Vector3 targetScale)
    {
        // Stops the previous tween so animations do not overlap
        if (currentTweenId != -1)
        {
            LeanTween.cancel(currentTweenId);
        }

        currentTweenId = LeanTween.scale(gameObject, targetScale, animationTime)
            .setEase(easeType)
            .id;
    }
}
