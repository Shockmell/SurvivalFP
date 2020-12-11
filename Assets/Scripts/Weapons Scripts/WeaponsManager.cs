using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField]
    private WeaponsHandler[] weapons;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        weapons[currentIndex].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectWeapon(5);
        }
    }

    void SelectWeapon(int idx)
    {
        if(currentIndex == idx)
        {
            return;
        }

        weapons[currentIndex].gameObject.SetActive(false);
        weapons[idx].gameObject.SetActive(true);

        currentIndex = idx;
    }

    public WeaponsHandler GetCurrentWeapon()
    {
        return weapons[currentIndex];
    }
}
