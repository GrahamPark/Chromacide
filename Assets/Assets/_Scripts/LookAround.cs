using UnityEngine;
using System.Collections;

public class LookAround : MonoBehaviour {


    float mouseX;
    float mouseY;

    private float rotationX = 0f;
    private float sensX = 2f;

    public float mouseSen;

    public GameObject cam;

    [HideInInspector]


    void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	

	void Update () {


        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        mouseLook(mouseX, mouseY);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;

            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }

    void mouseLook(float mouseX, float mouseY)
    {

        rotationX += mouseY * sensX;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        if (mouseX > 0)
        {
            transform.Rotate(Vector3.up * mouseSen * mouseX);
        }
        if (mouseX < 0)
        {
            transform.Rotate(-Vector3.up * mouseSen * -mouseX);
        }
        cam.transform.localEulerAngles = new Vector3(-rotationX, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);
    }
}
