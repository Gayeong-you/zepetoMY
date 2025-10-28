using UnityEngine;

public class BedInteractor : MonoBehaviour
{
    private bool isPlayerNear = false;
    private SceneLoader sceneLoader; 

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        if (sceneLoader == null)
        {
            Debug.LogError("SceneLoader 스크립트를 찾을 수 없습니다.");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) // 2D로 변경
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("E키를 눌러보세요. 무시무시한 것들이 기다리고 있을지도..");
        }
    }
  
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (sceneLoader != null)
            {
                Debug.Log("씬 이동 시도: hidden_street");
                sceneLoader.LoadHiddenStreet(); 
            }
        }
    }
}