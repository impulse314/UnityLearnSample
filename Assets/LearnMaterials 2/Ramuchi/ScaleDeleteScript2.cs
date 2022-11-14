using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using LearnMaterials_2.Scripts;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using JetBrains.Annotations;

public class ScaleDeleteScript2 : SampleScript
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
        for (int j = 0; target.transform.childCount > j; j++)
        {
            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * 0.5F;
                target.GetChild(j).localScale = Vector3.Lerp(target.GetChild(j).localScale, new Vector3(0,0,0), t);
                yield return null;
            }
            target.GetChild(j).localScale = new Vector3(0, 0, 0);
        }
        while (target.transform.childCount > 0)
        {
            int index = Random.Range(0, target.transform.childCount - 1);
            Destroy(target.transform.GetChild(index).gameObject);
            yield return null;
        }
    }
}
