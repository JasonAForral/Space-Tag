using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector3 differenceVector;
    public Vector3 screenMid;

    public bool mouseFollow;

    public float thrust;

    private RectTransform crosshair;

    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();

        screenMid = new Vector2(Screen.width * .5f, Screen.height * .5f);
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (mouseFollow)
        {
            screenMid = new Vector2(Screen.width * .5f, Screen.height * .5f);
            Vector3 mousePos = Input.mousePosition;
            differenceVector = (mousePos - screenMid) * 0.003f;
            transform.Rotate(-differenceVector.y, differenceVector.x, 0f);
            crosshair.position = Input.mousePosition;
        }
        else
        {
            //balance out
            LevelZ(true);
            crosshair.position = Vector2.Lerp(crosshair.position, screenMid, Time.deltaTime);
        }


        if (Input.GetButtonDown("TurnMode"))
        {
            mouseFollow = !mouseFollow;

            if (mouseFollow)
            {
                Cursor.visible = false;
                
            }
            else
            {
                Cursor.visible = true;
                
                
            }
        }
	}

    private void LevelZ (bool levelX = false)
    {
        Vector3 Euler = transform.eulerAngles;
        Euler = new Vector3
            (
                (Euler.x > 180 ? Euler.x - 360 : Euler.x),
                Euler.y,
                (Euler.z > 180 ? Euler.z - 360 : Euler.z)
            );
        Euler = new Vector3(Euler.x, Euler.y, Mathf.Lerp(Euler.z, 0f, Time.deltaTime));
        if (levelX)
        {
            Euler = new Vector3(Mathf.Lerp(Euler.x, 0f, Time.deltaTime), Euler.y, Euler.z);
        }
        transform.eulerAngles = Euler;
    }
}
