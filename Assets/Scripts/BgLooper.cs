using UnityEngine;

public class BgLooper : MonoBehaviour
{
    [Header("배경 스크롤 설정")]
    // 배경 이동 속도. (아이템/똥의 이동 속도와 동일하게 설정했는지 체크.)
    public float scrollSpeed = 5f; 
    public float backgroundWidth = 14.2f; 

    void Update()
    {
        // 1. 배경을 왼쪽으로 이동
        // Time.deltaTime을 곱해 프레임 속도와 관계없이 일정한 속도로 이동시킵니다.
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 2. 배경의 중심 X 위치가 왼쪽으로 완전히 나갔는지 확인
        // 배경의 중심이 자신의 너비(-backgroundWidth)를 넘어서면, 화면에서 사라진 것입니다.
        if (transform.position.x < -backgroundWidth)
        {
            // 3. 배경을 현재 위치보다 오른쪽으로 '너비의 2배'만큼 이동시킵니다.
            // (옆에 있던 두 번째 배경의 바로 뒤로 이동하여 무한 반복을 만듭니다.)
            Vector3 offset = new Vector3(backgroundWidth * 2f, 0, 0);
            transform.position += offset;
        }
    }
}