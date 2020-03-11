using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    private Transform playerTransform;

    void Start() {
          playerTransform = GameObject.FindGameObjectWithTag("Sune Tama").transform;

    }

    // Update is called once per frame
    void LateUpdate() {

          Vector3 temp = transform.position;
          temp.x = playerTransform.position.x;
          transform.position = temp;

    }
}
