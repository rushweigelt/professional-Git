using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Text;
using System.Xml;

using System.IO;

public class gameController : MonoBehaviour {



    public class questionSet{

        

        public class question{

            public question() { } //Not sure why doing this works but it does, review c# syntax for class constructors

            public question(string _qText, string _corrAns, string _altAns1, string _altAns2, string _altAns3, string _diff){
                qText = _qText;
                corrAns = _corrAns;
                altAns1 = _altAns1;
                altAns2 = _altAns2;
                altAns3 = _altAns3;
                diff = int.Parse(_diff);
            }

            public string qText { get; set; }
            public string corrAns { get; set; }
            public string altAns1 { get; set; }
            public string altAns2 { get; set; }
            public string altAns3 { get; set; }
            public int diff { get; set; }

        }

        public class questionCompare : IComparer<question>
        {
            public int Compare(question a, question b)
            {
                if (a.diff > b.diff) return 1;
                else if (a.diff < b.diff) return -1;
                else return 0;
            }
        }

        public static List<question> _populateQSet(){
            List<question> qSet = new List<question>();
            XmlDocument questionSetXML = new XmlDocument();
            questionSetXML.Load("Assets/testQuestionSet.xml");
            XmlNodeList questionList = questionSetXML.GetElementsByTagName("question");
            foreach (XmlNode question in questionList)
            {
                string qText = "";
                string corrAns = "";
                string altAns1 = "";
                string altAns2 = "";
                string altAns3 = "";
                string diff = "";

                XmlNodeList questionCompList = question.ChildNodes;
                foreach (XmlNode questionComp in questionCompList)
                {
                    if (questionComp.Name == "qText")
                    {
                        qText = questionComp.InnerText;
                    } else if (questionComp.Name == "corrAns")
                    {
                        corrAns = questionComp.InnerText;
                    }else if (questionComp.Name == "altAns1")
                    {
                        altAns1 = questionComp.InnerText;
                    }
                    else if (questionComp.Name == "altAns2")
                    {
                        altAns2 = questionComp.InnerText;
                    }
                    else if (questionComp.Name == "altAns3")
                    {
                        altAns3 = questionComp.InnerText;
                    }
                    else if (questionComp.Name == "diff")
                    {
                        diff = questionComp.InnerText;
                    }
                }
                qSet.Add(new question(qText, corrAns, altAns1, altAns2, altAns3, diff));
            }
            questionCompare qSort = new questionCompare();
            qSet.Sort(qSort);

        return qSet;
        }
    }

    public GameObject canvas;
    public GameObject mapHolder;
    public Text questionBox;
    public Text a0;
    public Text a1;
    public Text a2;
    public Text a3;
    public Button answer0;
    public Button answer1;
    public Button answer2;
    public Button answer3;
    public string rUnit = "";


    public int qCount = 0;

    public string correctAns;

    public System.Random rand = new System.Random();



    public string qProgress(List<questionSet.question> qSetInp){
        string qText ="";
        string corrAns ="";
        string altAns1 ="";
        string altAns2 ="";
        string altAns3 ="";
        

        if (qCount < qSetInp.Count){
            qText = qSetInp[qCount].qText;
            corrAns = qSetInp[qCount].corrAns;
            altAns1 = qSetInp[qCount].altAns1;
            altAns2 = qSetInp[qCount].altAns2;
            altAns3 = qSetInp[qCount].altAns3;
        }
        else{
            qText = "No more questions";
            answer0.gameObject.SetActive(false);
            answer1.gameObject.SetActive(false);
            answer2.gameObject.SetActive(false);
            answer3.gameObject.SetActive(false);

        }

        List<string> answerText = new List<string> { corrAns, altAns1, altAns2, altAns3 };
        List<string> shuffledAnswers = new List<string>();

        for (int i = 0; i < 4; i++){
            int randShuffle = rand.Next(0, answerText.Count);
            shuffledAnswers.Add(answerText[randShuffle]);
            answerText.RemoveAt(randShuffle);
        }
        

        questionBox.text = qText;
        a0.text = shuffledAnswers[0];
        a1.text = shuffledAnswers[1];
        a2.text = shuffledAnswers[2];
        a3.text = shuffledAnswers[3];

        return corrAns;
    }

    public void setRUnit(string n)
    {
        rUnit = n;
    }


    public void AnswerSelect(int x){
        bool qResult;
        
        if(x == 0){
            if(a0.text  == correctAns){
                qResult = true;
            }else{
                qResult = false;
            }
        }else if (x == 1){
            if (a1.text == correctAns){
                qResult = true;
            }else{
                qResult = false;
            }
        }else if (x == 2){
            if (a2.text == correctAns){
                qResult = true;
            }else{
                qResult = false;
            }
        }else{
            if (a3.text == correctAns){
                qResult = true;
                
            }else{
                qResult = false;
            }
        }

        qCount++;
        correctAns = qProgress(questionSet._populateQSet());

        //Return to battle
        mapHolder.SetActive(true);
        Debug.Log(rUnit);
        GameObject rUnitObject = GameObject.Find(rUnit);
        rUnitObject.SendMessage("battleWithResults", qResult);
        canvas.SetActive(false);
    }


    // Use this for initialization
    void Start () {
        correctAns = qProgress(questionSet._populateQSet());
    }

    // Update is called once per frame
    void Update () {
		
	}
}
