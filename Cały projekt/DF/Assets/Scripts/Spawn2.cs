using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Wave
{
    public List<int> enemys = new List<int>();
    public Wave(List<int> enemys2)
    {
        enemys = enemys2;
    }


}
public class Spawn2 : MonoBehaviour {
    public List<Wave> waves = new List<Wave>();
    public int secondBetweenWaves=15;
    public string directionOfSpawn = "toDown";
    int indexOfWaveToRelesed = 0;
    public int countOfWaves=7;


    //liczba wrogow ogolnie do wypuszczenia, na indeksie 0 jest enemy na indeksie 1 jest prefab enemy1 itp
    public List<int> enemys;
    

    void CalculateWaves()
    {
        List<int> calculatedEnemy = new List<int>();
        foreach (int a in enemys )
        {
            calculatedEnemy.Add((int)Math.Floor(((double)(a)/(double)(countOfWaves))*2));
        }
        Wave oneWave = new Wave(calculatedEnemy);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
