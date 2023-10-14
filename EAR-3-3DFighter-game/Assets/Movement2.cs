    using UnityEngine;
    using System.Collections;
     
    public class Movement2 : MonoBehaviour {
     
        public float playerSpeed;
        public float walkSpeed = 2f;
        public float mouseSensitivity = 2f;
        public float jumpHeight = 3f;
        private float yRot;
        bool isGrounded;
     
        private Rigidbody rigidBody;
     
        // Use this for initialization
        void Start () {
     
            playerSpeed = walkSpeed;
            rigidBody = GetComponent<Rigidbody>();
     
        }
     
        // Update is called once per frame
        void Update () {
     
            yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);
     
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            }
     
            if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
            {
                rigidBody.AddForce(Vector3.up * jumpHeight);
                isGrounded=false;
            }
        }

        void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.tag=="Ground")
            {
                isGrounded=true;
            }
        }
    }
     
