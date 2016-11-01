using UnityEngine;
 using System.Collections;
 
 public class CameraFacingBillboard : MonoBehaviour
 {
    public Camera cameraToLookAt;
 
    void Update() 
    {
    	if(cameraToLookAt != null){
	        Vector3 v = cameraToLookAt.transform.position - transform.position;
	        v.x = v.z = 0.0f;
	        transform.LookAt(cameraToLookAt.transform.position - v); 
	    }
	    else{
	    	cameraToLookAt = Camera.main;
	    }
    }
 }