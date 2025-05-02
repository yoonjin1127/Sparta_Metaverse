using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float cameraSpeed = 5.0f;
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    // 플레이어 이동은 Update이므로 겹치지 않게 뒤에 처리
    private void LateUpdate()
    {
        // z축은 그대로 유지
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, camera.transform.position.z);

        // 보간
        camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, cameraSpeed * Time.deltaTime);

        // Translate를 이용한 이동
        // 캐릭터가 떨려서 변경
        //Vector3 dir = target.transform.position - camera.transform.position;
        //Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime);
        //camera.transform.Translate(moveVector);
    }
}
