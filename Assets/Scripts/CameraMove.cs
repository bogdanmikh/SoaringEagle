using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour {
    public GameObject player;

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(player.transform.position.x + 6f, transform.position.y, transform.position.z);
    }
}
