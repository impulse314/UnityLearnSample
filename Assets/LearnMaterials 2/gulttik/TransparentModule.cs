using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[HelpURL("https://docs.google.com/document/d/1Cmm__cbik5J8aHAI6PPaAUmEMF3wAcNo3rpgzsYPzDM/edit?usp=sharing")]
public class TransparentModule : MonoBehaviour
{
    [Header("TransparentМодуль")]


    [SerializeField]
    private float changeSpeed;
    [SerializeField]
    private float defaultAlpha;
    //[SerializeField]
    //private Material mat;
    [SerializeField]
    private bool toDefault;
    Renderer renderer;

    private void Start()
    {
       renderer= GetComponent<Renderer>();
        defaultAlpha = renderer.material.color.a;
        toDefault = false;
    }
    [ContextMenu("Начать настройку прозрачности объектов")]
    public void ActivateModule()
    {
        float target = toDefault ? defaultAlpha : 0;
        StopAllCoroutines();
        StartCoroutine(ChangeTransparencyCoroutine(new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, target)));
        toDefault = !toDefault;
    }

    public void ReturnToDefaultState()
    {
        toDefault = true;
        ActivateModule();
    }
    [SerializeField]
    float t = 0;
    private IEnumerator ChangeTransparencyCoroutine(Color target)
    {
        Color start = renderer.material.color;
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * changeSpeed;
            renderer.material.color = Color.Lerp(start, target, t);
            Debug.Log(renderer.material.color);
            yield return null;
        }
        renderer.material.color = target;
    }
}
