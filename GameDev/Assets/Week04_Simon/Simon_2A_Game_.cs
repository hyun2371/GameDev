using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simon_2A_Game_ : MonoBehaviour
{   //P.S: �÷��̾� ���ʰ� �� ������ �ʱ�ȭ��
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
        Init(); //�ʱ�ȭ
        PlaySimonsTurn(); //���̸� ���ʺ���
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
        //PlayerPref ->���� �� ���� ������ ����, ������Ʈ�� �������� �� �����ߴ� ���� ������ �� ����
        GameObject.Find("MaxScoreValue").GetComponent<Text>().text = PlayerPrefs.GetInt("maxScore").ToString();
    }

    void DisplayScore(int score)
    {
        //text�� ������ ��ȯ->int.Parse()
        int maxScore = int.Parse(GameObject.Find("MaxScoreValue").GetComponent<Text>().text);
        if (score > maxScore)
        {
            maxScore = score; //����
            PlayerPrefs.SetInt("maxScore", maxScore); //PlayerPrefs�� ����
        }
        GameObject.Find("ScoreValue").GetComponent<Text>().text = score.ToString();
        GameObject.Find("MaxScoreValue").GetComponent<Text>().text = maxScore.ToString();
    }


    //4���� ������Ʈ Ȱ��ȭ ���� ����
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
        SetColorsInteractableTo(false); //���̸� ���ʷ� �Ѿ�Ƿ� ����ڰ� ��ư ������ ���ϵ��� ��
    }

    public void PlaySimonsTurn()
    {
        StartCoroutine(IPlaySimonsTurn());
    }


    IEnumerator IPlaySimonsTurn() //���̸� ����
    {
        SetColorsInteractableTo(false); //����ڰ� ��ư ������ ���ϵ��� ��

        string RandomColor = Colors[Random.Range(0, Colors.Length)]; //���� ���� ����
        SimonsSequence.Add(RandomColor); //����Ʈ�� ���� �߰�

        yield return new WaitForSeconds(1f); //wait for GameObject to be Active 

        for (int i = 0; i < SimonsSequence.Count; i++) //�ϳ��� ������
        {
            GameObject.Find(SimonsSequence[i]).GetComponent<Simon_2A_Colors>().Blink(0.2f, 0.3f); //0.2�� ������ 0.3�� ����
            yield return new WaitForSeconds(0.5f); //�������� ������ ó��
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
        if (HasPlayerPressedTheRightColor(PlayersColor)) //�°� ��������
        {
            PlayersSequence.Add(PlayersColor);

            if (PlayersSequence.Count == SimonsSequence.Count) //�÷��̾ ���̸��� ������ ��ư ��� ����
            {
                DisplayScore(SimonsSequence.Count);
                PlayersSequence.Clear(); //���� ����� ���� ���� ����� �Է� �ʱ�ȭ
                PlaySimonsTurn(); //���̸��� ���ʷ� �ѱ�
            }
            yield return new WaitForSeconds(1f); //�� ���� ������ 1�ʰ� ������
        }

        else //�÷��̾ Ʋ���� ��
        {
            DisplayScore(SimonsSequence.Count - 1); //���� ���� ǥ��
            EndGame(); //���� ����
            getIntro();
            Invoke("getIntro2", 2);
            yield return new WaitForSeconds(1f);
        }
    }

    bool HasPlayerPressedTheRightColor(string PlayersColor) //������ ��ư�� ��������
    {
        if (PlayersColor == SimonsSequence[PlayersSequence.Count]) //�� ��
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
