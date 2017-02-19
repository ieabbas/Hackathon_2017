using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All GameObjects appear in Unity and can be used to place corresponding assets

public class ArrowManager : MonoBehaviour
{
    //instance of this class
    public static ArrowManager Instance;
    //reference to controller (lets computer know where to place the arrow/bow)
    public SteamVR_TrackedObject trackedObj;
    //reference to your arrow on bow
    private GameObject currentArrow;
    //reference to the arrow prefab
    public GameObject arrowPrefab;
    //Holds where to attach arrow to string
    public GameObject stringAttachPoint;
    //sets where arrow should appear on  string when colliders hit
    public GameObject arrowStartPoint;
    //checks to see if bow is attached;
    private bool isAttached = false;
    //sets where the string starts off at (helps with determining pullback)
    public GameObject stringStartPoint;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    //destroy instance of class
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //makes sure we always have an arrow attached to our hand
        AttachArrow();
        //Checks to see if String is being pulled
        PullString();
	}

    private void PullString()
    {
        if(isAttached)
        {
            float distance = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
            //current position minus offset (controls how far is pullback to move arrow on string
            stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(11*distance, 0f, 0f);

            var device = SteamVR_Controller.Input((int)trackedObj.index);
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        //currentArrow.GetComponent<Rigidbody>().velocity = currentArrow.transform.forward * 10f;
        currentArrow.transform.parent = null;
        
        //sets arrow free with gravity
        Rigidbody r = currentArrow.GetComponent<Rigidbody>();
        r.velocity = currentArrow.transform.forward * 10f;
        r.useGravity = false;

        //changes the arrow from being iffset when attached
        stringAttachPoint.transform.position = stringStartPoint.transform.position;

        //doing these lets you replace the arrow
        currentArrow = null;
        isAttached = false;
    }
    //attaches arrow to hand
    public void AttachArrow()
    {
        //if no arrow in hand
        if(currentArrow == null)
        {
            //set current arrow to arrow prefab (basically make an arrow appear if none is there)
            currentArrow= Instantiate(arrowPrefab);
            //take arrow you just made and set it to controller (filled in trackedObj in right controller in Unity with arrow)
            currentArrow.transform.parent = trackedObj.transform;
            //places arrow at head of controller. 
            currentArrow.transform.localPosition = new Vector3(0f, 0f, .342f);
            //sets arrows rotation
            currentArrow.transform.localRotation = Quaternion.identity;
        }
    }

    public void AttachBowToArrow()
    {
        currentArrow.transform.parent = stringAttachPoint.transform;
        currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

        isAttached = true;
    }
}
