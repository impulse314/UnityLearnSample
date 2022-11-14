using UnityEngine;

namespace LearnMaterials_2.Scripts
{
    public class SampleScriptCall : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
                PrefabsUse();
            if (Input.GetKeyDown(KeyCode.P))
                Use();
        }

        [ContextMenu("Активировать модули")]
        public void Use()
        {
            var objects = FindObjectsOfType<SampleScript>();
            foreach (var script in objects)
            {
                script.Use();
            }
        }

        public void PrefabsUse()
        {
            var transObjects = FindObjectsOfType<TransparentModule>();
            var destrObjects = FindObjectsOfType<DestroyModule>();
            var scaleObjects = FindObjectsOfType<ScalerModule>();
            foreach (var script in transObjects)
                script.ActivateModule();
            foreach (var script in destrObjects)
                script.ActivateModule();
            foreach (var script in scaleObjects)
                script.ActivateModule();
        }
    }
}