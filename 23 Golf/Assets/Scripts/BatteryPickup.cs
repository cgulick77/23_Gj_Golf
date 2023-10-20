using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    public float brightnessIncreaseAmount = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallController ballController = other.GetComponent<BallController>();

            if (ballController != null)
            {
                // Increase the ball's brightness
                ballController.IncreaseBrightness(brightnessIncreaseAmount);
            }

            // Destroy the battery pickup object
            Destroy(gameObject);
        }
    }
}
