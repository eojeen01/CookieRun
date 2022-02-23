# CookieRun

# 1. 기능 설명
* 플레이어는 최대 2명까지 접속 가능하다.
* 캐릭터를 선택할 수 있다. 능력치는 캐릭터마다 다르다.
* 달리기를 시작하는 순간부터 일정 점수에 도달한 순간까지의 시간을 기준으로 순위가 정해진다.
* 달리는 중간에 랜덤으로 배치된 장애물을 피해서 달려야 한다. 장애물에 닿을 경우 체력이 줄어든다.
* 총 3가지의 아이템이 맵 내에 랜덤으로 배치된다. (속도 증가, 감소, 체력 증가)
* 맵 내에 랜덤으로 배치된 코인을 먹으면 점수가 올라가고, 점수가 200점이 되면 게임이 끝난다.

# 2. Class Diagram
![image](https://user-images.githubusercontent.com/76842423/155287470-e1e47495-51d8-40e3-b889-5f6e0cb41834.png)

# 3. Server GUI

![image](https://user-images.githubusercontent.com/76842423/155287956-c49a1cdf-aea2-48b0-8bec-17e1c86b243a.png)

* Open 버튼을 클릭하면 Server Open이라는 문구가 뜨면서 서버가 열린다. Clear 버튼을 클릭하면 listBox가 비워진다. 
* 클라이언트가 접속하면 Server Connected라는 문구와 함께 접속한 인원 수와 클라이언트가 선택한 캐릭터 번호를 띄운다.
* 클라이언트의 결과창이 닫히면 게임을 끝내는데 걸린 시간을 아이디와 함께 밀리 초로 나타낸다.

# 4. Client GUI

![image](https://user-images.githubusercontent.com/76842423/155288803-03d09785-7209-4817-8ea6-b74262d9eb89.png)

PLAY 버튼을 클릭하면 MouseDown, MouseUp 이벤트 때문에 버튼이 작아졌다가 커지며 다음 폼을 연다. 기존 폼은 닫힌다.

![image](https://user-images.githubusercontent.com/76842423/155288896-037503f4-5b4c-4559-99e9-81afef468683.png)

textBox에 닉네임을 입력하고 양쪽에 있는 버튼을 누르면 3가지의 캐릭터가 보인다. Ready 버튼을 누르면 서버와 연결되고 다음 폼으로 넘어간다. 기존의 폼은 닫힌다.

![image](https://user-images.githubusercontent.com/76842423/155288982-7e36bf2d-7170-4114-b8ad-434eb921ba8a.png)

스페이스바를 누르면 캐릭터가 점프하고 아래 방향키를 누르면 슬라이드 동작을 한다. 캐릭터가 장애물에 닿으면 체력이 깎이고, 코인을 먹으면 점수가 오른다.

![image](https://user-images.githubusercontent.com/76842423/155289070-511fd544-bde6-46f1-9074-b1daceb804a1.png)

아이템과 플레이어 캐릭터가 닿으면 아이템의 Visible은 false로 변한다. 파란색 젤리는 속도를 느리게 하고, 핑크색 젤리는 체력을 증가시키고, 노란색 젤리는 속도를 빠르게 한다.

# 5. 특징 기술

* Timer와 switch를 이용한 달리기 모션

 -Timer를 실행시켜서 num 변수에 100ms 당 1씩 더한다. 
 -num 변수가 0일 때, 1일 때, 2일 때, 3일 때 각각 다른 이미지를 pictureBox에 넣는다.
 -num 변수의 값이 3이 넘어가면 num 값을 다시 0으로 정해서 무한 반복될 수 있게 한다.





