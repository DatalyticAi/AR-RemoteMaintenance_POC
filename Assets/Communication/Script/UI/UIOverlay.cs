using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOverlay : MonoBehaviour
{
    // General Variables
    public string udi_value;
    public string pid_value;
    public string overstrain_value;
    public string power_value;
    public string toolWear_value;
    public string failureType_value;
    public string tempDiff_value;
    public string deviceName_value;
    public string target_value;

    public Text udi;
    public Text pid;
    public Text overstrain;
    public Text power;
    public Text toolwear;
    public Text failuretype;
    public Text tempdiff;
    public Text deviceName;

    // Data Visualization Variables
    public Image CircleLoadingBar;
    public Image SemiCircleLoadingBar;
    public Image SliderBar;
    public Image TemperatureBoxColor;

    public Slider PowerBar;

    // Error Log Variables
    public GameObject ErrorLog;

    // Error Page Variables
    public GameObject ErrorPage;

    public Image errorImage;
    public Image errorImageBgColor;

    public Sprite toolWearErrorImage;
    public Sprite heatDissipationErrorImage;
    public Sprite overstrainErrorImage;
    public Sprite powerErrorImage;

    public Text errorType;
    public Text errorMessage;

    // Maintenance Variables
    public GameObject Maintenance;

    public Image maintenanceImage;
    public Sprite toolWearErrorImageMaintenance;
    public Sprite heatDissipationErrorImageMaintenance;
    public Sprite overstrainErrorImageMaintenance;
    public Sprite powerErrorImageMaintenance;
    public Sprite randomErrorImageMaintenance;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UICoroutine());
    }

    private IEnumerator UICoroutine()
    {
        while (true)
        {
            DeclareVariables();
            yield return new WaitForSeconds(1f);
        }
    }

    void DeclareVariables()
    {
        udi.text = udi_value;
        pid.text = pid_value;
        overstrain.text = overstrain_value;
        power.text = power_value;
        toolwear.text = toolWear_value;
        failuretype.text = failureType_value;
        tempdiff.text = tempDiff_value;
        deviceName.text = deviceName_value;

        RadialBar(float.Parse(toolWear_value));
        SemiRadialBar(float.Parse(overstrain_value));
        TemperatureBox(float.Parse(tempDiff_value));
        LinearBar(float.Parse(power_value));
        IfError(target_value,failureType_value);
    }

    public void RadialBar(float currentValue)
    {
        CircleLoadingBar.fillAmount = currentValue / 240;
        if (currentValue < 149)
        {
            CircleLoadingBar.color = Color.green;
        }
        else if (currentValue > 149 && currentValue < 199)
        {
            CircleLoadingBar.color = Color.yellow;
        }
        else
        {
            CircleLoadingBar.color = Color.red;
        }
    }

    public void SemiRadialBar(float currentValue)
    {
        SemiCircleLoadingBar.fillAmount = currentValue / 15000;
       
        if (currentValue < 6000)
        {
            SemiCircleLoadingBar.color = Color.green;
        }
        else if (currentValue > 6000 && currentValue < 11999)
        {
            SemiCircleLoadingBar.color = Color.yellow;
        }
        else
        {
            SemiCircleLoadingBar.color = Color.red;
        }
    }

    public void TemperatureBox(float currentValue)
    {
        if (currentValue < 8.6)
        {
            TemperatureBoxColor.color = Color.red;
        }

        else
        {
            TemperatureBoxColor.color = Color.green;
        }
    }

    public void LinearBar(float currentValue)
    {
        PowerBar.value = currentValue;

        if (currentValue < 3500 || currentValue > 9000)
        {
            SliderBar.color = Color.red;
        }
        else if (currentValue > 4600 && currentValue < 7900)
        {
            SliderBar.color = Color.yellow;
        }
        else
        {
            SliderBar.color = Color.green;
        }

    }

    public void IfError(string target, string failureType)
    {
        if (target == "1")
        {
            

            if (failureType == "Power Failure")
            {
                errorImage.sprite = powerErrorImage;
                errorImageBgColor.color = Color.yellow;
                errorType.text = " Power Failure";
                errorMessage.text = "Check power connectivity to resume machine production";
                maintenanceImage.sprite = powerErrorImageMaintenance;
            }

            else if (failureType == "Overstrain Failure")
            {
                errorImage.sprite = overstrainErrorImage;
                errorImageBgColor.color = Color.red;
                errorType.text = " Overstrain Failure";
                errorMessage.text = "Check cause of overstrain";
                maintenanceImage.sprite = overstrainErrorImageMaintenance;
            }

            else if (failureType == "Tool Wear Failure")
            {
                errorImage.sprite = toolWearErrorImage;
                errorImageBgColor.color = Color.red;
                errorType.text = " Tool Wear Failure";
                errorMessage.text = "Change broken machine part and continue production";
                maintenanceImage.sprite = toolWearErrorImageMaintenance;
            }
            else if (failureType == "Heat Dissipation Failure")
            {
                errorImage.sprite = heatDissipationErrorImage;
                errorImageBgColor.color = Color.red;
                errorType.text = " Heat Dissipation Failure";
                errorMessage.text = "Check machine temperature";
                maintenanceImage.sprite = heatDissipationErrorImageMaintenance;
            }

            ErrorPage.SetActive(true);
        }
        else
        {
            ErrorPage.SetActive(false);
        }
    }

    

    public void ActivateErrorLog()
    {
        ErrorLog.SetActive(true);
    }

    public void DeactivateErrorLog()
    {
        ErrorLog.SetActive(false);
    }

    public void ActivateMaintenance()
    {
        Maintenance.SetActive(true);
    }

    public void DeactivateMaintenance()
    {
        Maintenance.SetActive(false);
    }
}
