using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using LearnMaterials_2.Scripts;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using JetBrains.Annotations;

public class ScaleDeleteScript : SampleScript
{
    public Transform target;
    //public Vector3 defaultScale;

    [ContextMenu("Активировать модуль")]
    public override void Use()
    {
        StartCoroutine(Call());
    }

    public IEnumerator Call()
    {
        int i = 0;

        GameObject[] allChildren = new GameObject[target.childCount];

        foreach(Transform child in target)
        {
            allChildren[i] = child.gameObject;
            i++;
        }
        foreach (Transform child in target)
        {
            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * 0.01F;
                transform.localScale = Vector3.Lerp(transform.lossyScale, new Vector3(0, 0, 0), t);
                yield return null;
            }
            transform.localScale = new Vector3(0, 0, 0);


        }
        //foreach (GameObject child in allChildren)
        //{
        //    Destroy(child.gameObject);
        //    yield return null;
        //}
    }
}
