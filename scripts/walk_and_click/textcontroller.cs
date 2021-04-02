using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class textcontroller : MonoBehaviour
{
    public GameObject source;
    string locationnumber;
    string locname;
    public int index = 1;
    public int memeValue;
    public int memeValuetext;
    public int count;
    public GameObject PanelText;
    public Text DescriptionLocation;
    public List <generatetext> textDataLocationList;
        generatetext GetTextData(){
        return textDataLocationList[index];
    }
    public GameObject next;
    public GameObject close;

        

    void Update() {
        
        if (PanelText.activeSelf==true){
            showtextarray();
            stringarray();
        }

    }
    public void showtextarray(){
        for (int i = 0; i < textDataLocationList.Count; i++)
        {   
            index = i;
            locname=GameObject.FindGameObjectWithTag("bg").name;
            int.TryParse(locname, out memeValue);
            locationnumber=GetTextData().locationnumber;
            int.TryParse(locationnumber, out memeValuetext);
            if (memeValue==memeValuetext)
            { 
                if (source.GetComponent<arrow>().ru == true){  
                DescriptionLocation.text = GetTextData().description[count];
                break;
                }
                if (source.GetComponent<arrow>().eng == true){  
                DescriptionLocation.text = GetTextData().descriptioneng[count];
                break;
                }
            }

        }
    }
    public void stringarray(){

        if (GetTextData().description.Length>1){
            close.SetActive(false);
            next.SetActive(true);
        }
        if(count==GetTextData().description.Length-1){
            close.SetActive(true);
            next.SetActive(false);
        }
        


    }
    public void clickcounting(){
        count++;
    }

    public void hidetext(){
        count=0;
    }
}
