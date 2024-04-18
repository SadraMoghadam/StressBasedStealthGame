/// <summary>
/// SURGE FRAMEWORK
/// Author: Bob Berkebile
/// Email: bobb@pixelplacement.com
/// 
/// An optional helper class that sets up a GameObject so that it can "physically" collide with a ColliderButton for input events... 
/// all this means is that is has a collider that has 'isTrigger' set to true.
/// 
/// </summary>

using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ColliderButtonInteraction : MonoBehaviour {
	//Init
	void Reset() {
		GetComponent<Collider> ().isTrigger = true;
	}

	void Awake() {
		var collider = GetComponent<Collider> ();
		collider.isTrigger = true;
	}
}
