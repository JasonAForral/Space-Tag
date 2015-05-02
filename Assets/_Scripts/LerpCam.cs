using UnityEngine;
using System.Collections;

public class LerpCam : MonoBehaviour {

    public Transform lerpTarget;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if ((transform.position - lerpTarget.position).sqrMagnitude > float.Epsilon)
        {
            transform.position = Vector3.Lerp(transform.position, lerpTarget.position, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, lerpTarget.rotation, Time.deltaTime);
        }
        else
        {
            transform.position = lerpTarget.position;
            transform.rotation = lerpTarget.rotation;
        }
	}
}
