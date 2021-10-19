using System.Collections;
using UnityEngine;

namespace Tactile.TactileMatch3Challenge.Utils {

    public delegate float EaseFunction(float x);

    public class Tween {

        public static IEnumerator Move(Transform source, Vector3 fromPos, Vector3 toPos, float duration, EaseFunction easeFunction) {

            float t = 0f;
            float v = 0f;
            float timeScale = 1 / duration;
            do {
                v = easeFunction(t);
                t = Mathf.Clamp01(t + Time.deltaTime * timeScale);
                source.position = Vector3.Lerp(fromPos, toPos, v);
                yield return null;
            } while (t < 1f);

            source.position = toPos;
        }
    }

    public static class EaseFunctions {

        public static float EaseOutBounce(float x) {

            const float n1 = 7.5625f;
            const float d1 = 2.75f;

            if (x < 1 / d1) {
                return n1 * x * x;
            } else if (x < 2 / d1) {
                return n1 * (x -= 1.5f / d1) * x + 0.75f;
            } else if (x < 2.5 / d1) {
                return n1 * (x -= 2.25f / d1) * x + 0.9375f;
            } else {
                return n1 * (x -= 2.625f / d1) * x + 0.984375f;
            }
        }
    }
}
