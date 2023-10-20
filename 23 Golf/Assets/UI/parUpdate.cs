using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class parUpdate : MonoBehaviour
{
    private TextMeshProUGUI parDisplay;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        parDisplay = GetComponent<TextMeshProUGUI>();
        index = GameObject.Find("Score").GetComponent<StrokeScoreUpdate>().index;
        parDisplay.text="Par: "+GameObject.Find("ParNum").transform.GetChild(index).GetComponent<TextMeshProUGUI>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
