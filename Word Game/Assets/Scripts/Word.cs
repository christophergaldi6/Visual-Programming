using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour {

    public string word;//Word to be guessed by the user
    public string category;//Category hint for the user
    public string wordHint;//A hint for the user that is to be shown when they ask for it

    public string GetWordHint() {

        return wordHint;

    }


}
