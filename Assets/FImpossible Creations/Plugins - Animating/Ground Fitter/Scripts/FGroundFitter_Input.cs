using UnityEngine;

namespace FIMSpace.GroundFitter
{
    public class FGroundFitter_Input : FGroundFitter_InputBase
    {
        protected virtual void Update()
        {
            // 왼손 컨트롤러 입력 감지
            Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            // 점프 입력 감지
            if (OVRInput.GetDown(OVRInput.Button.One)) // One은 컨트롤러의 A 버튼에 해당합니다.
            {
                TriggerJump();
            }

            // 이동 방향 설정
            Vector3 dir = Vector3.zero;

            // 이동 방향 계산
            dir.x = thumbstick.x;
            dir.z = thumbstick.y;

            // 이동 벡터 정규화
            dir.Normalize();

            // 회전 각도 설정
            RotationOffset = Quaternion.LookRotation(dir).eulerAngles.y;

            // 이동 벡터 설정
            MoveVector = dir;

            // 스프린트 설정
            Sprint = OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp);

            // 컨트롤러에 값을 전달
            controller.Sprint = Sprint;
            controller.MoveVector = MoveVector;
            controller.RotationOffset = RotationOffset;
        }
    }
}
