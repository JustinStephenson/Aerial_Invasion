using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicy : MonoBehaviour
{
    // Go to Privacy Policy
    public void PrivacyPolicyURL()
    {
        MenuSounds.sound.menuSound = true;
        string ppURL = "https://docs.google.com/document/d/1380KEo7sLT0gV2Fpts2VOSRI6pXQaOqqYklvEa-AWY0/edit?usp=sharing";
        Application.OpenURL(ppURL);
    }
}
