using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    [Header("Regular walking speed for player")]
    private float speed = 3;

    [SerializeField]
    [Header("Sensitivity of player look")]
    private float lookSpeed = .5f;

    private Camera camera;
    private Rigidbody rigidbody;
    private Vector2 cameraRotation = new Vector2(0,0);
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        lastPosition = transform.position;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isRunning)
        {
            speed = 700;
        }
        else
        {
            speed = 400;
        }
        if (Input.GetAxisRaw("Horizontal") <= -0.5f)
        {
            rigidbody.velocity = speed * Time.deltaTime * -transform.right;
        }
        else if (Input.GetAxisRaw("Horizontal") >= 0.5f)
        {
            rigidbody.velocity = speed * Time.deltaTime * transform.right;
        }

        if (Input.GetAxisRaw("Vertical") <= -0.5f)
        {
            rigidbody.velocity = speed * Time.deltaTime * -transform.forward;
        }
        else if (Input.GetAxisRaw("Vertical") >= 0.5f)
        {
            rigidbody.velocity = speed * Time.deltaTime * transform.forward;
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -.05f && Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -.05f)
        {
            rigidbody.velocity = Vector3.zero;
        }



        cameraRotation.y += Input.GetAxis("Mouse X");
        cameraRotation.x += -Input.GetAxis("Mouse Y");
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -90, 90);

        camera.transform.localRotation = Quaternion.Euler(cameraRotation.x, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X"), 0);

    }

}


