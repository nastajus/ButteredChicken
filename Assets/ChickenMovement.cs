using UnityEngine;
using System.Collections;

public class ChickenMovement : MonoBehaviour {

    Bounds chickenBounds;
    float direction = .2f;
    Transform chefTransform;
    SpriteRenderer sr;

    float timeLeftToCatchChicken;
    bool winConditionTriggered = false;

	// Use this for initialization
	void Start () {
        chickenBounds = IanUtils.CameraOrthographicBounds(Camera.main);
        chefTransform = GameObject.Find("chef").transform;
        sr = GetComponent<SpriteRenderer>();
        timeLeftToCatchChicken = 3f;
    }
	
	// Update is called once per frame
	void Update () {

        //screen sides 
        Vector3 moveRange = new Vector3(Random.Range(.2f + direction, -.2f + direction), 0, 0);
        IanUtils.MoveToScreenEdge(gameObject.transform, transform.position + moveRange);

        if (transform.position.x >= chickenBounds.extents.x - 1){
            direction *= -1;
            //print("flipped");
        }
        else if (transform.position.x <= -chickenBounds.extents.x + 1)
        {
            direction *= -1;
            //print("flipped 2");
        }

        if (DetectChickenOnChef(transform, chefTransform))
        {
            sr.color = Color.white;
        }
        else
        {
            sr.color = Color.red;
            timeLeftToCatchChicken -= Time.deltaTime;
        }

        //WinCondition
        if (timeLeftToCatchChicken <= 0 && !winConditionTriggered)
        {
            winConditionTriggered = true;
            //insert win stuff here.
            print("WIN");

            //flip chicken 
            transform.localScale *= -1;
        }

	}

    public bool DetectChickenOnChef(Transform chefTransform, Transform chickenTransform)
    {
        if (chefTransform.position.x <= chickenTransform.position.x - 1 || chefTransform.position.x >= chickenTransform.position.x + 1)
        {
            return true;
        }
        return false;
    }

}
