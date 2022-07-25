using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public float TotalTime;
    public float Scale;
    // Start is called before the first frame update
    void Start()
    {
        //Scale = transform.localScale;
        StopAllCoroutines();
        StartCoroutine(ScaleWithCurve(animationCurve));
    }
    IEnumerator ScaleWithCurve(AnimationCurve Curve)
    {
        float time = 0;
        
        while (time < TotalTime)
        {
            float normalizedTime = time / TotalTime;
            float sampleRate = Curve.Evaluate(normalizedTime);
            transform.localScale= (sampleRate * Scale) * Vector3.one;
           
            time += Time.deltaTime;
            yield return null;
        }
    }
}
