using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanController : MonoBehaviour
{
    // ������ġ
    public Transform[] enemySpwans;
    // �� ������
    public GameObject[] enemyGameObject;
    // �ð��� ��� ����
    float time;
    // �� ���� �ð�
    float respwanTime;
    // �� ���� ����
    int enemyCount;
    // ���� ���� ������ �����ϴ� �迭
    int[] randomCount;
    // ���̺� >> ���� ���
    int wave;
    // �÷��̾� ����
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //�ʱⰪ����
        time = 0;
        respwanTime = 4.0f;
        enemyCount = 5;
        randomCount = new int[enemyCount];
        wave = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    // �ð��� üũ�ϴ� �Լ�

    void Timer()
    {
        time += Time.deltaTime;
        if (time > respwanTime)
        {
            RandomPos();
            EnemyCreate();
            wave++;
            time -= time;
        }
    }

    void RandomPos()
    {
        // ���� ��ġ�� ���� ����
        for (int i = 0; i < enemyCount; i++)
        {
            randomCount[i] = Random.Range(0, 9);
        }
    }

    void EnemyCreate()
    {
        if (player == null)
            return;
        for (int i = 0; i < enemyCount; i++)
        {
            // ���� �� ����
            int tmpCnt = Random.Range(0, enemyGameObject.Length);
            // ����
            GameObject tmp = GameObject.Instantiate(enemyGameObject[tmpCnt]);
            // ��ġ
            tmp.transform.position = enemySpwans[randomCount[i]].position;
            // ���� ��ġ�� �����ϱ� ���� ������ ��ġ �� ����
            float tmpX = tmp.transform.position.x;
            float result = Random.Range(tmpX - 2.0f, tmpX + 2.0f);
            tmp.transform.position = new Vector3(result, tmp.transform.position.y, tmp.transform.position.z);
        }
    }
}
