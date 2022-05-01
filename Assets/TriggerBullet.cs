using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class TriggerBullet : MonoBehaviour
{
  [SerializeField]
  GameObject bulletPrefab;

  public HandEnum handEnum;
  bool shoot = true;
  GameObject bullet;

  // Update is called once per frame
  void Update()
  {
    UpdateGesture();
  }

  void UpdateGesture()
  {
    var handState = NRInput.Hands.GetHandState(handEnum);

    if (handState == null) return;
    if (handState.pinchStrength > 0.6 && shoot)
    {
      shoot = false;

      bullet = GameObject.Instantiate(bulletPrefab);

      Pose p = handState.pointerPose;
      bullet.transform.position = p.position;

      bullet.GetComponent<Rigidbody>().AddForce(
        p.forward * 8, ForceMode.Impulse
      );

    }
    else if (!handState.isPinching)
    {
      shoot = true;
    }
  }

}
