using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private Image bar;
    public bool charge, neg=false;
    [Range(0.0f, 1.0f)]
    public float rate;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        bar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        charge = GameObject.Find("Ball").GetComponent<BallMovement>().bar;
        if (charge)
        {
            if (!neg)
            {
                bar.fillAmount = bar.fillAmount + rate*Time.deltaTime;
                if (bar.fillAmount == 1)
                {
                    neg = true;

                }
            }
            else
            {
                bar.fillAmount = bar.fillAmount - rate * Time.deltaTime;
                if (bar.fillAmount == 0)
                {
                    neg = false;

                }
            }

        }

    }
}

