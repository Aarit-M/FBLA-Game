using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ReadyUpFade : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public GameObject mControl;



    private void Update()
    {
        DetectAndHandleColor(Color.yellow);
    }

    public void DetectAndHandleColor(Color targetColor)
    {

        Renderer renderer = mControl.GetComponent<Renderer>();


        if (renderer != null && renderer.material != null)
        {

            Color objectColor = renderer.material.color;


            if (objectColor == targetColor)
            {
                FadeOut();
            }
        }
    }

    public void FadeOut()
    {
        DOTween.ToAlpha(() => GetComponent<Renderer>().material.color,
                        color => GetComponent<Renderer>().material.color = color,
                        0.0f, fadeDuration)
               .OnComplete(LoadNextScene);
    }

    void LoadNextScene()
    {
        // Replace "SceneName" with the name of your next scene
        SceneManager.LoadScene("LevelOne");
    }
}
