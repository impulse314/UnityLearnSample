using System.Collections;
using UnityEngine;

namespace LearnMaterials_2.Scripts
{
    public class RotationObjectScript : SampleScript
    {
        [Min(0)]
        public float rotationSpeed;
        public float t;
        public float endX;
        public float endY;
        public float endZ;
        private Quaternion startRotation;
        private Quaternion endRotation;

        public void Start()
        {
            startRotation = transform.rotation;
        }

        [ContextMenu("Активировать модуль")]
        public override void Use()
        {
            StartCoroutine(Call());
        }

        public IEnumerator Call()
        {
            startRotation = transform.rotation;
            endRotation = Quaternion.Euler(new Vector3(endX, endY, endZ));
            t = 0;
            while (transform.rotation != endRotation)
            {
                if (t < 1)
                {
                    transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
                    t += Time.deltaTime * rotationSpeed / 100;
                }
                else
                {
                    transform.rotation = endRotation;
                }

                yield return null;
            }
        }
    }
}