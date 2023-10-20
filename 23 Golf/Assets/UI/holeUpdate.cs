using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class holeUpdate : MonoBehaviour
{
    private TextMeshProUGUI parDisplay;
    public int index;
    private int offset=10;
    // Start is called before the first frame update
    void Start()
    {
        parDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        index = GameObject.Find("Score").GetComponent<StrokeScoreUpdate>().index;
        index = index - 9+offset;
        parDisplay.text = "Hole: " + index;
    }
}
