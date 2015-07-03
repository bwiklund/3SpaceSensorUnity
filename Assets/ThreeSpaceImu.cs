using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

class ThreeSpaceImu : IImu {
  public Quaternion LatestRotation { get; private set; }

  SerialPort serialPort;
  Thread thread;

  public void Start() {
    Console.Out.WriteLine("Serial ports:");
    foreach (var port in SerialPort.GetPortNames()) {
      Console.Out.WriteLine(port);
    }

    serialPort = new SerialPort("COM4");
    serialPort.Open();

    thread = new Thread(Read);
    thread.Start();
  }

  public void Stop() {
    if (serialPort != null) serialPort.Close();
    if (thread != null) thread.Abort();
  }

  void Read() {
    while (true) {
      serialPort.WriteLine(":0");
      var line = serialPort.ReadLine();

      // 3space quaternions are "x,y,z,w" order.
      var parts = line.Split(',');
      LatestRotation = new Quaternion(
        float.Parse(parts[0]),
        float.Parse(parts[1]),
        float.Parse(parts[2]),
        float.Parse(parts[3])
      );
    }
  }
}
