using UnityEngine;
using System.Collections;

public class MouseUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (PlayerController.mouseFollow)
        {
            transform.position = Input.mousePosition;
        }
	}
}
