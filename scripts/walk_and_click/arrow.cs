using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;


public class arrow : MonoBehaviour
{   public bool ru=false;
public bool eng=false;
    int memeValue;
    public GameObject source;
    public UnityEngine.GameObject [] locationslist;
    public UnityEngine.GameObject [] arrowslist;
    public UnityEngine.GameObject [] looklist;
    public int [] firststeplist;
    public int numberoffirststeps=0;
    public string from;
    public string to;
    public string var;
    public GameObject PanelText;
    public GameObject menu;
    public Text endtext;
    void Start() {
        looklist = GameObject.FindGameObjectsWithTag("look"); 
        array();
    }
    
     void Update() {
    }

    public void array(){
    locationslist = GameObject.FindGameObjectsWithTag("bg");
        
        for (int i = 0; i < locationslist.Length; i++){
            locationslist[i].SetActive(false);
             numberoffirststeps++;
        }
        firststeplist = new int [numberoffirststeps];
            for (int i = 0; i < firststeplist.Length; i++){
                firststeplist[i]=1;
        }
    }

    public void step(){
        var=EventSystem.current.currentSelectedGameObject.name;

        string[] numbers = var.Split(new char[] {'o'});
        from=numbers[0];
        to=numbers[1];

        string sub="t";
        int indexofchar=from.IndexOf(sub);
        from=from.Remove(indexofchar);
        for (int i = 0; i < locationslist.Length; i++)
        {
            if (locationslist[i].name==from){
                locationslist[i].SetActive(false);
                firststeplist[i]=0;
            }
            if (locationslist[i].name==to){
                locationslist[i].SetActive(true);
                 if(firststeplist[i]==1){
                    PanelText.SetActive(true);
                    showtext();
                }
                int.TryParse(to, out memeValue);
                if(memeValue==15){
                    if (source.GetComponent<papercontroller>().over == false){
                        for (int n = 0; n < looklist.Length; n++)
                            {
                                looklist[n].SetActive(false);
                            }
                    }
                    else
                    {
                                              for (int n = 0; n < looklist.Length; n++)
                            {
                                looklist[n].SetActive(true);
                            }  
                    }
                }
                
            }

        }
 
        
    }

    public void showtext(){
        if(PanelText.activeSelf==true){
            arrowslist = GameObject.FindGameObjectsWithTag("arrow");
                    for (int i = 0; i < arrowslist.Length; i++)
            {
                arrowslist[i].SetActive(false);
            }

        }
    }


    public void closetext(){
        PanelText.SetActive(false);
        for (int i = 0; i < arrowslist.Length; i++)
            {
                arrowslist[i].SetActive(true);
            }
    }
    public void rulang (){

        GameObject[] start = GameObject.FindGameObjectsWithTag("start");
        foreach (GameObject btn in start)
        {
            Destroy(btn);
        }
        ru=true;
        menu.SetActive(false);
        for (int i = 0; i < locationslist.Length; i++)
        {if (locationslist[i].name=="12"){
                locationslist[i].SetActive(true);

            }
        }
        PanelText.SetActive(true);
        showtext();
        
    }
    public void englang (){
        GameObject[] start = GameObject.FindGameObjectsWithTag("start");
        foreach (GameObject btn in start)
        {
            Destroy(btn);
        }
        eng=true;
        menu.SetActive(false);
        for (int i = 0; i < locationslist.Length; i++)
        {
            if (locationslist[i].name=="12"){
                locationslist[i].SetActive(true);
 
            }
        }
        PanelText.SetActive(true);
        showtext();
        
    }
    public void end(){
        GameObject.FindGameObjectWithTag("bg").SetActive(false);
        menu.SetActive(true);
        if (ru==true){
            endtext.text="Всё будет хорошо.";
        }
        if (eng==true){
            endtext.text="Everything will be fine.";
        }

    }
    public void look(){
                for (int i = 0; i < locationslist.Length; i++)
        {
            if (locationslist[i].name=="15"){
                locationslist[i].SetActive(false);
                firststeplist[i]=0;
            }
            if (locationslist[i].name=="17"){
                locationslist[i].SetActive(true);
                 if(firststeplist[i]==1){
                    PanelText.SetActive(true);
                    showtext();
                }
            }
        
        }

    }
}
