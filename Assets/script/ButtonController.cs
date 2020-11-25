using UnityEngine;
using System.Collections;
#if UNITY_2019_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSave(){
		GetComponent<SaveImage> ().saveImage ();
	}
	public void OnGallery(){
#if UNITY_2019_3_OR_NEWER
		SceneManager.LoadScene("gallery");
#else
        Application.LoadLevel ("gallery");
#endif
	}
	public void OnToBackboard(){
#if UNITY_2019_3_OR_NEWER
		SceneManager.LoadScene("blackboard");
#else
        Application.LoadLevel ("blackboard");
#endif
	}

}
