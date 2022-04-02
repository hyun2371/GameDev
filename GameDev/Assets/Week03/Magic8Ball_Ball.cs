using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Magic8Ball_Ball : MonoBehaviour
{
    bool isShake = false;
    //��鸱 ���� x,y,z ������ ���� �ٲ�
    //�ʱ� ��ġ ���� ����
    Vector3 DefaultPosition;

    float shakeMultiplier = 0.1f;
    float shakeDuration = 1f;
    public GameObject Ball_Number, Ball_Answer;

    string[] Answers =
    {   "It is certain.",
        "It is decidedly so.",
        "Without a doubt.",
        "Yes definitely.",
        "You may rely on it.",
        "As i see it yes.",
        "Most likely.",
        "Outlook good.",
        "Yes.",
        "Signs point to yes.",
        "Reply hazy try again.",
        "Ask again later.",
        "Better not tell you now.",
        "Cannot predict now.",
        "Concentrate and ask again.",
        "Don't count on it.",
        "My reply is no.",
        "My sources say no.",
        "Outlook not so good.",
        "Very doubtful."
    };

    // Start is called before the first frame update
    void Start()
    {
        DefaultPosition = transform.position;
        DisplayNumberBall();
    }

    // Update is called once per frame
    void Update()
    {
        ShakeOnCondition();
    }

    void ShakeOnCondition()
    {
        if (isShake)
        {   //x��, y��, z�࿡ ���� ������ ��(0~1)�� ����
            Vector3 RandomOffset = Random.insideUnitSphere;

            //���� ��鸱 �� ��ġ�� �ο�
            Vector3 RandomPosition = DefaultPosition + RandomOffset * shakeMultiplier;
            RandomPosition.z = DefaultPosition.z;
            transform.position = RandomPosition;
        }
    }

    void DisplayNumberBall()
    {
        Ball_Answer.SetActive(false);
        Ball_Number.SetActive(true);
    }

    void DisplayAnswerBall()
    {
        Ball_Answer.SetActive(true);
        Ball_Number.SetActive(false);
    }

    void DisplayAnswer()
    {
        string answer = Answers[Random.Range(0, Answers.Length)];
        print(string.Format("Answer: {0}", answer));
        GameObject Answer = GameObject.Find("Answer");
        Answer.GetComponent<TMPro.TextMeshPro>().text = answer;
    }

    //1�� ���� ���� ����, �Ŀ� ��鸲�� ���� (number->answer)
    public void ShakeBall()
    {
        StartCoroutine(IShakeUntil(shakeDuration));
    }
    //����
    IEnumerator IShakeUntil(float duration)
    {
        DisplayNumberBall();
        isShake = true;
        yield return new WaitForSeconds(duration);
        isShake = false;
        DisplayAnswerBall();
        DisplayAnswer();
    }

    private void OnMouseEnter()
    {
        // isShake = true;
        //DisplayNumberBall();
        //ShakeBall();
    }
    
    //���콺�� �� ������ ������
    private void OnMouseExit()
    {
        //isShake = false;
        //DisplayAnswerBall();
    }
}
