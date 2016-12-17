using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rogueSystem : MonoBehaviour {
    public string MapCodeFile;
    private List<string> MapCode;

    public GameObject floorGen;
    public GameObject EnemyGen;

    private List<int> floorCode;

    void Awake()
    {
        floorCode = new List<int>();
        floorCode.Add(1);
        //floorCode[0] = 1;
        bool _FinishFloorGen = floorGen.GetComponent<floorGen>().makeFloor(floorCode);

        Debug.Log("FloorGen = " + _FinishFloorGen);
    }
}
