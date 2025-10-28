using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 1. real_room -> hidden_street 이동 함수 (침대 상호작용에 연결)
    public void LoadHiddenStreet()
    {
        // 씬 이름을 직접 사용하여 로드
        SceneManager.LoadScene("hidden_street");
    }

    // 2. hidden_street -> witch_room 이동 함수 (마지막 발판에 연결)
    public void LoadWitchRoom()
    {
        // 씬 이름을 직접 사용하여 로드
        SceneManager.LoadScene("witch_room");
    }
}
