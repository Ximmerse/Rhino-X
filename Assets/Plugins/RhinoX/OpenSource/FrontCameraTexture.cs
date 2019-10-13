using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Ximmerse.RhinoX
{
    /// <summary>
    /// Attach this script to a raw image and assign to the field "webCameraImage" to display RhinoX front camera image.
    /// </summary>
    public class FrontCameraTexture : MonoBehaviour
    {
        public RawImage webCameraImage;

        public bool AutoStart = true;

        WebCamTexture webCamTexture = null;

        // Start is called before the first frame update
        void Start()
        {
            if(AutoStart)
            {
                StartCoroutine(StartCamera());
            }
        }

        private void OnDestroy()
        {
            StopCamera();
        }

        IEnumerator StartCamera ()
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                webCamTexture = new WebCamTexture();

                //如果有后置摄像头，调用后置摄像头  
                for (int i = 0; i < WebCamTexture.devices.Length; i++)
                {
                    if (WebCamTexture.devices[i].isFrontFacing)
                    {
                        WebCamDevice webCameraDevice = WebCamTexture.devices[i];
                        webCamTexture.deviceName = WebCamTexture.devices[i].name;
                        //Debug.LogFormat("Depth Cam Name : {0}, isAutoFocusPointSupported:{1}, isFrontFacing:{2}, kind: {3}, name : {4}",
                        // webCameraDevice.depthCameraName, webCameraDevice.isAutoFocusPointSupported, webCameraDevice.isFrontFacing, webCameraDevice.kind, webCameraDevice.name);
                        //break;
                    }
                }
                webCameraImage.texture = webCamTexture;
                webCamTexture.Play();
                if(webCameraImage != null)
                {
                    webCameraImage.texture = webCamTexture;
                }
                Debug.Log("web camera starts");
            }
            else
            {
                Debug.Log("has not authorization");
            }
        }

        void StopCamera ()
        {
            if(webCamTexture != null && webCamTexture.isPlaying)
            {
                webCamTexture.Stop();
            }
        }

    }
}