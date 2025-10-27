using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame_Zone.scripts
{
    public class ItemObstacleManager : MonoBehaviour
    {
        [Header("1. 프리팹 연결")] 
        
        public GameObject poopPrefab;
        public GameObject applePrefab;

        [Header("2. 생성 위치 및 시간 설정")] 
        
        public float lastSpawnX = 15f; //게임이 시작되자마자 플레이어와 부딪히지 않게 안전간격으로 생성
        
        //일정한 시간 간격으로 생성
        public float fixedSpawnInterval = 2f;
        public float nextSpawnTime;
        
        //화면 Y축 경계(최대/최소높이)
        public float spawnBoundaryY = 4f;

        private readonly float[] appleYPositions = new float[] { -3f, 0f, 3f };


        void Start() //다음생성타임에 타임을 담아준다
        {
            nextSpawnTime = Time.time;
        }

        void Update()
        {
            if (Time.timeScale > 0 && Time.time >= nextSpawnTime)
            {
                SpawnBatch(); // 다음 생성 시간을 고정된 간격(fixedSpawnInterval)으로 설정
                nextSpawnTime = Time.time + fixedSpawnInterval;
            }
        }

        private void SpawnBatch()
        {
            if (Random.Range(0f, 1f) < 0.5f)
            {
                SpawnPoops();
            }
            else
            {
                SpawnApples();
            }
        }


        private void SpawnPoops()
        {
            int count = Random.Range(1, 4); //응가 랜덤갯수결정(1~3개). 랜덤레인지는 마지막숫자를 미포함한다. 배열과 마찬가지로!
            float spawnX = lastSpawnX + Random.Range(8f, 12f);

            for (int i = 0; i < count; i++)
            {
                float randomY=Random.Range(-spawnBoundaryY, spawnBoundaryY);//위치는 랜덤
                Vector3 spawnPosition=new Vector3(spawnX,randomY,0);
                Instantiate(poopPrefab, spawnPosition, Quaternion.identity);
            }
            
            lastSpawnX = spawnX;
        }

        private void SpawnApples()
        {
            int count = Random.Range(3, 7); //3개에서 5개 사이에 사과생성
            float spawnX = lastSpawnX + Random.Range(10f, 15f); //다음 x위치 시작점
            float finalXEnd = spawnX;

            for (int i = 0; i < count; i++)
            {
                float currentX = spawnX + (i * 1.5f);
                float basePatternY=appleYPositions[i%appleYPositions.Length];
                float finalY = basePatternY + Random.Range(-0.5f, 0.5f);
                
                Vector3 spawnPosition=new Vector3(currentX,finalY,0);
                Instantiate(applePrefab, spawnPosition, Quaternion.identity);

                finalXEnd = currentX;// 가장 오른쪽 사과 위치 기록
            }
            lastSpawnX = finalXEnd;
        }
    }
}
