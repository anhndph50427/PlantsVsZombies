using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar2 : MonoBehaviour
{

    public Slider progressBar;
    public float duration;
    private float elapsedTime = 0f;

    void Start()
    {
        if (progressBar != null)
        {
            progressBar.value = 0;
        }
    }

    void Update()
    {
        if (progressBar != null)
        {
            elapsedTime += Time.deltaTime;

            progressBar.value = Mathf.Clamp01(elapsedTime / duration);

            if (progressBar.value >= 1f)
            {
                enabled = false;
            }
        }
    }
}
