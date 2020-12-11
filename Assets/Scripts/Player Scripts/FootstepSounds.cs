using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    private AudioSource footstep;
    [SerializeField]
    private AudioClip[] audioClips;
    private CharacterController characterController;
    private float accumulatedDistance;

    [HideInInspector]
    public float stepDistance;
    [HideInInspector]
    public float volMax, volMin;

    // Start is called before the first frame update
    void Awake()
    {
        footstep = GetComponent<AudioSource>();
        characterController = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound();
    }

    void PlaySound()
    {
        if(!characterController.isGrounded)
        {
            return;
        }
        
        if(characterController.velocity.sqrMagnitude > 0)
        {
            accumulatedDistance += Time.deltaTime;
            if(accumulatedDistance > stepDistance)
            {
                footstep.volume = Random.Range(volMin, volMax);
                footstep.clip = audioClips[Random.Range(0, audioClips.Length)];
                footstep.Play();

                accumulatedDistance = 0.0f;
            }
        }
        else
        {
            accumulatedDistance = 0.0f;
        }
    }
}
