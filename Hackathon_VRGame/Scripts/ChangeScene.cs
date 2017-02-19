using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public SteamVR_TrackedObject trackedObj1;
    public SteamVR_TrackedObject trackedObj2;
    private SteamVR_Controller.Device device1;
    private SteamVR_Controller.Device device2;


    // Use this for initialization
    void Start () {
        trackedObj1 = GetComponent<SteamVR_TrackedObject>();
        trackedObj2 = GetComponent<SteamVR_TrackedObject>();
    }
	
	// Update is called once per frame
	void Update () {

        device1 = SteamVR_Controller.Input((int)trackedObj1.index);
        if (device1.GetPressDown(triggerButton))
        {
            //Load game
            SceneManager.LoadScene("Accuracy_Test");
        }

        device2 = SteamVR_Controller.Input((int)trackedObj1.index);
        if (device2.GetPressDown(triggerButton))
        {
            //Load game
            SceneManager.LoadScene("Accuracy_Test");
        }
    }
}
