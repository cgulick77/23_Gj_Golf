using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrokeUI : MonoBehaviour
{
    private TextMeshProUGUI strokeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        strokeDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addAStroke(int val)
    {
        strokeDisplay.text = "Stroke: " + val;
    }
}
