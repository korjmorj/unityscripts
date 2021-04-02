using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class papercontroller : MonoBehaviour
{
    public GameObject source;
    public UnityEngine.GameObject [] arrowslist;
    public int index=0;
    public bool over = false;
    public int count;
    public GameObject Paper;
    public GameObject PanelReaction;
    public Text textpaper;
    public List <papertext> papertextList;
        papertext GetTextData(){
        return papertextList[index];
    }
    public GameObject nexttext;
    public GameObject closetext;
    public int react;


    public Text ReactionText;
    public GameObject nextreaction;
    public GameObject closereaction;
            public List <reactiontext> reactiontextList;
        reactiontext GetReactData(){
        return reactiontextList[index];
    }

        void Update() {
        if(papertextList.Count == 0){
            over = true;
        }
        
        if (Paper.activeSelf==true){
            showtextofpaper();
            stringarray();
        }
        if (PanelReaction.activeSelf==true){
            reactshowtextofpaper();
            reactstringarray();
        }

        }
        
    public void showtextofpaper(){
                if (source.GetComponent<arrow>().ru == true){  
                textpaper.text = GetTextData().papertextdata[count];
                }
                if (source.GetComponent<arrow>().eng == true){  
                textpaper.text = GetTextData().papertextdataeng[count];
                }



    }
    public void stringarray(){

        if (GetTextData().papertextdata.Length>1){
            closetext.SetActive(false);
            nexttext.SetActive(true);
        }
        if(count==GetTextData().papertextdata.Length-1){
            closetext.SetActive(true);
            nexttext.SetActive(false);
        }
        


    }
    public void clickcounting(){
        count++;
    }

    public void hidetext(){
        count=0;
        Paper.SetActive(false);
        papertextList.RemoveAt(index);
        PanelReaction.SetActive(true);
        if(papertextList.Count==0){
            over=true;
        }
    }



    public void read(){
        arrowslist = GameObject.FindGameObjectsWithTag("arrow");
            for (int i = 0; i < arrowslist.Length; i++)
            {
                arrowslist[i].SetActive(false);
            }
        Paper.SetActive(true);
        Destroy(EventSystem.current.currentSelectedGameObject);

    }

     public void reactshowtextofpaper(){
                if (source.GetComponent<arrow>().ru == true){  
                ReactionText.text = GetReactData().reaction[react];
                }
                if (source.GetComponent<arrow>().eng == true){  
                ReactionText.text = GetReactData().reactioneng[react];
                }


    }
    public void reactstringarray(){

        if (GetReactData().reaction.Length>1){
            closereaction.SetActive(false);
            nextreaction.SetActive(true);
        }
        if(react==GetReactData().reaction.Length-1){
            closereaction.SetActive(true);
            nextreaction.SetActive(false);
        }
        


    }
        public void clickcountingreact(){
        react++;
    }
            public void hidereact(){
        react=0;
        PanelReaction.SetActive(false);
        reactiontextList.RemoveAt(index);
                for (int i = 0; i < arrowslist.Length; i++)
            {
                arrowslist[i].SetActive(true);
            }

    }
}