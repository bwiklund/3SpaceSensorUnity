using UnityEngine;
using System.Collections;

public interface IImu {
  void Start();
  void Stop();
  Quaternion LatestRotation { get; }
}
