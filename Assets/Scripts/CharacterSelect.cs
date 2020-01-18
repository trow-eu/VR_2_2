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

        if(charSelect == 0)
        {
            this.GetComponentInParent<Climber>().enabled = false;
            this.GetComponent<WebShooting>().enabled = false;
            this.GetComponent<OVRGrabber>().enabled = true;
            // cut not active;
        }
        if (charSelect == 1)
        {
            this.GetComponentInParent<Climber>().enabled = true;
            this.GetComponent<WebShooting>().enabled = true;
            this.GetComponent<OVRGrabber>().enabled = true;
            // cut not active;
        }

        if(charSelect == 2)
        {
            this.GetComponentInParent<Climber>().enabled = false;
            this.GetComponent<WebShooting>().enabled = false;
            this.GetComponent<OVRGrabber>().enabled = false;
            //Cut active;
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
