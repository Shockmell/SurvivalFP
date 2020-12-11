using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AimType
{
    NONE,
    SELF,
    AIM
}

public enum FireType
{
    SINGLE,
    MULTIPLE
}

public enum BulletType
{
    NONE,
    BULLET,
    SPEAR,
    ARROW
}

public class WeaponsHandler : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private AudioSource shootSound, reloadSound;

    public AimType aim;
    public FireType fire;
    public BulletType bullet;
    public GameObject attackPoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Shoot()
    {
        anim.SetTrigger(AnimationTags.SHOOT);
    }

    void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AIM, canAim);
    }

    void MuzzleFlashOn()
    {
        muzzleFlash.SetActive(true);
    }

    void MuzzleFlashOff()
    {
        muzzleFlash.SetActive(false);
    }

    void PlayShootSound()
    {
        shootSound.Play();
    }

    void PlayReloadSound()
    {
        reloadSound.Play();
    }

    void AttackPointOn()
    {
        attackPoint.SetActive(true);
    }

    void AttackPointOff()
    {
        if(attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
