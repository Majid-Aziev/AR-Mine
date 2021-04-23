using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProgrammManager : MonoBehaviour
{
    [Header("Put your planeMarker here")]
    [SerializeField] private GameObject PlaneMarkerPrefab;

    private ARRaycastManager ARRaycastManagerScript;

    private Vector2 TouchPosition;

    public GameObject ObjectToSpawn; 

    private int isClick = 0;

    private int isClickI = 0;

    public GameObject ONObject;

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        PlaneMarkerPrefab.SetActive(false);
    }

    void Update()
    {
        ShowMarker();  
    }

    public void ON(){
    	if (isClick == 0){
    		isClick = 1;
    		PlayerPrefs.SetInt("c", isClick);
    		ONObject.GetComponent<Image>().color = new Color(0.6509804f, 0.6509804f, 0.6509804f);
    	}

    	else if (isClick == 1){
    		isClick = 0;
    		PlayerPrefs.SetInt("c", isClick);
    		ONObject.GetComponent<Image>().color = new Color(0.135f, 0.5490196f, 1f);
    	}    	
    }

    void ShowMarker()
    {
      isClickI = PlayerPrefs.GetInt("c");

      if (isClickI == 0){
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }
       
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Instantiate(ObjectToSpawn, hits[0].pose.position, ObjectToSpawn.transform.rotation);
            PlaneMarkerPrefab.SetActive(false);
        }
    }

      else if (isClickI == 1){
        PlaneMarkerPrefab.SetActive(false);
     } 
  }
}