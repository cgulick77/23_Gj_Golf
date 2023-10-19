using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject camPoint;
    public float ratio;
    // Start is called before the first frame update
    void Start()
    {
        camPoint=GameObject.Find("CameraPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = (Vector3.Lerp(transform.position, camPoint.transform.position, ratio));
        //transform.rotation = (camPoint.transform.rotation);
    }
    void FixedUpdate()
    {
        transform.position = (Vector3.Lerp(transform.position, camPoint.transform.position, ratio));
        transform.rotation = Quaternion.Lerp(transform.rotation, camPoint.transform.rotation, ratio);
    }

}
