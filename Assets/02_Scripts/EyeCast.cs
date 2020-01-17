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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
