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

    public void Shoot()
    {
        anim.SetTrigger(AnimationTags.SHOOT);
    }

    public void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AIM, canAim);
    }

    public void MuzzleFlashOn()
    {
        muzzleFlash.SetActive(true);
    }

    public void MuzzleFlashOff()
    {
        muzzleFlash.SetActive(false);
    }

    public void PlayShootSound()
    {
        shootSound.Play();
    }

    public void PlayReloadSound()
    {
        reloadSound.Play();
    }

    public void AttackPointOn()
    {
        attackPoint.SetActive(true);
    }

    public void AttackPointOff()
    {
        if(attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
