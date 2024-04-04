using UnityEngine;
using DG.Tweening;
using TMPro;

public class SlideToLeft : MonoBehaviour
{
    public Transform objectToSlide;
    public TextMeshProUGUI textToFade;
    public float fadeDuration = 1f;
    public float targetAlpha = 0f;
    public float slideDistance = 1f;
    public float duration = 1f;

    void Start()
    {
        // Slide both objects to the left
        Invoke("SlideAndFade", 8f);
    }

    void SlideAndFade()
    {
        Fade();
        Slide();
    }

    void Slide()
    {
        // Calculate the target position for sliding the regular GameObject
        Vector3 targetPosition = objectToSlide.position + Vector3.left * slideDistance;

        // Use DOTween to animate the movement of the regular GameObject
        objectToSlide.DOMove(targetPosition, duration);
    }

    void Fade()
    {
        // Use DOTween to animate the alpha value of TMP text
        textToFade.DOFade(targetAlpha, fadeDuration);
    }
}
