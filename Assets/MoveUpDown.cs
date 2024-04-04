using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class MoveUpDown : MonoBehaviour
{
    public float moveDistance = 1f; // Distance to move up and down
    public float moveDuration = 1f; // Duration of each move
    public GameObject mControl;

    void Start()
    {
        // Call the MoveLoop function to start the movement loop
        MoveLoop();
    }

    public void ChangeMColor(Color newColor)
    {

        Renderer renderer = mControl.GetComponent<Renderer>();


        if (renderer != null && renderer.material != null)
        {

            renderer.material.color = newColor;
        }
    }

    private void OnMouseDown()
    {
        ChangeMColor(Color.yellow);
    }
    void MoveLoop()
    {
        // Move the GameObject up
        transform.DOMoveY(transform.position.y + moveDistance, moveDuration)
                 .SetEase(Ease.InOutQuad)
                 .OnComplete(() =>
                 {
                     // Once the movement up is complete, move the GameObject down
                     transform.DOMoveY(transform.position.y - moveDistance, moveDuration)
                              .SetEase(Ease.InOutQuad)
                              .OnComplete(() =>
                              {
                                  // After moving down, call the MoveLoop function recursively to continue the loop
                                  MoveLoop();
                              });
                 });
    }
}
