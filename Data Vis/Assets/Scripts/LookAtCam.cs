using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    /**
     * Cette classe très simple a pour objectif de toujours orienter les UI
     * situées dans le "world space" dans la direction de la caméra.
     * 
     * Frédéric 30.08.19
     */

    public Transform cam;

    void Update()
    {
        transform.LookAt(cam.position);
    }
}
