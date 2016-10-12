using UnityEngine;
using System.Collections;

public class DiscRotationManager : MonoBehaviour {
	public void RotateToAngle(float angle,float time)
    {
        iTween.RotateTo(gameObject,new Vector3(0,0,angle),time);
	}
}
