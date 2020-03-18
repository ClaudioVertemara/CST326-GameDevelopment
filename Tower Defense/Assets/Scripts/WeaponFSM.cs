using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponStates
{
  Idle,
  Target,
  Shoot
}

public enum WeaponParameters
{
  isTarget,
  targetDistroyed,
  newTarget
}


[RequireComponent(typeof(Animator))]
public class WeaponFSM : MonoBehaviour
{
  private Animator weapon;
  public GameObject bullet;
  public GameObject target;
  void Awake()
  {
    weapon = GetComponent<Animator>();
  }
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.A))
    {
      weapon.SetBool(WeaponParameters.isTarget.ToString(), !weapon.GetBool(WeaponParameters.isTarget.ToString()));
    }

    transform.LookAt(target.transform);
    

  }

  void Bang()
  {
    Debug.Log("Pow");
    GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
  }

}
