using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LB {
		[RequireComponent(typeof(MovementManager))]
		public class PlayerInputHandler : MonoBehaviour {

				public Interactable currentFocus;	    		// Our current focus: Item, Enemy etc.
				private new Camera camera;			        	// Reference to our camera
				private MovementManager MovementManager;	// Reference to our MovementManager
				public GameObject WaypointIndicator;    	// Reference to waypointer prefab.
				private GameObject waypointInstance;    	// Reference to waypointer instance.
				public GameObject StatPanel;							// Reference to our statPanel UI


				void Awake(){
					camera = Camera.main;
					MovementManager = GetComponent<MovementManager>();
				}
				
				void Update(){
					if (Input.GetKeyUp("space")){
						ShowStatPanel();
					}

					if (Input.GetKeyUp("q")){
						if(currentFocus){
							CharacterManager TargetCharacterManager = currentFocus.GetComponentInParent<CharacterManager>();
							if(TargetCharacterManager){
								TargetCharacterManager.StatsManager.Stats["HP"].CurrentValue -= 9999;
								TargetCharacterManager.TakeDamage("9999", DamageTypes.Flat, true); 
							}	
						}
						
					}

					// If has a focus, calculate distance
					if(currentFocus != null){
						MovementManager.CalculateDistance(currentFocus.transform);
					} else {
						MovementManager.isCloseToCurrentTarget = false;
					}

					if(!EventSystem.current.IsPointerOverGameObject()){    
						// catch rightClickHold
						if(Input.GetMouseButton(1)){
								Ray ray = camera.ScreenPointToRay(Input.mousePosition);
								RaycastHit hit;
								if(Physics.Raycast(ray, out hit)){
										MovementManager.MoveToPoint(hit.point);
								}
						}

						// catch rightClick
						if(Input.GetMouseButtonDown(1)){
							Ray ray = camera.ScreenPointToRay(Input.mousePosition);
							RaycastHit hit;
							if(Physics.Raycast(ray, out hit)){
								Interactable interactable = hit.collider.GetComponentInParent<Interactable>();
								if(interactable != null){
									SetAndMoveToFocus(interactable);
								} else {
									if(waypointInstance != null){
										waypointInstance.SetActive(true);
										waypointInstance.transform.position = hit.point;
									} else {
										waypointInstance = Instantiate(WaypointIndicator, hit.point, Quaternion.identity);
									}
									MovementManager.MoveToPoint(hit.transform.position);
									MovementManager.StopFollowTarget();
								}
							}
						}

						// catch leftClick
						if(Input.GetMouseButtonDown(0)){
							Ray ray = camera.ScreenPointToRay(Input.mousePosition);
							RaycastHit hit;
							if(Physics.Raycast(ray, out hit)){
								Interactable interactable = hit.collider.GetComponentInParent<Interactable>();
								if(interactable != null){
									SetFocus(interactable);
								} else {
									RemoveFocus();
								}
							}
						}
					}

					if(waypointInstance != null){
						if(MovementManager.nvAgent.remainingDistance <= 0){
							waypointInstance.SetActive(false);
						}
					}
				}

				// Acquires the entity clicked as player currentFocus
				void SetFocus (Interactable newFocus){
						if(newFocus != currentFocus){
								if(currentFocus != null){
										currentFocus.OnDefocused();
								}
								currentFocus = newFocus;
						}
						newFocus.OnFocused(transform);
				}

				// Acquires the entity clicked as player currentFocus and moves in range
				void SetAndMoveToFocus (Interactable newFocus){
						if(newFocus != currentFocus){
								if(currentFocus != null){
										currentFocus.OnDefocused();
								}
								currentFocus = newFocus;
								MovementManager.StartFollowTarget(currentFocus);
						} else {
								if(currentFocus != null){
										MovementManager.StartFollowTarget(currentFocus);
								}
						}
						newFocus.OnFocused(transform);
				}

				// cleares the player currentFocus and interrupts any MovementManager
				void RemoveFocus(){
						if(currentFocus != null){
								currentFocus.OnDefocused();
						}
						currentFocus = null;
						MovementManager.StopFollowTarget();
				}

				public void ShowStatPanel(){
						if(StatPanel){
								bool isActive = StatPanel.activeSelf;
								StatPanel.SetActive(!isActive);
						}
				}
		}
}