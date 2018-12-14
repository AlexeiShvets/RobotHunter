using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMoveController : MonoBehaviour {

    public Transform Target;

	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Target.position.x,0.1f , Target.position.z);
	}
}
