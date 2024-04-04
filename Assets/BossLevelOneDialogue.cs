using UnityEngine;
using TMPro;
using DG.Tweening;

public class BossLevelOneDialogue : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private TMP_Text textComponent;
    private string fullText;
    private bool isTyping = false;
    public TMP_Text textMeshProText;
    public Color transparentColor = new Color(0f, 0f, 0f, 0f);
    public Color blackColor = Color.black;
    private bool isTextTransparent = true;
    public GameObject mControl;
    public bool didNotSpeakYet = true;

    public Transform objectToSlide;
    public float slideDistance = 1f;
    public float duration = 1f;


    void Slide()
    {
        // Calculate the target position for sliding
        Vector3 targetPosition = objectToSlide.position + Vector3.left * slideDistance;

        // Use DOTween to animate the movement
        objectToSlide.DOMove(targetPosition, duration);
    }

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        fullText = textComponent.text;
        textComponent.text = ""; // Clear the text initially

        // Set the initial color of textMeshProText to transparent
        textMeshProText.color = transparentColor;
    }

    public void StartTypewriterEffect()
    {
        if (!isTyping)
        {
            isTyping = true;
            textComponent.text = ""; 
            int totalVisibleCharacters = fullText.Length;
            int visibleCount = 0;
            DOTween.To(() => visibleCount, x => visibleCount = x, totalVisibleCharacters, typingSpeed * totalVisibleCharacters)
                .OnUpdate(() =>
                {
                    textComponent.text = fullText.Substring(0, visibleCount);
                })
                .OnComplete(() => isTyping = false);
        }
    }

    void Update()
    {
        if (mControl != null)
        {
   
            Renderer renderer = mControl.GetComponent<Renderer>();


            if (renderer != null && renderer.material != null)
            {
        
                Color objectColor = renderer.material.color;

                if (objectColor == Color.cyan)
                {
                    if (didNotSpeakYet == true)
                    {
                        textMeshProText.color = blackColor;
                        didNotSpeakYet = false;
                        StartTypewriterEffect();
                    }
                }
            }

        }
    }
    }
