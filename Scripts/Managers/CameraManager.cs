using UnityEngine;


namespace LB {

    public class CameraManager : MonoBehaviour {

        [Header("Camera Setup")]
        private GameObject Player;
        private GameObject Camera;

        [Header("Camera Position")]
        private Vector3 Offset;
        private Vector3 Rotation;

        [Header("Zoom Options")]
        public float MaxRangeZoom = 10f;
        public float MinRangeZoom = 4f;
        private float CurrentZoom = 10f;
        public float ZoomSpeed = 4f;

        [Header("Follow Params")]
        public float SmoothSpeed = 1f;


        void Awake(){
            Player = GameObject.FindGameObjectWithTag("Player");
            Camera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        void Start() {
            Offset = new Vector3(-10f, 10f, -10f);
            Rotation = new Vector3(30f, 45f, 0f);
        }

        void LateUpdate(){
            FollowPlayer();
            HandleZoom();
        }

        void HandleZoom(){
            CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
            CurrentZoom = Mathf.Clamp(CurrentZoom, MinRangeZoom, MaxRangeZoom);
            Camera.GetComponent<Camera>().orthographicSize = CurrentZoom;
        }

        void FollowPlayer(){
            Vector3 newPosition = Player.transform.position + Offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPosition, SmoothSpeed);
            transform.position = smoothedPosition;
            transform.rotation = Quaternion.Euler(Rotation);
            transform.LookAt(Player.transform);
        }
        
    }

}
