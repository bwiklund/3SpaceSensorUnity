using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {
  public Transform ballPrefab;

  float lastBallTime;
  float throwInterval = 1f;

  void FixedUpdate() {
    var now = Time.time;
    if (now - lastBallTime > throwInterval) {
      lastBallTime = now;
      ThrowBall();
    }
  }

  private void ThrowBall() {
    var ball = (Transform)Instantiate(ballPrefab, transform.position, Quaternion.identity);
    ball.GetComponent<Rigidbody>().velocity = new Vector3(0f, 7.5f, -8f) + Random.insideUnitSphere * 0.5f;
  }
}
