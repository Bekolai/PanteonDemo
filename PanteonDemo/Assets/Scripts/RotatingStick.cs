using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStick : MonoBehaviour
{
     string Phase = "BotR";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchBotR()
    {
        Phase = "BotR";
    }
    public void SwitchBotL()
    {
        Phase = "BotL";
    }
    public void SwitchTopR()
    {
        Phase = "TopR";
    }
    public void SwitchTopL()
    {
        Phase = "TopL";
    }
    public string GetPhase()
    {
        return Phase;
    }
}
