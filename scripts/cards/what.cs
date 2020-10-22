using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class what : MonoBehaviour
{
    public GameObject Panel;
    public Text title;
    public Text description;
    public List <generatetext> textDataList;
    public int index=0;
    public float timer;
    public float cooldown;
    public bool notchoose;
    generatetext GetTextData(){
        return textDataList[index];
    }
    // Start is called before the first frame update
    void Start()
    { timer=cooldown;
      notchoose=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0){
            Panel.gameObject.SetActive(false);
            notchoose=true;
            timer-=Time.deltaTime;
        }
        
        if (timer<0){
            notchoose=false;
            
        } 
        if (!notchoose){
            if (textDataList.Count==0){
                Panel.gameObject.SetActive(true);

                timer=0;
                description.text = "на данный момент предложений о запретах нет";
                title.text = "ПОДОЖДИТЕ";
            }
            else {            
                Panel.gameObject.SetActive(true);
                showText();
                timer=0;
                }

        }

    }
    public void showText(){
            createtext();
            notchoose=true;

    }
    public void createtext(){
        index=Random.Range(0, textDataList.Count-1);
        description.text = GetTextData().descriptiontext;
        title.text = GetTextData().titletext;

    }
    public void forit(){
        textDataList.RemoveAt(index);
        timer=cooldown;

    }
        public void wait(){
        index=Random.Range(0, textDataList.Count-1);
        timer=cooldown;

    }
}
