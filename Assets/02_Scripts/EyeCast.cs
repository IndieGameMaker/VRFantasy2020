using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EyeCast : MonoBehaviour
{
    private Transform tr;   //자신의 Transform 컴포넌트를 저장할 변수
    private Ray ray;        //생성할 광선
    private RaycastHit hit; //광선끝에 충돌한 충돌정보를 저장할 구조체

    [Range(5.0f, 20.0f)]
    public float distance = 20.0f;

    public Animator crossHair;

    private GameObject prevButton = null;
    private GameObject currButton = null;

    public float selectedTime = 1.0f;
    private float passedTime  = 0.0f;
    private Image circleBar;
    private bool isClicked = false;

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
            crossHair.SetBool("IsLook", true);
            LookButton();
        }
        else
        {
            MoveCtrl.isStopped = false;
            crossHair.SetBool("IsLook", false);
            ReleaseButton();
        }
    }

    void LookButton()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        //
        if (hit.collider.gameObject.layer != 8) return;

        currButton = hit.collider.gameObject;
        circleBar = currButton.GetComponentsInChildren<Image>()[1];

        //새로운 버튼을 응시했을 때
        if (currButton != prevButton)
        {
            ButtonInit();

            //새로운 버튼에 OnPointerEnter 이벤트 전달
            ExecuteEvents.Execute(currButton, data, ExecuteEvents.pointerEnterHandler);
            //이전 버튼에 OnPointerExit 이벤트를 전달
            ExecuteEvents.Execute(prevButton, data, ExecuteEvents.pointerExitHandler);
            prevButton = currButton;
        }
        else
        {  //계속 동일한 버튼을 응시하고 있을 경우
            passedTime += Time.deltaTime;
            circleBar.fillAmount = passedTime / selectedTime; // 0.0f ~ 1.0f

            if (!isClicked && passedTime >= selectedTime)
            {
                Debug.Log("Clicked");
                ExecuteEvents.Execute(currButton, data, ExecuteEvents.pointerClickHandler);
                isClicked = true;
            }
        }
    }

    void ReleaseButton()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        if (prevButton != null)
        {
            ExecuteEvents.Execute(prevButton, data, ExecuteEvents.pointerExitHandler);
            prevButton.GetComponentsInChildren<Image>()[1].fillAmount = 0.0f;

            prevButton = null;
        }
    }

    void ButtonInit()
    {
        isClicked = false;
        passedTime = 0.0f;
        if (circleBar != null)
        {
            circleBar.fillAmount = 0.0f;
        }
    }
}
