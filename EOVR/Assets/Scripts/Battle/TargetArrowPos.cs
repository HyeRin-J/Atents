using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArrowPos : MonoBehaviour {

    public Transform target;
    Vector3 screenPos;
    Vector2 local = new Vector2();
    public float y;

    private void OnEnable()
    {
        target = transform.parent.parent.GetChild(1);
        screenPos = Camera.main.WorldToScreenPoint(new Vector3(target.position.x, target.position.y + y, target.position.z));
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), screenPos, Camera.main, out local);
        GetComponent<RectTransform>().anchoredPosition = local;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            screenPos = Camera.main.WorldToScreenPoint(new Vector3(target.position.x, target.position.y + y, target.position.z));
            RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), screenPos, Camera.main, out local);
            GetComponent<RectTransform>().anchoredPosition = local;
        }
    }
}
