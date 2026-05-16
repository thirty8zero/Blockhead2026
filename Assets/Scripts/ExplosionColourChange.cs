using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class EmissionFlareAndColorFade : MonoBehaviour
{
    private Renderer rend;
    private MaterialPropertyBlock propBlock;

    [Header("Shader Properties")]
    public string baseColorProperty = "_BaseColor";   // "_Color" for Standard
    public string emissionProperty = "_EmissionColor";

    [Header("Emission Settings")]
    public Color flareEmissionColor = Color.blue;
    public float flareIntensity = 5f;
    public float flareDuration = 0.2f;
    public float holdDuration = 0.1f;

    [Header("Color Fade Settings")]
    public float fadeDuration = 1f;
    public Color[] possibleColors = new Color[4];

    private Color currentColor;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        propBlock = new MaterialPropertyBlock();

        rend.sharedMaterial.EnableKeyword("_EMISSION");

        //rend.GetPropertyBlock(propBlock);
        //currentColor = propBlock.GetColor(baseColorProperty);
        if (rend.sharedMaterial.HasProperty(baseColorProperty))
            currentColor = rend.sharedMaterial.GetColor(baseColorProperty);
        //if (currentColor == default)
        else
            currentColor = Color.white;
    }

    void Start()
    {
        //GetComponent<EmissionFlareAndColorFade>().TriggerEffect();
        TriggerEffect();
    }

    public void TriggerEffect()
    {
        StopAllCoroutines();
        StartCoroutine(FlareSequence());
    }

    private IEnumerator FlareSequence()
    {
        rend.GetPropertyBlock(propBlock);

        // 🔥 Flare emission
        Color emissionColor = flareEmissionColor * flareIntensity;
        propBlock.SetColor(emissionProperty, emissionColor);
        rend.SetPropertyBlock(propBlock);

        yield return new WaitForSeconds(flareDuration);

        // ⬛ Turn emission off
        // propBlock.SetColor(emissionProperty, Color.black);
        // rend.SetPropertyBlock(propBlock);

        // yield return new WaitForSeconds(holdDuration);

        float fadeTime = 0f;
        Color startEmission = flareEmissionColor * flareIntensity;

        while (fadeTime < fadeDuration)
        {
            fadeTime += Time.deltaTime;
            float t = fadeTime / flareDuration;

            Color emission = Color.Lerp(startEmission, Color.black, t);

            propBlock.SetColor(emissionProperty, emission);
            rend.SetPropertyBlock(propBlock);

            yield return null;

            // propBlock.SetColor(emissionProperty, Color.black);
            // rend.SetPropertyBlock(propBlock);

            // yield return new WaitForSeconds(holdDuration);
        }

        propBlock.SetColor(emissionProperty, Color.black);
        rend.SetPropertyBlock(propBlock);

        yield return new WaitForSeconds(holdDuration);

        // 🎨 Pick random target color
        if (possibleColors.Length == 0) yield break;
        Color targetColor = possibleColors[Random.Range(0, possibleColors.Length)];

        // 🌈 Fade to target
        float time = 0f;
        Color startColor = currentColor;

        // float fadeTime = 0f;
        // Color startEmission = flareEmissionColor * flareIntensity;


        while (time < fadeDuration)
        {
            // fadeTime += Time.deltaTime;
            // float t = fadeTime / flareDuration;

            // Color emission = Color.Lerp(startEmission, Color.black, t);

            // propBlock.SetColor(emissionProperty, emission);
            // rend.SetPropertyBlock(propBlock);

            // yield return null;

            time += Time.deltaTime;
            float t = time / fadeDuration;

            currentColor = Color.Lerp(startColor, targetColor, t);

            //rend.GetPropertyBlock(propBlock);
            propBlock.SetColor(baseColorProperty, currentColor);
            rend.SetPropertyBlock(propBlock);

            yield return null;
        }


        currentColor = targetColor;
    }
}
