/*Name: Kiara Cardona and Chris Galdi
Student ID#: 2293780 and 229616
Chapman email: cardona @chapman.edu and galdi@chapman.edu
Course Number and Section: 236-02
Beach Send
*/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveball : MonoBehaviour
{


    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;

    public string controlLocked = "n";
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 4);

        if (Input.GetKeyDown(moveL) && (laneNum > 1) && (controlLocked == "n"))
        {
            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";


        }
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 4);

        if (Input.GetKeyDown(moveR) && (laneNum < 3) && (controlLocked == "n"))
        {
            horizVel = 2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "lethal")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Coin")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Currency")
        {
            Destroy(other.gameObject);
            gamemaster.coinTotal += 1;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "exit")
        {
            SceneManager.LoadScene("LevelComplete");
        }
        if (other.gameObject.name == "exit")
        {
            SceneManager.LoadScene("LevelComplete");
        }
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controlLocked = "n";
    }
}