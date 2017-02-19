using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This makes Bow&Arrow pull and shoot on trigger

public class Arrow : MonoBehaviour {

    public static int arrows;
    public static int score = 0;
    public GameObject meme;

    void OnTriggerStay()
    {
        Destroy(meme);
        AttachArrow();
        //ArrowManager.Instance.AttachBowToArrow();
    }
    void OnTriggerEnter()
    {
        AttachArrow();
        Debug.LogError("Box colliders hit");
    }

    void AttachArrow()
    {
        var device = SteamVR_Controller.Input((int)ArrowManager.Instance.trackedObj.index);
        if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            ArrowManager.Instance.AttachBowToArrow();
        }
    }
}
