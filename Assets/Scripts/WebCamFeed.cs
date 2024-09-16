using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// a script that handles the webcam feed in a Unity project.
public class WebCamFeed : MonoBehaviour
{
    public RawImage rawImage;
    public Material effectMaterial;

    // WebCam Textures are textures onto which the live video input is rendered.
    private WebCamTexture webCamTexture;

    // Start is called before the first frame update
    void Start()
    {
        // Return a list of available devices.
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length > 0)
        {
            webCamTexture = new WebCamTexture(devices[0].name);
            rawImage.texture = webCamTexture;
            webCamTexture.Play();

            // Apply the WebCamEffectsMaterial to the rawImage.
            rawImage.material = effectMaterial;
            
        }
        else
        {
            Debug.Log("No camera detected");
        }
    }

    void OnDestroy()
    {
        if (webCamTexture != null)
        {
            webCamTexture.Stop();
        }
    }
}
