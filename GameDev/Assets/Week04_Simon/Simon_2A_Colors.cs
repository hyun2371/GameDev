using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon_2A_Colors : MonoBehaviour
{
    Color DefaultColor; //디폴트 색상
    Dictionary<string, Color> ActiveColors; //버튼 눌렀을 때 표시되는 색상
    AudioSource Audio;
    bool isInterActive = true; //버튼 비활성화
    float brightenDelay, darkenDelay; //버튼이 켜져 있는 시간, 어두운 상태가 유지되는 시간
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        //디폴트; 저장 게임 오브젝트에서 색상 가져옴(랜더러 사용)
        DefaultColor = GetComponent<Renderer>().material.color;

        //채도가 높은 색상은 딕셔너리에서 가져옴
        ActiveColors = new Dictionary<string, Color>
        {
            {"Blue", Color.blue },
            {"Yellow", Color.yellow },
            {"Green", Color.green },
            {"Red", Color.red }
        };
        Audio = GetComponent<AudioSource>();
        isInterActive = true;
    }

    void PlayAudio()
    {
        Audio.Play();
    }

    public void Brighten() 
    {
        GetComponent<Renderer>().material.color = ActiveColors[gameObject.name];
    }

    public void Darken()
    {
        GetComponent<Renderer>().material.color = DefaultColor;
    }

  
    IEnumerator IBlink() //밝아졌다 어두워지도록
    {
        Brighten();
        yield return new WaitForSeconds(brightenDelay);

        Darken();
        yield return new WaitForSeconds(darkenDelay);
    }

    
    public void Blink(float brightenDelay, float darkenDelay)
    {
        PlayAudio();

        this.brightenDelay = brightenDelay;
        this.darkenDelay = darkenDelay;
        StartCoroutine(IBlink());  //코루틴으로 호출
    }

    public void SetColorsInteractableTo(bool inInteractive)
    {   //컬러 오브젝트를 활성화/비활성화
        this.isInterActive = inInteractive;
    }

    private void OnMouseDown()
    {
        if (isInterActive) //사용자 차례
        {   //버튼이 어두우면
            if (GetComponent<Renderer>().material.color == DefaultColor)
            { //버튼 누를 수 있음
                PlayAudio();
                Brighten();
            }
        }
    }

    private void OnMouseUp() //마우스에서 손을 뗐을 때
    {
        if (isInterActive) //플레이어턴
        {
            Darken();
            AddColorToPlayersSequence(); 
        }
    }

    private void AddColorToPlayersSequence()
    {   //플레이어가 누른 색상 토대로 맞게 눌렀는지 확인
        GameObject.Find("Game").GetComponent<Simon_2A_Game_>().AddColorToPlayersSequence(gameObject.name);
    }
}
