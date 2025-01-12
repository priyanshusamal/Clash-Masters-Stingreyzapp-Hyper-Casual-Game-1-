using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]private SquadDetection squadDetection;

    public Camera cam;
    public bool FinishLine = false;
    void Start()
    {
        cam = Camera.main;
        FinishLine = false;
    }

    
    [SerializeField]private Quaternion tempQuaternion;
    [SerializeField]private Quaternion target;
    [SerializeField]private Vector3 targetRot;
    void Awake()
    {
       
    }
    void Update()
    {
        FinishLine = squadDetection.finishLineDetected;
        tempQuaternion.SetLookRotation(cam.transform.position, Vector3.forward);
        if(FinishLine == true)
        {
            target = Quaternion.Euler(tempQuaternion[0],tempQuaternion[1],transform.rotation.z);
            // transform.rotation = Quaternion.Euler(tempQuaternion.Euler.x,tempQuaternion.Euler.y,transform.rotation.z,0);
            // target = Quaternion.Euler(tempQuaternion[0],tempQuaternion[1],transform.rotation[2]);
        }
        else{
            // target = Quaternion.Euler(tempQuaternion[0],transform.rotation[1],transform.rotation[2]);
            target = Quaternion.Euler(tempQuaternion[0],transform.rotation.y,transform.rotation.z);
            // transform.rotation = Quaternion.Euler(-tempQuaternion.Euler.x,transform.rotation.y,transform.rotation.z,1f);
        }
        targetRot = new Vector3(target[0],target[1],target[2]);
        transform.Rotate(tempQuaternion[0],tempQuaternion[1],transform.rotation.z,Space.Self);
        // tempQuaternion = tempTransform.rotation;
        // transform.rotation = new Quaternion(tempQuaternion.Euler.x,tempQuaternion.eulerAngles.y,tempQuaternion.eulerAngles.z);
        // transform.Quaternion = target;
        // transform.rotation = tempQuaternion;
    }
}
