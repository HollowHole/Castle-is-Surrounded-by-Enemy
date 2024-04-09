using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterSpawner : MonoBehaviour
{
    public LevelSO levelSO;
    public GameObject start;
    //�ܲ���
    private int waveTotalNum;
    //��ǰ����
    private int waveCount = 0;
    //ÿһ����ˢ���ļ��ʱ�� ��SO��ֵ
    private int[] waveInterval;
    //�²����ֵ���
    private int nextWaveCountDown = 0;

    //����waveCount+MonsterID(1+2),spawnNum 
    //102,3 ��1��IDΪ2�Ĺ�����3ֻ
    //private Dictionary<int,int>;

    //�ĳɶ���
    //private list<int> mosnterToBeSpawned; SO
    private int[] monstersPerWave = { 1 };
    private int spawnMonsterCount = 0;

    private void Awake()
    {

        waveTotalNum = levelSO.waveTotalNum;
        waveInterval = new int[waveTotalNum]; waveInterval[0] = 1;
    }
    
    
    
    private void Update()
    {
        if (waveCount >= waveTotalNum)
        {
            return;
        }
        if (nextWaveCountDown <= 0)
        {
            if (spawnMonsterCount < monstersPerWave[waveCount])
            {
                //ͨ��ID�ҵ��������
                GameObject generatedMonster = Instantiate(levelSO.monsters[0], start.transform.position, Quaternion.identity);
                spawnMonsterCount++;
            }
            else
            {
                Debug.Log("waveEnd!");
                spawnMonsterCount = 0;
                nextWaveCountDown = waveInterval[waveCount];
                waveCount++;
            }
        }
        else
        {
            nextWaveCountDown--;
        }


    }
}
