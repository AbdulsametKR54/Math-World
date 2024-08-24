using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuestionsGenerator : MonoBehaviour
{
    public GameObject closeButton, pauseButton, homeButton;
    public GameObject firstStage, secondStage;
    public Text skorText, puanText, basariText;
    public Text questionText, soruSayisi;
    public Text a_answer, b_answer, c_answer, d_answer;
    public Text scoreboard, score;
    public Text time;
    int aAnswer, bAnswer, cAnswer, dAnswer, correctAnswer;
    int soru = 1, skor = 0, dogruCevaplananSoru = 0;
    float basari = 0f;
    float timer = 60f, countdown = 1f;
    string question;
    int sayi, g�n; 
    int words, equipment, price, names, distinct, deck;
    string w, e, n;
    void Start()
    {
        maker();
        scoreboard.text = "Scoreboard:";
        score.text = skor + "";
        soruSayisi.text = soru + ")";
        firstStage.SetActive(true);
        secondStage.SetActive(false);
    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            timer -= 1f;
            countdown = 1f; // Tekrar ba�latmak i�in
        }

        if (timer <= 0f)
        {
            puanPage();
        }
        time.text = "S�re: " + (int)timer;
        if(soru>25)
            puanPage();
    }
    void maker()
    {
        {
            sayi = Random.Range(2, 5);
            g�n = Random.Range(2, 15);
            words = Random.Range(1, 3);
            equipment = Random.Range(1, 4);
            price = Random.Range(4, 15);
            names = Random.Range(1, 4);
        }
        question = QuestionsEditor();
        questionText.text = question;
        AnswerEditor();
        soruSayisi.text = soru + ")";
    }
    string QuestionsEditor()
    {
        int probability = Random.Range(1, 4);
        switch (probability)
        {
            case 1:
                distinct = 2;
                question = "Bir inek g�nde " + sayi + " kova s�t veriyorsa " + g�n + " g�n'de ka� kova s�t verir?";
                correctAnswer = AnswerMaker(sayi, g�n);
                break;
            case 2:
                distinct = 2;
                question = "Bir kumbaraya g�nde " + sayi + " TL at�l�yorsa " + g�n + " g�n'de ka� TL birikir?";
                correctAnswer = AnswerMaker(sayi, g�n);
                break;
            case 3:
                distinct = 1;
                switch (words)
                {
                    case 1:
                        w = "d�zine";
                        deck = 12;
                        correctAnswer = AnswerMaker(deck, price);
                        break;
                    case 2:
                        w = "deste";
                        deck = 10;
                        correctAnswer = AnswerMaker(deck, price);
                        break;
                }
                switch (equipment)
                {
                    case 1:
                        e = "kalem";
                        break;
                    case 2:
                        e = "silgi";
                        break;
                    case 3:
                        e = "kalemtra�";
                        break;
                }
                switch (names)
                {
                    case 1:
                        n = "Ali";
                        break;
                    case 2:
                        n = "Ahmet Eren";
                        break;
                    case 3:
                        n = "Ay�e";
                        break;
                    case 4:
                        n = "J�lide";
                        break;
                }
                question = n + " k�rtasiyeden bir " + w + " " + e + " al�yorsa ve tanesi " + price + " TL ise k�rtasiyeye ka� TL vermelidir?";
                break;
            default:
                question = "Soru �retilemedi";
                break;
        }
        return question;
    }
    void AnswerEditor()
    {
        int probability = Random.Range(1, 5);
        switch (distinct)
        {
            case 1:
                switch (probability)
                {
                    case 1:
                        a_answer.text = AnswerMaker(deck, price) + "";
                        b_answer.text = FalseAnswerMaker(deck, price) + "";
                        c_answer.text = FalseAnswerMaker(deck, price) + "";
                        d_answer.text = FalseAnswerMaker(deck, price) + "";
                        break;
                    case 2:
                        a_answer.text = FalseAnswerMaker(deck, price) + "";
                        b_answer.text = AnswerMaker(deck, price) + "";
                        c_answer.text = FalseAnswerMaker(deck, price) + "";
                        d_answer.text = FalseAnswerMaker(deck, price) + "";
                        break;
                    case 3:
                        a_answer.text = FalseAnswerMaker(deck, price) + "";
                        b_answer.text = FalseAnswerMaker(deck, price) + "";
                        c_answer.text = AnswerMaker(deck, price) + "";
                        d_answer.text = FalseAnswerMaker(deck, price) + "";
                        break;
                    case 4:
                        a_answer.text = FalseAnswerMaker(deck, price) + "";
                        b_answer.text = FalseAnswerMaker(deck, price) + "";
                        c_answer.text = FalseAnswerMaker(deck, price) + "";
                        d_answer.text = AnswerMaker(deck, price) + "";
                        break;
                }
                break;
            case 2:
            switch (probability)
            {
                case 1:
                    a_answer.text = AnswerMaker(sayi, g�n) + "";
                    b_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    c_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    d_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    break;
                case 2:
                    a_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    b_answer.text = AnswerMaker(sayi, g�n) + "";
                    c_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    d_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    break;
                case 3:
                    a_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    b_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    c_answer.text = AnswerMaker(sayi, g�n) + "";
                    d_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    break;
                case 4:
                    a_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    b_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    c_answer.text = FalseAnswerMaker(sayi, g�n) + "";
                    d_answer.text = AnswerMaker(sayi, g�n) + "";
                    break;
            }
            break;
        }  
            
    }
    int AnswerMaker(int sayi, int g�n)
    {
        return sayi * g�n;
    }
    int FalseAnswerMaker(int sayi, int g�n)
    {
        int r = Random.Range((sayi * g�n) - 5, (sayi * g�n) + 5);
        if (r != AnswerMaker(sayi, g�n))
        {
            if (r < 0)
                return Mathf.Abs(r);
            return r;
        }
        return r + 3;
    }
    public void A()
    {
        aAnswer = int.Parse(a_answer.text);
        AnswerController(aAnswer);
    }
    public void B()
    {
        bAnswer = int.Parse(b_answer.text);
        AnswerController(bAnswer);
    }
    public void C()
    {
        cAnswer = int.Parse(c_answer.text);
        AnswerController(cAnswer);
    }
    public void D()
    {
        dAnswer = int.Parse(d_answer.text);
        AnswerController(dAnswer);
    }
    public void AnswerController(int answer)
    {
        if (answer == correctAnswer)
        {
            skor++;
        }
        else
        {
            skor--;
            if (skor < -5)
                GameExit();
        }
        scoreEditor();
        soru++;
        maker();
    }
    public void scoreEditor()
    {
        score.text = skor + "";
    }
    public void puanPage()
    {
        Time.timeScale = 0f;
        firstStage.SetActive(false);
        secondStage.SetActive(true);
        if(dogruCevaplananSoru<0)
            dogruCevaplananSoru = 0;
        else
            dogruCevaplananSoru=skor;
        skorText.text = "Do�ru Cevaplanan Soru Say�s�: " + dogruCevaplananSoru;
        puanText.text = "Puan: " + "(" + skor + " * 4) = " + skor * 4 + " / " + (soru - 1) * 4;
        if ((soru - 1) != 0 && skor >= 0)
            basari = (float)skor / (soru - 1) * 100f;
        else
            basari = 0;
        basariText.text = "Ba�ar� Y�zdesi: %" + basari;
    }
    public void antiPuanPage()
    {
        if((timer==0)||(soru>=25))
        {
            GameExit();
        }
        else
        {
            Time.timeScale = 1f;
            firstStage.SetActive(true);
            secondStage.SetActive(false);
        }

    }
    public void GameExit()
    {
        SceneManager.LoadScene(0);
    }
}

