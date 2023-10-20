using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class holeUpdate : MonoBehaviour
{
    private TextMeshProUGUI parDisplay;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        parDisplay = GetComponent<TextMeshProUGUI>();
        index = GameObject.Find("Score").GetComponent<StrokeScoreUpdate>().index;
        parDisplay.text = "Hole: " + index+1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
