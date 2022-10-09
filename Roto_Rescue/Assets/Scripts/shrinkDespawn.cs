using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrinkDespawn : MonoBehaviour
{
    void Start()
    {
        ScaleToTarget(new Vector3(0f, 0f, 0f), 15);
    }

    public void ScaleToTarget(Vector3 targetScale, float duration)
	{
        StartCoroutine(ScaleToTargetCoroutine(targetScale, duration));
	}
    private IEnumerator ScaleToTargetCoroutine(Vector3 targetScale, float duration)
	{
        Vector3 startScale = transform.localScale;
        float timer = 0.0f;

		while (timer < duration)
		{
            timer += Time.deltaTime;
            float t = timer / duration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
		}
        Destroy(gameObject);
        yield return null;
	}
}
