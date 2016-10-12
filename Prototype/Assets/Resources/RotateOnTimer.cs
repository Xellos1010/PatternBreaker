using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateOnTimer : MonoBehaviour {

    DiscRotationManager manager;
    float currentAngle = 0;

	void Start()
    {
        manager = GetComponent<DiscRotationManager>();
        StartCoroutine(RotateToNextRune());   
    }

    IEnumerator RotateToNextRune()
    {
        yield return new WaitForSeconds(2);
        currentAngle += 72;
        if (currentAngle == (72 * 5))
            currentAngle = 0;
        manager.RotateToAngle(currentAngle, 1.5f);
        StartCoroutine(RotateToNextRune());
    }

	// Update is called once per frame
	void Update () {
	
	}
}
