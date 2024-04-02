using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpecify : MonoBehaviour
{
    private float startTime;
    private bool functionCalled = false;
    public Color targetColor = Color.blue;

    void ChangeMColorWithDelay()
    {
        // Call the original function
        ChangeMColor(targetColor);
    }



    public void ChangeMColor(Color newColor)
    {

        Renderer renderer = gameObject.GetComponent<Renderer>();


        if (renderer != null && renderer.material != null)
        {

            renderer.material.color = newColor;
        }
    }

    private void Start()
    {
        Invoke("ChangeMColorWithDelay", 14f);
    }
}