using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ObstacleItem : MonoBehaviour
{
    private Renderer rend;
    private float changeSpeed = 0.2f;

    [Range(0f, 1f)]
    public float currentValue;
    private static float damage = 0.005f;

    //[SerializeField]
    private UnityEvent onDestroyObstacle;

    [SerializeField]
    [ContextMenu("Сделать дамаг")]
    public void GetDamage()//float value
    {
        currentValue -= damage;
        StartCoroutine(PressCorroutine(changeSpeed));
        //Debug.Log("Значение жизей: " + currentValue);


    }
    private IEnumerator PressCorroutine(float speed)
    {
        float t = 0;
        Color currentColor = transform.GetComponent<Renderer>().material.color;

        while (t < 1)
        {
            t += speed * Time.deltaTime;
            if (currentValue >= 0.7f && currentValue < 0.9f)
            {
                transform.GetComponent<Renderer>().material.color = Color.Lerp(currentColor, new Color32(255, 208, 208, 255), t);
            }
            else if (currentValue >= 0.3f && currentValue < 0.7f)
            {
                transform.GetComponent<Renderer>().material.color = Color.Lerp(currentColor, new Color32(255, 132, 132, 255), t);
            }
            else if (currentValue > 0.0001f && currentValue < 0.3f)
            {
                transform.GetComponent<Renderer>().material.color = Color.Lerp(currentColor, new Color32(255, 57, 57, 255), t);
            }
            else if(currentValue <= 0.01f)
            {
                onDestroyObstacle.Invoke();
                //Debug.Log("Мы зашли в убийство!!!!");
            }
            yield return null;
        }
    }
    void Start()
    {
        onDestroyObstacle = new UnityEvent();
        onDestroyObstacle.AddListener(() => Destroy(gameObject, 1));
    }
}
