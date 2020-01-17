using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast : MonoBehaviour
{
    private Transform tr;   //자신의 Transform 컴포넌트를 저장할 변수
    private Ray ray;        //생성할 광선
    private RaycastHit hit; //광선끝에 충돌한 충돌정보를 저장할 구조체

    [Range(5.0f, 20.0f)]
    public float distance = 20.0f;

    public Animator crossHair;

    void Start()
    {
        tr = GetComponent<Transform>();
        //tr = transform;
    }

    void Update()
    {
        //광선을 생성
        ray = new Ray(tr.position, tr.forward);
        //광성의 시각화
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);

        //
        if (Physics.Raycast(ray, out hit, distance, 1<<8 | 1<<9))
        {
            MoveCtrl.isStopped = true;
        }
        else
        {
            MoveCtrl.isStopped = false;
        }
    }
}
