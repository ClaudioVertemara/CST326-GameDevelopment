using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
  public float speed = 5;
  public float lifeTime = 5;
  private Rigidbody rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }
  void FixedUpdate()
  {
    rb.velocity = Vector3.forward * speed;
    lifeTime -= Time.fixedDeltaTime;
    Debug.Log(lifeTime);
    if (lifeTime < 0) Destroy(gameObject);
  }
}
