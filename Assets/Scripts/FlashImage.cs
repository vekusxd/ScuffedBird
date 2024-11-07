using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    Image m_image;
    Coroutine m_currentFlashCoroutine = null;
    private void Awake()
    {
        m_image = GetComponent<Image>();
    }

    public void StartFlash(float sForFlash, float maxAlpha, Color color)
    {
        m_image.color = color;
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        if (m_currentFlashCoroutine != null)
            StopCoroutine(m_currentFlashCoroutine);

        StartCoroutine(Flash(sForFlash, maxAlpha));
    }

    IEnumerator Flash(float sForFlash, float maxAlpha)
    {
        //animate flash in
        float flashDuration = sForFlash / 2;
        for (float t = 0; t <= flashDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = m_image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashDuration);
            m_image.color = colorThisFrame;
            //wait untill next frame crazyh coroutine shit
            yield return null;
        }
        //animate flash out
        for (float t = 0; t <= flashDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = m_image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashDuration);
            m_image.color = colorThisFrame;
            //wait untill next frame crazyh coroutine shit
            yield return null;
        }
        m_image.color = new Color32(0, 0, 0, 0);
    }
}
