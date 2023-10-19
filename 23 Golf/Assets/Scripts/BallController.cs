using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
   
    private Light ballLight; // Reference to the light component
    private Material ballMaterial; // Reference to the ball's material
    private Color initialEmissionColor;

    private void Start()
    {
        // Get the light component on the ball (Assuming it's on the same GameObject)
        ballLight = GetComponent<Light>();

        // Get the ball's material
        ballMaterial = GetComponent<Renderer>().material;

        // Store the initial emission color
        initialEmissionColor = ballMaterial.GetColor("_EmissionColor");
    }

    public void IncreaseBrightness(float amount)
    {
        // Increase the brightness by modifying the emission color
        Color newEmissionColor = initialEmissionColor + new Color(amount, amount, amount);

        // Set the new emission color
        ballMaterial.SetColor("_EmissionColor", newEmissionColor);

        // Ensure the emission is enabled
        ballMaterial.EnableKeyword("_EMISSION");

        // Recompile the material to apply changes
        ballMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

        // Adjust the light intensity and range based on the brightness change
        ballLight.intensity += .05f; // You may need to fine-tune this value
        ballLight.range += 500; // Adjust the range based on your requirements
    }
}