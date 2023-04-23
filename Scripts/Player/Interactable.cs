using UnityEngine;

namespace LB {
    public class Interactable : MonoBehaviour {

        public float radius = 2f;	// How close do we need to be to interact?

        bool isFocus = false;	// Is this interactable currently being focused?
        Transform player;		// Reference to the player transform

        bool hasInteracted = false;	// Have we already interacted with the object?

        public virtual void Interact ()
        {
            // This method is meant to be overwritten
            Debug.Log("Interacting with " + transform.name);
        }

        void Update ()
        {
            // If we are currently being focused
            // and we haven't already interacted with the object
            if (isFocus && !hasInteracted)
            {
                // If we are close enough
                float distance = Vector3.Distance(player.position, transform.position);
                if (distance <= radius)
                {
                    // Interact with the object
                    Interact();
                    hasInteracted = true;
                }
            }
        }

        // Called when the object starts being focused
        public void OnFocused (Transform playerTransform)
        {
            isFocus = true;
            player = playerTransform;
            hasInteracted = false;
        }

        // Called when the object is no longer focused
        public void OnDefocused ()
        {
            isFocus = false;
            player = null;
            hasInteracted = false;
        }

        // Draw our radius in the editor
        void OnDrawGizmosSelected(){
            Color color = Color.yellow;
            color.a = 0.30f;
            Gizmos.color = color;
            Gizmos.DrawSphere(transform.position, radius);
        }

    }
}
