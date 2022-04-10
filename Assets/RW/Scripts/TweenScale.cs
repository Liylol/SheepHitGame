using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public float targetScale;
    public float timeToReachTarget;
    private float startScale;
    private float percentScale;
   
    private void Start()
    {
        startScale = transform.localScale.x;
    }

    
   private void Update()
    {
        if (percentScale < 1f)
        {

            percentScale += Time.deltaTime / timeToReachTarget;
            float scale = Mathf.Lerp(startScale, targetScale, percentScale);
            transform.localScale = new Vector3(scale, scale, scale);

        }
    }
}
