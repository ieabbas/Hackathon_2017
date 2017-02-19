using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayTheFuckStill : MonoBehaviour {

    public GameObject stay;

    // Update is called once per frame
    void Start () {
        stay.transform.localPosition = new Vector3(0f, 0f, 0f);
    }
}
