using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintAndCrouch : MonoBehaviour
{
    #region Variables
    #region Public
    public float sprintSpeed = 10.0f;
    public float moveSpeed = 5.0f;
    public float crouchSpeed = 2.0f;
    public float crouchSprint = 4.0f;
    #endregion

    #region Private
    private PlayerMovement playerMovement;
    private Transform lookRoot;
    private float standHeight = 1.6f;
    private float crouchHeight = 0.8f;
    private bool isCrouched;
    private CharacterController characterController;
    private FootstepSounds footstepSounds;
    private float sprintVol = 1.0f;
    private float crouchVol = 0.1f;
    private float crsprVol = 0.2f;
    private float walkVolMin = 0.2f, walkVolMax = 0.6f;
    private float stepDist = 0.4f;
    private float stepSprintDist = 0.25f;
    private float stepCrouchDist = 0.5f;
    private float stepCrsprDist = 0.35f;
    #endregion
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        characterController = GetComponent<CharacterController>();
        footstepSounds = GetComponentInChildren<FootstepSounds>();

        lookRoot = transform.GetChild(0);
    }

    private void Start()
    {
        footstepSounds.volMin = walkVolMin;
        footstepSounds.volMax = walkVolMax;
        footstepSounds.stepDistance = stepDist;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Crouch();
            }
        }

        Sprint();
    }

    #region Custom Functions
    void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouched)
        {
            playerMovement.speed = sprintSpeed;
            footstepSounds.stepDistance = stepSprintDist;
            footstepSounds.volMax = sprintVol;
            footstepSounds.volMin = sprintVol;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouched)
        {
            playerMovement.speed = moveSpeed;
            footstepSounds.stepDistance = stepDist;
            footstepSounds.volMax = walkVolMax;
            footstepSounds.volMin = walkVolMin;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && isCrouched)
        {
            playerMovement.speed = crouchSprint;
            footstepSounds.stepDistance = stepCrsprDist;
            footstepSounds.volMax = crsprVol;
            footstepSounds.volMin = crsprVol;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && isCrouched)
        {
            playerMovement.speed = crouchSpeed;
            footstepSounds.stepDistance = stepCrouchDist;
            footstepSounds.volMax = crouchVol;
            footstepSounds.volMin = crouchVol;
        }
    }

    void Crouch()
    {
        if (!isCrouched)
        {
            playerMovement.speed = crouchSpeed;
            lookRoot.localPosition = new Vector3(0.0f, crouchHeight, 0.0f);
            footstepSounds.stepDistance = stepCrouchDist;
            footstepSounds.volMax = crouchVol;
            footstepSounds.volMin = crouchVol;
            isCrouched = true;
        }
        else
        {
            playerMovement.speed = moveSpeed;
            lookRoot.localPosition = new Vector3(0.0f, standHeight, 0.0f);
            footstepSounds.stepDistance = stepDist;
            footstepSounds.volMax = walkVolMax;
            footstepSounds.volMin = walkVolMin;
            isCrouched = false;
        }
    }
    #endregion
}
