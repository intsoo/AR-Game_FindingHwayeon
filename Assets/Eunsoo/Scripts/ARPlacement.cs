using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{

    public GameObject arObjectToSpawn;  // bowl to place on the plane
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    // #ES: No more plane showing after he bowl is placed
    private ARPlaneManager arPlaneManager;

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        arPlaneManager = FindObjectOfType<ARPlaneManager>();

    }

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {
        // Create the bowl instance and place it on the plane only once
        if(spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();

    }
    void UpdatePlacementIndicator()
    {
        if(spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
            
            // Stop showing perceived planes
            // foreach (var plane in arPlaneManager.trackables) {
            //     // 오브젝트가 생성되었기 때문에 Plane 인스턴스 생성을 멈추게 한다.
            //     plane.gameObject.SetActive(false);
            // }
        }
    }

    void UpdatePlacementPose()
    {
        // Get the position of the screen center
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if(placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;  // Get the very first hit
        }
    }

    // Create the new instance of the bowl
    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
    
        var rigidbody = spawnedObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }
}


