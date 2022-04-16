using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingArrows_GaugeController : MonoBehaviour
{
    Image Gauge;
    public UnityEngine.Object TargetScene;

    // Start is called before the first frame update
    void Start()
    {
        Gauge = GetComponent<Image>();
        SetGauge();
    }

    private void Update()
    {
        if (Gauge.fillAmount <= 0.1f)
        {
            SceneManager.LoadScene(TargetScene.name);
        }
    }

    private void SetGauge()
    {
        Gauge.fillAmount = 1f; //게이지가 꽉차게 
    }


    public void DecreaseGauge()
    {
        Gauge.fillAmount -= 0.2f;
    }
}
