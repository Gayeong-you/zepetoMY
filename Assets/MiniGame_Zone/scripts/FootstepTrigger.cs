using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame_Zone.scripts
{
    public class FootstepTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            // 'Player' 태그를 가진 오브젝트가 발판에 닿았을 때만 작동
            if (other.CompareTag("Player"))
            {
                // 씬 로더를 찾아서 마녀의 방으로 이동하는 함수 호출
                FindObjectOfType<SceneLoader>().LoadWitchRoom();
            }
        }
    }
}



