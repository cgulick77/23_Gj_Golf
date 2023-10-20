using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrokeScoreUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI h1, h2, h3, h4, h5, h6, h7, h8, h9;
    public int index;
    void Start()
    {
        h1 = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        h2 = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        h3 = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        h4 = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        h5 = transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        h6 = transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        h7 = transform.GetChild(6).GetComponent<TextMeshProUGUI>();
        h8 = transform.GetChild(7).GetComponent<TextMeshProUGUI>();
        h9 = transform.GetChild(8).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateScorecard(int score)
    {
        switch (index)
        {
            case 0:
                h1.text ="" + score;
                break;
            case 1:
                h2.text = "" + score;
                break;
            case 2:
                h3.text = "" + score;
                break;
            case 3:
                h4.text = "" + score;
                break;
            case 4:
                h5.text = "" + score;
                break;
            case 5:
                h6.text = "" + score;
                break;
            case 6:
                h7.text = "" + score;
                break;
            case 7:
                h8.text = "" + score;
                break;
            case 8:
                h9.text = "" + score;
                break;
        }
        index++;
    }
}
