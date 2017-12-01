using UnityEngine;
using System.Collections;

public class VHand : MonoBehaviour {

	private GameObject selectedO;
	private Material initialM;
	public Material highlightM;
	private Renderer renderO;

	public bool selected = false;
	public Camera camera;

	// Use this for initialization
	void Start () {
		
	}

	// -------------------------------------------------------
	// Virtual Hand
	//
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && selected) {
			selectedO.transform.parent = this.transform;
		} 
		else if(Input.GetKeyUp(KeyCode.Space)) {
			selectedO.transform.parent = camera.transform;
		}
	}

	public void OnTriggerEnter(Collider collider)
	{
		selectedO = collider.transform.gameObject;
		renderO = selectedO.GetComponent<Renderer> ();
		initialM = renderO.material;

		selected = true;
		renderO.material = highlightM;

	}

	public void OnTriggerExit(Collider collider)
	{
		selected = false;
		renderO.material = initialM;
	}


	// ---------------------------------------------------------
	// Raycasting

//	void Update() {
//
//		RaycastHit hit;
//		Ray ray = new Ray (transform.position, Vector3.up);
//
//		if (Physics.Raycast (ray, out hit)) {
//
//			if (hit.collider.tag == "Target") {
//
//				// Do your thing with the object that was hit by the raycast.
//				selectedO = hit.transform.gameObject; 
//				renderO = selectedO.GetComponent<Renderer> ();
//				initialM = renderO.material;
//
//				renderO.material = highlightM;
//
//				if (Input.GetKeyDown (KeyCode.Space)) {
//					selectedO.transform.parent = this.transform;
//				} 
//				else if (Input.GetKeyUp (KeyCode.Space)) {
//					selectedO.transform.parent = camera.transform;
//				}
//			} 
//			else if (hit.collider.tag == null){
//				renderO.material = initialM;
//			}
//		}
//	}
}