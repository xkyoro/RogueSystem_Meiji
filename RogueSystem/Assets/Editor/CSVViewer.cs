using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CSVViewer : EditorWindow {
  TextAsset csv;

  Vector2 boxSize = new Vector2(50,50);
  int spacing = 10;

  List<List<string>> parsedList;

  Vector2 scrollPos;

  [MenuItem("Window/CSV Viewer")]
  public static void ShowWindow() {
    EditorWindow.GetWindow(typeof(CSVViewer));
  }

  void OnGUI() {
    GUILayout.Label("CSV File", EditorStyles.boldLabel);
    csv = (TextAsset)EditorGUILayout.ObjectField("File", csv, typeof(TextAsset), false);

    GUILayout.Label("CSV Boxes Parameters", EditorStyles.boldLabel);
    boxSize = EditorGUILayout.Vector2Field("Box Size", boxSize);
    spacing = EditorGUILayout.IntField("Spacing", spacing);

    GUILayout.Label("CSV Elements", EditorStyles.boldLabel);

    if (csv != null) {
      parsedList = new List<List<string>>();
      parsedList = LoadCSVElements();

      Vector2 arrayCount = CountMaxArray(parsedList);

      scrollPos = GUI.BeginScrollView(new Rect(0, 150, position.size.x, position.size.y - 150), scrollPos, new Rect(0, 0,50 + arrayCount.x * (boxSize.x + spacing) ,50 + arrayCount.y * (boxSize.y + spacing)));
      for (var i = 0; i < parsedList.Count; i++) {
        for (var j = 0; j < parsedList[i].Count; j++) {
          GUI.TextField(new Rect(30 + j * (boxSize.x + spacing),30 + i * (boxSize.y + spacing), boxSize.x, boxSize.y), parsedList[i][j]);
        }
      }
      GUI.EndScrollView();
    }
  }

  private List<List<string>> LoadCSVElements() {
    List<string> csvLines = new List<string>();
    List<List<string>> csvElements = new List<List<string>>();
    csvLines.AddRange(csv.text.Split('\n'));
    foreach (var line in csvLines) {
      List<string> splitLines = new List<string>();
      splitLines.AddRange(line.Split(','));
      if (!CheckForEmptyLine(splitLines)) {
        csvElements.Add(splitLines);
      }
    }
    return csvElements;
  }

  private bool CheckForEmptyLine(List<string> line) {
    bool res = true;
    foreach(var element in line) {
      if(element != "") {
        res = false;
      }
    }
    return res;
  }

  private Vector2 CountMaxArray(List<List<string>> csv) {
    Vector2 res = new Vector2();

    res.y = csv.Count;

    int max = 0;
    for (var i = 0; i < parsedList.Count; i++) {
      if(parsedList[i].Count > max) {
        max = parsedList[i].Count;
      }
    }

    res.x = max;

    return res;
  }
}
