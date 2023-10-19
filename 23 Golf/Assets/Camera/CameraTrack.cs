using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [Range(0,90)]
    public float xRot;
    private GameObject ball;
    public float ratio;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = (Vector3.Lerp(transform.position, ball.transform.position, ratio) + offset);
        //transform.rotation = (ball.transform.rotation);
    }
    public void UpdateRotation(float angle, Vector3 lineEnd)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x + xRot, angle, transform.rotation.z);
        transform.position = lineEnd;
    }
    public void UpdatePos( Vector3 ball)
    {
        transform.position = ball;
    }
}
