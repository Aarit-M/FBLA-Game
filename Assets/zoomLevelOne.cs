using UnityEngine;
using DG.Tweening;

public class zoomLevelOne : MonoBehaviour
{
    public Transform squareTransform;
    public Vector3 targetScale;
    public float duration = 1f;

    public void StartScaleTween()
    {
        // Tween the scale of the square element to the target scale
        squareTransform.DOScale(targetScale, duration);
    }

    private void Start()
    {
        Invoke("StartScaleTween", 8f);
    }
}
