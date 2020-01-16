using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public static int charSelect = 0;
    public List<GameObject> characters;
    int previousSelecterChar;
    private void Start()
    {
        SelectCharacter();
    }


    private void Update()
    {
        previousSelecterChar = charSelect;
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (charSelect >= characters.Count- 1)
                charSelect = 0;
            else
                charSelect++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (charSelect <= 0)
                charSelect = characters.Count - 1 ;
            else
                charSelect--;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            charSelect = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            charSelect = 1;
        }

        if (previousSelecterChar != charSelect)
        {
            SelectCharacter();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ButtonL")
        {
            Debug.Log("Hjit");
            if (charSelect <= 0)
                charSelect = characters.Count - 1;
            else
                charSelect--;
        }

        if (other.gameObject.tag == "ButtonR")
        {
            if (charSelect >= characters.Count - 1)
                charSelect = 0;
            else
                charSelect++;
        }

        if (previousSelecterChar != charSelect)
        {
            SelectCharacter();
        }
    }
    void SelectCharacter()
    {
        int i = 0;
        foreach (Transform character in transform)
        {
            if(i == charSelect)
            {
                characters[i].gameObject.SetActive(true);
            }
            else
            {
                characters[i].gameObject.SetActive(false);
            }
            i++;
        }
    }
}
