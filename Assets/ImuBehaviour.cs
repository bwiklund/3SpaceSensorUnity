using UnityEngine;
using System.Collections;

public class ImuBehaviour : MonoBehaviour {
  IImu imu;

  void Start() {
    imu = new ThreeSpaceImu();
    imu.Start();
  }

  void OnApplicationQuit() {
    imu.Stop();
  }

  void Update() {
    transform.rotation = imu.LatestRotation;
  }
}
