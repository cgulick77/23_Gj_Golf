using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    [Range(1.0f, 1000.0f)]
    public float maxPower;
    [Range(0.3f, 1.0f)]
    public float nextShotMinSpeed;
    public float changeAngleSpeed;
    public float maxAngVel;
    public float lineLength;
    private Rigidbody rB;
    private float angle;
    private LineRenderer line;
    public bool bar, shoot=false,scoreCard;
    private GameObject strokeUI;
    private int strokeCount;
    private GameObject cam;
    public Vector3 newtonsAppeilay, startPos;
    public AudioSource source;
    public AudioClip hole,putt,wall;

    // Start is called before the first frame update
    void Awake()
    {
        strokeUI=GameObject.Find("StrokeCount");
        rB =GetComponent<Rigidbody>();
        rB.maxAngularVelocity = maxAngVel;
        line = GetComponent<LineRenderer>();
        strokeCount = 0;
        cam= GameObject.Find("StupidCamTrack");
        Physics.gravity = newtonsAppeilay;
    }

    // Update is called once per frame
    void Update()
    {
        if (rB.velocity.magnitude < nextShotMinSpeed)
        {
            this.gameObject.transform.GetChild(0).GetChild(1).GetComponentInChildren<ParticleSystem>().Stop();
            rB.velocity = new Vector3(0, 0, 0);

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
        if (Input.GetKey(KeyCode.R))
        {
            rB.velocity = new Vector3(0, 0, 0);
            rB.angularVelocity = new Vector3(0, 0, 0);
            transform.position = startPos;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (scoreCard)
            {
                GameObject.Find("ScoreCard").GetComponent<CanvasGroup>().alpha = 1;
                scoreCard = false;
            }
            else
            {
                GameObject.Find("ScoreCard").GetComponent<CanvasGroup>().alpha = 0;
                scoreCard = true;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        UpdateLine();
    }
    private void FixedUpdate()
    {
        if (shoot)
        {
            float temp = GameObject.Find("PowerBar").GetComponent<Image>().fillAmount;
            rB.AddForce(Quaternion.Euler(0, angle, 0) * Vector3.forward * maxPower * temp, ForceMode.Impulse);
            this.gameObject.transform.GetChild(0).GetChild(1).GetComponentInChildren<ParticleSystem>().Play();
            shoot = false;
            //shoot sound
            source.PlayOneShot(putt);
            strokeCount++;
            strokeUI.GetComponent<StrokeUI>().addAStroke(strokeCount);
            GameObject.Find("PowerBar").GetComponent<Image>().fillAmount=0;
        }
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
        line.startWidth = 1.0f;
    }
    private void SendPos()
    {
        cam.GetComponent<CameraTrack>().UpdatePos(transform.position);
    }
    private void Shoot()
    {
        shoot = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            source.PlayOneShot(wall);
            this.gameObject.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().Play();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        this.gameObject.transform.GetChild(1).GetComponentInChildren<ParticleSystem>().Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            source.PlayOneShot(hole);
            GameObject.Find("Score").GetComponent<StrokeScoreUpdate>().updateScorecard(strokeCount);
                GameObject.Find("ScoreCard").GetComponent<CanvasGroup>().alpha = 1;
                scoreCard = false;
            Invoke("next", 3);
        }
    }
    private void next()
    {
        rB.velocity = new Vector3(0, 0, 0);
        rB.angularVelocity = new Vector3(0, 0, 0);
        transform.position = startPos;
        strokeCount = 0;
        GameObject.Find("ScoreCard").GetComponent<CanvasGroup>().alpha = 0;
        scoreCard = true;
        GameObject.Find("SceneManager").GetComponent<SceneMan>().nextScene();
    }
}
