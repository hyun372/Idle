using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour
{
    [ColorUsage(true, true)]
    [SerializeField] private Color flashColor = Color.yellow;
    [SerializeField] private float flashDuration = 0.1f;
    [SerializeField] private AnimationCurve flashSpeedCurve;

    private SpriteRenderer spriteRenderer;
    private Material material;

    private Coroutine hitFlashCoroutine;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Init();
    }

    public void CallHitFlash()
    {
        hitFlashCoroutine= StartCoroutine(HitFlasher());
    }

    private void Init()
    {
        material = spriteRenderer.material;
    }

    private IEnumerator HitFlasher()
    {
        SetFlashColor();

        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while(elapsedTime < flashDuration)
        {
            elapsedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(1f, flashSpeedCurve.Evaluate(elapsedTime), elapsedTime / flashDuration);
            SetFlashAmount(currentFlashAmount);


            yield return null;
        }
    }
    private void SetFlashColor()
    {
        material.SetColor("_FlashColor", flashColor);
    }
    private void SetFlashAmount(float amount)
    {
        material.SetFloat("_FlashAmount", amount);
    }
}
