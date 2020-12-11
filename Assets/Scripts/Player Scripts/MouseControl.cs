using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    #region Variables
    #region Editable
    [SerializeField]
    private Transform playerRoot, lookRoot;
    [SerializeField]
    private bool invert;
    [SerializeField]
    private bool canUnlock = true;
    [SerializeField]
    private float sensitivity = 5.0f;
    [SerializeField]
    private int smoothSteps = 10;
    [SerializeField]
    private float smoothWeight = 0.4f;
    [SerializeField]
    private Vector2 lookLimits = new Vector2(-70.0f, 80.0f);
    #endregion

    #region Private
    private Vector2 lookAngle;
    private Vector2 currentMouseLook;
    private Vector2 smoothMove;
    private int lastLookFrame;
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LockCursor();
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }

    #region Custom Functions
    void LockCursor()
    {
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void LookAround()
    {
        currentMouseLook = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        lookAngle.x += currentMouseLook.x * sensitivity * (invert ? 1.0f : -1.0f);
        lookAngle.y += currentMouseLook.y * sensitivity;

        lookAngle.x = Mathf.Clamp(lookAngle.x, lookLimits.x, lookLimits.y);

        lookRoot.localRotation = Quaternion.Euler(lookAngle.x, 0.0f, 0.0f);
        playerRoot.localRotation = Quaternion.Euler(0.0f, lookAngle.y, 0.0f);
    }
    #endregion
}
