using UnityEngine;
using System.Collections.Generic;
using System;

public class MapLoader : MonoBehaviour {

  private List<int> Load(string filePath) {
    TextAsset csv = Resources.Load(filePath) as TextAsset;
    List<string> csvElements = new List<string>();
    csvElements.AddRange(csv.text.Split(',','\n'));
    List<int> res = new List<int>();
    foreach (var s in csvElements) {
      int numVal;
      if (Int32.TryParse(s, out numVal)) {
        res.Add(numVal);
      }
    }
    return res;
  }
}
