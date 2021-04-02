using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class reactioncontroller : MonoBehaviour
{   
    public GameObject source;
    public UnityEngine.GameObject [] arrowslist;
    public int react;
        public int index=0;
    public GameObject PanelReaction;

    public Text ReactionText;
    public GameObject nextreaction;
    public GameObject closereaction;
            public List <reactiontext> reactiontextList;
        reactiontext GetReactData(){
        return reactiontextList[index];
    }

    // Update is called once per frame
    void Update()
    {
                if(PanelReaction.activeSelf==true){
            reactshowtextofpaper();
            reactstringarray();
        }

    }

            public void reactshowtextofpaper(){arrowslist = GameObject.FindGameObjectsWithTag("arrow");
                                        for (int i = 0; i < arrowslist.Length; i++)
            {
                arrowslist[i].SetActive(false);
            }

                ReactionText.text = GetReactData().reaction[react];

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
