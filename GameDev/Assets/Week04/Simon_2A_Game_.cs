using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simon_2A_Game_ : MonoBehaviour
{   //P.S: 플레이어 차례가 될 때마다 초기화함
    List<string> SimonsSequence, PlayersSequence;
    string[] Colors;
  

    private void Start()
    {
      
    }
    public void getStart()
    {
        getIntro();
        Invoke("getIntro2", 2f);
        Invoke("realStart",4f);
    }

    public void realStart()
    {
        GameObject.Find("StartButton").SetActive(false);
        Init(); //초기화
        PlaySimonsTurn(); //사이먼 차례부터
    }

    public void Restart()
    {
        Init();
        PlaySimonsTurn();
    }

    void Init()
    {
        SimonsSequence = new List<string>();
        PlayersSequence = new List<string>();
        Colors = new string[] { "Green", "Red", "Blue", "Yellow" };

        DisplayScore(0);
        //PlayerPref ->씬과 씬 사이 데이터 전달, 프로젝트를 껐다켰을 때 세팅했던 값을 가져올 수 있음
        GameObject.Find("MaxScoreValue").GetComponent<Text>().text = PlayerPrefs.GetInt("maxScore").ToString();
    }

    void DisplayScore(int score)
    {
        //text를 정수로 변환->int.Parse()
        int maxScore = int.Parse(GameObject.Find("MaxScoreValue").GetComponent<Text>().text);
        if (score > maxScore)
        {
            maxScore = score; //갱신
            PlayerPrefs.SetInt("maxScore", maxScore); //PlayerPrefs에 저장
        }
        GameObject.Find("ScoreValue").GetComponent<Text>().text = score.ToString();
        GameObject.Find("MaxScoreValue").GetComponent<Text>().text = maxScore.ToString();
    }


    //4개의 오브젝트 활성화 상태 제어
    void SetColorsInteractableTo(bool isInteractive)
    {
        foreach (string color in Colors)
        {
            GameObject.Find(color).GetComponent<Simon_2A_Colors>().SetColorsInteractableTo(isInteractive);
        }
    }

    void EndGame()
    {
        print("Your Failed: Click button to Restart.");
        SetColorsInteractableTo(false); //사이먼 차례로 넘어가므로 사용자가 버튼 누르지 못하도록 함
    }

    public void PlaySimonsTurn()
    {
        StartCoroutine(IPlaySimonsTurn());
    }


    IEnumerator IPlaySimonsTurn() //사이먼 차례
    {
        SetColorsInteractableTo(false); //사용자가 버튼 누르지 못하도록 함

        string RandomColor = Colors[Random.Range(0, Colors.Length)]; //랜덤 색깔 추출
        SimonsSequence.Add(RandomColor); //리스트에 색깔 추가

        yield return new WaitForSeconds(1f); //wait for GameObject to be Active 

        for (int i = 0; i < SimonsSequence.Count; i++) //하나씩 보여줌
        {
            GameObject.Find(SimonsSequence[i]).GetComponent<Simon_2A_Colors>().Blink(0.2f, 0.3f); //0.2초 켜지고 0.3초 꺼짐
            yield return new WaitForSeconds(0.5f); //수동으로 딜레이 처리
        }
        SetColorsInteractableTo(true);
    }

    
    void getIntro()
    {
        string[] cg = new string[] { "Blue", "Yellow", "Red", "Green" };
        for (int i = 0; i < 4; i++)
        {
            GameObject.Find(cg[i]).GetComponent<Simon_2A_Colors>().Brighten();


        }
        
    }

    void getIntro2()
    {
        Debug.Log("Get ready for it!");
        string[] cg = new string[] { "Blue", "Yellow", "Red", "Green" };
        for (int i = 0; i < 4; i++)
        {
            GameObject.Find(cg[i]).GetComponent<Simon_2A_Colors>().Darken();

        }
       
    }

   
    public void AddColorToPlayersSequence(string PlayersColor)
    {
        StartCoroutine(IAddColorToPlayersSequence(PlayersColor));

    }

    IEnumerator IAddColorToPlayersSequence(string PlayersColor)
    {
        if (HasPlayerPressedTheRightColor(PlayersColor)) //맞게 눌렀으면
        {
            PlayersSequence.Add(PlayersColor);

            if (PlayersSequence.Count == SimonsSequence.Count) //플레이어가 사이먼이 제시한 버튼 모두 맞춤
            {
                DisplayScore(SimonsSequence.Count);
                PlayersSequence.Clear(); //다음 라운드로 가기 위해 사용자 입력 초기화
                PlaySimonsTurn(); //사이먼의 차례로 넘김
            }
            yield return new WaitForSeconds(1f); //한 턴이 끝나면 1초간 딜레이
        }

        else //플레이어가 틀렸을 때
        {
            DisplayScore(SimonsSequence.Count - 1); //이전 점수 표시
            EndGame(); //게임 종료
            getIntro();
            Invoke("getIntro2", 2);
            yield return new WaitForSeconds(1f);
        }
    }

    bool HasPlayerPressedTheRightColor(string PlayersColor) //적절한 버튼을 눌렀는지
    {
        if (PlayersColor == SimonsSequence[PlayersSequence.Count]) //값 비교
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
