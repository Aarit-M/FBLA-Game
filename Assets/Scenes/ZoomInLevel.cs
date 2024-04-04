using UnityEngine;
using DG.Tweening;

public class ZoomInLevel : MonoBehaviour
{
    public Transform squareTransform; // Reference to the square's transform
    public float zoomDuration = 1f; // Duration of zoom animation
    public float finalScale = 2f; // Final scale of the square after zooming

    void Start()
    {
        // Check if the square transform is assigned
        if (squareTransform == null)
        {
            Debug.LogError("Square Transform is not assigned!");
            return;
        }

        // Set the initial scale of the square to 1
        squareTransform.localScale = Vector3.one;

        // Zoom in animation using DOTween
        squareTransform.DOScale(finalScale, zoomDuration);
    }
}
