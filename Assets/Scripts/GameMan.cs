﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public static GameMan Instance { get; private set; }
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public GameObject PlayerAgent;
    public GameObject projectileNormalPrefab;
    public List<GameObject> projectileNormal;
    public int projectileNomralIndex = -1;
    [HideInInspector]
    public GameObject[] playerProjArr;
    public GameObject playerProjParent;
    public GameObject playerProjPrefab;
    private int playerProjIndex = 0;
    private int ppaLen = 300;

    public GameObject testObj;
    public GameObject testObj2;


    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {

        playerProjArr = new GameObject[ppaLen];
        for (int i = 0; i < ppaLen; i++) {
            playerProjArr[i] = Instantiate(playerProjPrefab, playerProjParent.transform);
            playerProjArr[i].SetActive(false);
        }
        
        for (int i = 0; i < 10; i++)
        {
            GameObject projectileObj  = Instantiate(projectileNormalPrefab);
            projectileObj.SetActive(false);
            projectileNormal.Add(projectileObj);
        }
    }

    public GameObject GetPlayerProj() {
        playerProjIndex++;
        if (playerProjIndex >= ppaLen) {
            playerProjIndex = 0;
        }
        return playerProjArr[playerProjIndex];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            testObj.GetComponent<Enemy>().StartFire();
            testObj2.GetComponent<Enemy>().StartFire();
        }
    }

    public int GetEnemyProjectile(int projectileType)
    {
        switch (projectileType)
        {
            case 0: //Normal Projectile
                projectileNomralIndex++;
                return projectileNomralIndex;
            case 1:
                return 0;
        }
        return -1;
    }

}