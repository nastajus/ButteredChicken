using UnityEngine;
using System.Collections;

public class ChefMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
	    if (x!=0) {
            Vector3 tryMoveHere = gameObject.transform.position + new Vector3(x,0, 0);
            IanUtils.MoveToScreenEdge(gameObject.transform, tryMoveHere);
        }
	}
}
