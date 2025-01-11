<div align="center">
  
# Unduck_XR Made with Unity

<p align="center"><img src="https://github.com/user-attachments/assets/5488a343-1f6e-443b-b21b-6c48b81bc194"></p>


---
## 수상내역

<div align="center"> 안양대학교 2024 캡스톤디자인 경진대회 (대상)</div>

![KakaoTalk_20250111_225124760](https://github.com/user-attachments/assets/2f493ca0-eab6-4ac3-88df-8b3815d51d9d) | ![KakaoTalk_20250111_225124760_01](https://github.com/user-attachments/assets/0e834330-3047-44d6-9d0e-f3d3e4996fbb)
---|---|

---
## 모든 영상보기

https://youtube.com/playlist?list=PLIdj2GUX0wT9xt-ytokkzKiZ6FPiE4unq&si=wNix3BXkzEe9DpQW

---
## Unduck의 목표

Meta Quest2를 기반으로 한 이 VR, AR, MR (XR, 확장 현실)체험은 사용자가 몰입할 수 있는 스토리와 재미있는 미니게임을 결합하여 제공합니다. 기존 Meta Quest2의 부족한 MR 경험을 보완하고, 다양한 체험을 통해 새로운 차원의 재미를 선사하는 것이 목표입니다.

---
## Unduck만의 특징

*체험프로그램에 포함된 스토리*

사용자는 게임의 스토리에 따라 진행하며, 각 단계에서 다양한 미니게임을 통해 이야기를 이어나갑니다. 이는 사용자에게 깊은 감정적 연결을 제공합니다.


*구 하드웨어로 즐길 수 있는 다양한 체험*

현재 나와있는 Quest Pro, Quest3에 비해 부족한 기능들 면에서 Quest2로 VR, AR, MR을 통해 다채로운 환경과 상황을 체험할 수 있게 만들었습니다. 각 체험은 사용자의 호기심을 자극하고 흥미를 유발합니다.

---
## 시스템 구성도
<p align="center"><img src="https://github.com/user-attachments/assets/ed557b13-129b-4a7d-b918-cdfeb770b55a"></p>

---
## 스테이지 별 주요 기술
### MainMenu

![메인메뉴](https://github.com/user-attachments/assets/c72540a2-2bf2-4c5d-8327-ff7784bb2994)

메인메뉴에서 오브젝트를 잡기 상호작용을 사용할 수 있고 메뉴를 직접 열어 컨트롤러를 위치하고 A 버튼을 누르면 게임이 시작됨.

### Stage1

*NPCController and OVRCameraRIGController*

![NPCController](https://github.com/user-attachments/assets/f7524f2f-b4e6-451b-92cf-e4dcc73612a7)

NPC Area에 Trigger 되면 Dialogue와 함께 OVRCamera가 움직이게됨.

*Two Hands Grab and Destroy Walls*

![MazeMap](https://github.com/user-attachments/assets/dcd32271-0ce7-4e17-9921-83f6d6b1915c)

Two Hands Grab으로 망치를 자유롭게 Grab 가능하면 돌리기가 가능하고, 이 망치를 이용하여 벽을 부술 수 있음.

*MRUK and ObjectSlice*

![Golem2](https://github.com/user-attachments/assets/e85ed1fe-715d-4c26-8efa-780727c80f13)

MRUK를 이용하여 미리 설정한 방구조에서 Bed 와 Table을 인식하여 오브젝트를 설치하여 안전을 지킬 수 있도록하고,

![GolemSlice](https://github.com/user-attachments/assets/87228c3a-9f17-486c-986b-dc6d08eb22d1)

 Ezy-Slice 사용하여 오브젝트를 자를 수 있게함.

*Ray Grab and BatContorller*

![RayInteraction](https://github.com/user-attachments/assets/7b5d8baf-4b52-4784-9f11-e048f93a8c3b)

Ray Grab을 이용해 멀리 있는 오브젝트를 선택하여 잡을 수 있게되고, 

![BatController](https://github.com/user-attachments/assets/0278bc17-66ee-4f75-9068-172534bb83b6)

Bat를 휘두르면 상대 몬스터에게 구체 오브젝트가 날라가게 됨.

### Stage2

*Grab and AI Nav*

![Potion](https://github.com/user-attachments/assets/0180809e-0a29-42b0-92b5-0ebb9333bddc)

포션을 손으로 직접 주워 박스로 가져갈 수 있으며, 

![zombie](https://github.com/user-attachments/assets/80ca4e3a-9dc6-4c4c-b22f-997b6f0a2cf0)

좀비 몬스터는 AI Nav를 통해 플레이어를 따라오게함.

*Ray Pointer*

![colortile](https://github.com/user-attachments/assets/b6f3e358-c4ff-4f00-9614-549c8fc449f4)

Ray Interaction을 이용하여 멀리 있는 블럭타일의 색을 변경할 수 있도록 함.

### Stage1 and Stage2

*MRUK, Passthrough Falsh and Invisible Object*

![FloorHak](https://github.com/user-attachments/assets/45cdf220-e7b1-4a58-9140-97d1d1b6840b)

방 구조에서 Floor를 인식하여 가구가 없는 Floor에서만 학이 랜덤으로 생성되도록 하고, 

![InvisibleHak](https://github.com/user-attachments/assets/cf4da47b-66f1-4c04-819e-5bec3849e26c)

가구 뒤에 있는 학은 보이지 않도록 설계됨.

![WeaponController](https://github.com/user-attachments/assets/0b22bcb6-a8c2-4e41-b09c-f2ddf09d5b9d)

십자가 무기를 통해 몬스터를 퇴치할 수 있다. 플래시를 이용하면 어두워진 현실 공간 화면을 밝힐 수 있게된다.

![Mole2](https://github.com/user-attachments/assets/7673c2fc-bebf-4cae-a3db-3cb5bf179e27)

두더지 게임 또한 침대 혹은 테이블에서만 생성이 되고, 망치도 테이블에서만 생성이 된다. 

### Practice Mode

![PracticeMode](https://github.com/user-attachments/assets/ef66db35-4d49-4057-9b72-d8bb4ac386f8)

체험 모드는 메인 메뉴에서 실행 할 수 있으며 인게임 메뉴를 통해 쉽게 메인메뉴와 왕래할 수 있다.

메뉴 또한 Ray Interaction을 이용한 UI로 스크롤 할 수 있도록 했다.

### 사용된 자료

https://github.com/UnduckProject/Assets_Source
</div>

### 팀원: 강형진, 문경만
### 제작: 2024.07 - 2024.10
