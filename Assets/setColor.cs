using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setColor : MonoBehaviour
{
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
        ChangeMColor(Color.cyan);
    }
}
