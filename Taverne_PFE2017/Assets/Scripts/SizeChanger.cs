using UnityEngine;
using System.Collections;

public class SizeChanger : MonoBehaviour {

    public float ChangeDelay;
    private float currentRatio = 1;
    private Transform transf;
    private Vector3 baseScale;

    private bool endedScale = true;

    void Start()
    {
        transf = transform;
        baseScale = transf.localScale;
    }

    public void ToSizeFunc(float finalRatio)
    {
        StartCoroutine(ToSize(finalRatio));
    }

    public IEnumerator ToSize(float finalRatio)
    {
        if (!endedScale)
            yield break;

        endedScale = false;
        
        float time = 0.0f;
        float tmpRatio;
        while (time < ChangeDelay && currentRatio != finalRatio)
        {
            time += Time.deltaTime;
            if (time > ChangeDelay)
                time = ChangeDelay;
            tmpRatio = Mathf.Lerp(currentRatio, finalRatio, time / ChangeDelay);
            transf.localScale = baseScale * tmpRatio;
            yield return new WaitForEndOfFrame();
        }

        currentRatio = finalRatio;
        endedScale = true;
    }
}
