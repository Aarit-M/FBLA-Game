using UnityEngine;
using TMPro;
using DG.Tweening;

public class DiaScript : MonoBehaviour
{
    public GameObject mControl;
    public GameObject boss;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void DetectAndHandleColor(Color targetColor)
    {

        Renderer renderer = mControl.GetComponent<Renderer>();


        if (renderer != null && renderer.material != null)
        {

            Color objectColor = renderer.material.color;


            if (objectColor == targetColor)
            {
                gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        DetectAndHandleColor(Color.cyan);
    }
}
