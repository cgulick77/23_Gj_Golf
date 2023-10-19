using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    [Range(1.0f, 1000.0f)]
    public float maxPower;
    [Range(0.05f, 0.3f)]
    public float nextShotMinSpeed;
    public float changeAngleSpeed;
    public float maxAngVel;
    public float lineLength;
    private Rigidbody rB;
    private float angle;
    private LineRenderer line;
    public bool bar;
    private GameObject strokeUI;
    private int strokeCount;
    private GameObject cam;

    // Start is called before the first frame update
    void Awake()
    {
        strokeUI=GameObject.Find("StrokeCount");
        rB =GetComponent<Rigidbody>();
        rB.maxAngularVelocity = maxAngVel;
        line = GetComponent<LineRenderer>();
        strokeCount = 0;
        cam= GameObject.Find("StupidCamTrack");
    }

    // Update is called once per frame
    void Update()
    {
        if (rB.velocity.magnitude < nextShotMinSpeed)
        {
            turnOnLine();
            
            if (Input.GetKey(KeyCode.A))
            {
                AngleUpdate(-1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                AngleUpdate(1);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                bar = true;
            }
            if (bar)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    bar = false;
                    Shoot();
                }
            }

        }
        else
        {
            turnOffLine();
            SendPos();
        }
        
        UpdateLine();
    }
    private void AngleUpdate(int direction)
    {
        angle += changeAngleSpeed * Time.deltaTime * direction;
    }
    private void UpdateLine()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward*lineLength);
        cam.GetComponent<CameraTrack>().UpdateRotation(angle, transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * lineLength);
    }
    private void turnOffLine()
    {
        line.startWidth=0.0f;
    }
    private void turnOnLine()
    {
        line.startWidth = 10.0f;
    }
    private void SendPos()
    {
        cam.GetComponent<CameraTrack>().UpdatePos(transform.position);
    }
    private void Shoot()
    {
        float temp = GameObject.Find("PowerBar").GetComponent<Image>().fillAmount;
        rB.AddForce(Quaternion.Euler(0, angle, 0) * Vector3.forward * maxPower* temp, ForceMode.Impulse);
        //shoot sound
        strokeCount++;
        strokeUI.GetComponent<StrokeUI>().addAStroke(strokeCount);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
