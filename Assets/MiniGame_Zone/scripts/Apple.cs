using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame_Zone.Scripts
{
    public class Apple : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) //나와 부딪힌 상대방의 정보 Collider other
        {
            if (other.CompareTag ("Player"))
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.AddScore(1);
                }
                Destroy(gameObject);
            }
        }
    }
}

