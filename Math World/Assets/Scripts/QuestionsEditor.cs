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
    int sayi, gün; 
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
            countdown = 1f; // Tekrar baþlatmak için
        }

        if (timer <= 0f)
        {
            puanPage();
        }
        time.text = "Süre: " + (int)timer;
        if(soru>25)
            puanPage();
    }
    void maker()
    {
        {
            sayi = Random.Range(2, 5);
            gün = Random.Range(2, 15);
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
                question = "Bir inek günde " + sayi + " kova süt veriyorsa " + gün + " gün'de kaç kova süt verir?";
                correctAnswer = AnswerMaker(sayi, gün);
                break;
            case 2:
                distinct = 2;
                question = "Bir kumbaraya günde " + sayi + " TL atýlýyorsa " + gün + " gün'de kaç TL birikir?";
                correctAnswer = AnswerMaker(sayi, gün);
                break;
            case 3:
                distinct = 1;
                switch (words)
                {
                    case 1:
                        w = "düzine";
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
                        e = "kalemtraþ";
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
                        n = "Ayþe";
                        break;
                    case 4:
                        n = "Jülide";
                        break;
                }
                question = n + " kýrtasiyeden bir " + w + " " + e + " alýyorsa ve tanesi " + price + " TL ise kýrtasiyeye kaç TL vermelidir?";
                break;
            default:
                question = "Soru üretilemedi";
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
                    a_answer.text = AnswerMaker(sayi, gün) + "";
                    b_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    c_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    d_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    break;
                case 2:
                    a_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    b_answer.text = AnswerMaker(sayi, gün) + "";
                    c_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    d_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    break;
                case 3:
                    a_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    b_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    c_answer.text = AnswerMaker(sayi, gün) + "";
                    d_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    break;
                case 4:
                    a_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    b_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    c_answer.text = FalseAnswerMaker(sayi, gün) + "";
                    d_answer.text = AnswerMaker(sayi, gün) + "";
                    break;
            }
            break;
        }  
            
    }
    int AnswerMaker(int sayi, int gün)
    {
        return sayi * gün;
    }
    int FalseAnswerMaker(int sayi, int gün)
    {
        int r = Random.Range((sayi * gün) - 5, (sayi * gün) + 5);
        if (r != AnswerMaker(sayi, gün))
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
        skorText.text = "Doðru Cevaplanan Soru Sayýsý: " + dogruCevaplananSoru;
        puanText.text = "Puan: " + "(" + skor + " * 4) = " + skor * 4 + " / " + (soru - 1) * 4;
        if ((soru - 1) != 0 && skor >= 0)
            basari = (float)skor / (soru - 1) * 100f;
        else
            basari = 0;
        basariText.text = "Baþarý Yüzdesi: %" + basari;
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

