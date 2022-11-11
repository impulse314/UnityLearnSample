using UnityEngine;

namespace LearnMaterials_2.Scripts
{
    public class SampleScriptCall : MonoBehaviour
    {
        [ContextMenu("Активировать модули")]
        public void Use()
        {
            var objects = FindObjectsOfType<SampleScript>();
            foreach (var script in objects)
            {
                script.Use();
            }
        }
    }
}