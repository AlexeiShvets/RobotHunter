using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interfaceController : MonoBehaviour
{

    public bool EndTurn;
    public bool IsMove;

    [SerializeField]
    private GameObject commandPanel;

    private List<Text> texts;

    // Use this for initialization
    void Start ()
    {
        texts = new List<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ClickEndButton()
    {
        EndTurn = true;
    }

    public void ClickMoveButton()
    {
        IsMove = !IsMove;
        SetCommand("M");
    }

    public void SetCommand(string strCommand)
    {
        if (commandPanel == null || commandPanel.GetComponentsInChildren<Text>().Length>=2)
            return;
        var text = Instantiate(Resources.Load("TextCommand")) as GameObject;
        text.GetComponent<Text>().text = strCommand;
        if (text != null)
            text.transform.SetParent(commandPanel.transform);

        

    }
}

