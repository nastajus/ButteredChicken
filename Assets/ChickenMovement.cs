using UnityEngine;
using System.Collections;

public class ChickenMovement : MonoBehaviour {

    Bounds chickenBounds;
    float direction = .2f;

	// Use this for initialization
	void Start () {
        chickenBounds = IanUtils.CameraOrthographicBounds(Camera.main);
    }
	
	// Update is called once per frame
	void Update () {

        //screen sides 
        Vector3 moveRange = new Vector3(Random.Range(.2f + direction, -.2f + direction), 0, 0);
        IanUtils.MoveToScreenEdge(gameObject.transform, transform.position + moveRange);

        if (transform.position.x >= chickenBounds.extents.x - 1){
            direction *= -1;
            print("flipped");
        }
        else if (transform.position.x <= -chickenBounds.extents.x + 1)
        {
            direction *= -1;
            print("flipped 2");
        }

	}
}
