using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponsManager weaponsManager;
    private float nextTimeToFire;
    private Animator zoomAnim;
    private bool isZoom;
    private bool isAim;
    private GameObject crosshair;
    private Camera mainCam;

    public float fireRate = 15.0f;
    public float damage = 20.0f;

    private void Awake()
    {
        weaponsManager = GetComponent<WeaponsManager>();
        zoomAnim = transform.Find(Tags.LOOK_ROOT).transform.Find(Tags.ZOOM_CAM).GetComponent<Animator>();
        crosshair = GameObject.FindGameObjectWithTag(Tags.CROSSHAIR);
        mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Zoom();
    }

    void Shoot()
    {
        if(weaponsManager.GetCurrentWeapon().fire == FireType.MULTIPLE)
        {
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                weaponsManager.GetCurrentWeapon().Shoot();
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(weaponsManager.GetCurrentWeapon().CompareTag(Tags.AXE))
                {
                    weaponsManager.GetCurrentWeapon().Shoot();
                }

                if(weaponsManager.GetCurrentWeapon().bullet == BulletType.BULLET)
                {
                    weaponsManager.GetCurrentWeapon().Shoot();
                }

                if (weaponsManager.GetCurrentWeapon().bullet == BulletType.ARROW || weaponsManager.GetCurrentWeapon().bullet == BulletType.SPEAR)
                {
                    if (isAim)
                    {
                        weaponsManager.GetCurrentWeapon().Shoot();
                    }
                }
            }
        }
    }

    void Zoom()
    {
        if(weaponsManager.GetCurrentWeapon().aim == AimType.AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                zoomAnim.Play(AnimationTags.ZOOM_IN);
                isZoom = true;
                crosshair.SetActive(false);
            }
            if (Input.GetMouseButtonUp(1))
            {
                zoomAnim.Play(AnimationTags.ZOOM_OUT);
                isZoom = false;
                crosshair.SetActive(true);
            }
        }
        if (weaponsManager.GetCurrentWeapon().aim == AimType.SELF)
        {
            if (Input.GetMouseButtonDown(1))
            {
                weaponsManager.GetCurrentWeapon().Aim(true);
                isAim = true;
            }
            if (Input.GetMouseButtonUp(1))
            {
                weaponsManager.GetCurrentWeapon().Aim(false);
                isAim = false;
            }
        }
    }
}
