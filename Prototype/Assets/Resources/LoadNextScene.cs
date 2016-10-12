using UnityEngine;
using System.Collections;

public class LoadNextScene : MonoBehaviour {

	// Update is called once per frame
	public void LoadGameplayScene() {
        Application.LoadLevel(1);
	}
}
