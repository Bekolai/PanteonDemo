using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Resolution[] resolutions;
    public TMP_Dropdown resDropdown;
    public bool portraitModeBool=true;
    void Start()
    {
        Screen.SetResolution(1080, 1920, Screen.fullScreenMode = FullScreenMode.Windowed); //native res
       
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();
       
        int currentResIndex=0;
       
        for(int i =0;i<resolutions.Length;i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height+" @ " + resolutions[i].refreshRate+"hz";
            options.Add(option);

            
            if (resolutions[i].width==Screen.width && resolutions[i].height == Screen.height 
                || (resolutions[i].height == Screen.width && resolutions[i].height == Screen.width)) //checking which res we are using 
            {
                currentResIndex = i;
            }
        }
        resDropdown.AddOptions(options); //adding options
        resDropdown.value = currentResIndex; //showing selected value
        resDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void addPortraitRes()
    {
       
    }
    public void setRes(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        if(!portraitModeBool)
        {
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode=FullScreenMode.Windowed); // if not portrait just give resolution directly
        }
        else
        {
            Screen.SetResolution(resolution.height,resolution.width , Screen.fullScreenMode = FullScreenMode.Windowed); //if portrair switch height and width
        }
        
    }
    public void PortraitChange()
    {
        portraitModeBool = !portraitModeBool;
    }
}
