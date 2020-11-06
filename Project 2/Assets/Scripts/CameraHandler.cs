using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    Camera camara;
    Matrix4x4 matrixProjection;
    Matrix4x4 matrixOrthogonalProjection;

    // Start is called before the first frame update
    void Start()
    {
        camara = this.GetComponent<Camera>();
        //camara.aspect = 0.5f;
        //matrixProjection = camara.previousViewProjectionMatrix;
        //camara.cameraToWorldMatrix;
        //camara.worldToCameraMatrix;
        //camara.orthographic = true;
        //Debug.Log(matrixProjection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
