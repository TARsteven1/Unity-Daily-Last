using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCurveScript : MonoBehaviour
{
     public AnimationCurve animationCurve;
    public Vector3  Endpoint;
     Vector3 Startpoint;
    public float TotalTime;
    public float MaxHeight;
    // Start is called before the first frame update
    private void Awake()
    {
        Startpoint = transform.position;
    }
    void Start()
    {
        StopAllCoroutines();
        StartCoroutine(FlyWithCurve(animationCurve));
    }
    IEnumerator FlyWithCurve(AnimationCurve Curve)
    {
        float time = 0;
        Vector3 dir = (Endpoint-Startpoint).normalized;
        float distance = Vector3.Distance(Endpoint, Startpoint);
        while (time<TotalTime)
        {
            float normalizedTime = time / TotalTime;
            float sampleRate = Curve.Evaluate(normalizedTime);
            transform.position = Startpoint + dir * (distance* normalizedTime)+
                (sampleRate*MaxHeight)*Vector3.up;
            time += Time.deltaTime;
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
