using UnityEngine;

namespace LB {
	public class Targetable : MonoBehaviour {

		public float currentDistanceFromTarget;
		public float maxDistanceFromTarget;
		public Transform CurrentTarget;
		public bool isCloseToCurrentTarget = false;

		public void Update(){
			if(CurrentTarget){
				float distance = Vector3.Distance(transform.position, CurrentTarget.transform.position);
					if(distance <= 2){
							isCloseToCurrentTarget = true;
					} else {
							isCloseToCurrentTarget = false;
					}
			}
		}

		// Called when the object starts being focused
		public void OnTargetLock(Transform Target){
			// show UI of targeted entity
		}

		// Called when the object is no longer focused
		public void OnTargetCancel(){
			// remove UI of targeted entity
		}

		public void ToggleTargetUI(){
			// Toggle UI elements
		}

	}
}
