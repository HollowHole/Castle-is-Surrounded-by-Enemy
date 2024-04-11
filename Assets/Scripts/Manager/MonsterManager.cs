using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


public class MonsterSpawner : MonoBehaviour
{

    public LevelSO levelSO;
    public GameObject start;

    //�ܲ���
    private int waveTotalNum;
    //��ǰ����
    private int waveCount = 0;
    //ÿһ����ˢ���ļ��ʱ��
    private int[] waveInterval;
    //ÿ��������
    private List<List<KeyValuePair<int, int>>> MonstersPerWave;

    //�²����ֵ���
    private float nextWaveCountDown = 0;

    private float myTime = 0;

    private int spawnMonsterIndex = 0;
    private int spawnMonsterCount = 0;

    private void Awake()
    {

        waveTotalNum = levelSO.waveTotalNum;
        waveInterval = levelSO.waveInterval;
        MonstersPerWave = levelSO.MonstersPerWave;
    }


    //��������չ����start��������ʾ��һ���������ɵ���ʱnextWaveCountDown
    private void Update()
    {
        if (waveCount >= waveTotalNum)
        {
            return;
        }
        myTime += Time.deltaTime;
        if (nextWaveCountDown <= 0 && myTime > Globle.spawnInterval)
        {
            myTime -= Globle.spawnInterval;
            bool aMonsterIsSpawned = false;
            while (!aMonsterIsSpawned)
            {
                if (MonstersPerWave[waveCount][spawnMonsterIndex].Value > spawnMonsterCount)
                {
                    //ͨ��ID�ҵ��������
                    int monsterIndex = MonstersPerWave[waveCount][spawnMonsterIndex].Key;
                    GameObject generatedMonster = Instantiate(levelSO.monsters[monsterIndex], start.transform.position, Quaternion.identity);
                    aMonsterIsSpawned = true;
                    spawnMonsterCount++;
                }
                else if (spawnMonsterIndex + 1 < MonstersPerWave[waveCount].Count)
                {
                    spawnMonsterIndex++;
                    spawnMonsterCount = 0;
                }
                else
                {
                    Debug.Log("waveEnd!");
                    spawnMonsterCount = 0;
                    spawnMonsterIndex = 0;
                    if (waveInterval.Length < waveCount)
                    {
                        nextWaveCountDown = waveInterval[waveCount];
                    }
                    waveCount++;
                    break;
                }
            }
        }
        else if (nextWaveCountDown > 0 && myTime > 1f)
        {
            myTime -= 1f;
            nextWaveCountDown--;
        }



    }

}
