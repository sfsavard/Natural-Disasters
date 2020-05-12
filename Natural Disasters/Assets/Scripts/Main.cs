using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static public Main S;
    [Header("Set in Inspector")]
    public int stress = 1;
    public GameObject stressmeter1;
    public GameObject stressmeter2;
    public GameObject stressmeter3;
    public GameObject diedText;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        // Find a reference to the Stress Meter GameObject
        // GameObject stressMeter = GameObject.Find("ScoreCounter");
        stressmeter1 = GameObject.Find("Stress Meter Level 1 Variant");
        stressmeter2 = GameObject.Find("Stress Meter Level 2 Variant");
        stressmeter3 = GameObject.Find("Stress Meter Level 3 Variant");
        diedText = GameObject.Find("Text (TMP)");
        winText = GameObject.Find("Text (TMP) (1)");
        stressmeter2.gameObject.SetActive(false);
        stressmeter3.gameObject.SetActive(false);
        diedText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stress == 2)
        {
            stressmeter1.SetActive(false);
            stressmeter2.SetActive(true);
            stressmeter3.SetActive(false);
        }
        if (stress == 3)
        {
            stressmeter1.SetActive(false);
            stressmeter2.SetActive(false);
            stressmeter3.SetActive(true);
        }
        if (stress == 4)
        {
            diedText.SetActive(true);
            
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Chandelier" && stress <= 3)
        {
            stress = stress + 1;
            print("you hit the chandelier");
        }

        if (collidedWith.tag == "Door")
        {
            winText.gameObject.SetActive(true);
        }
    }
}
