using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIFindMachine : MonoBehaviour
{
    public TMP_Text udi_value;
    public TMP_Text pid_value;
    public TMP_Text tempdiff_value;
    public TMP_Text toolwear_value;
    public TMP_Text overstrain_value;
    public TMP_Text power_value;
    public TMP_Text failureType_value;
    public TMP_Text deviceID_value;

    public InputField searchBar;

    private Devices devices;
    private Telemetry telemetry;

    private string target;
    private string lastSearchedDeviceName = "";

    public void Start()
    {
        devices = FindObjectOfType<Devices>();
        telemetry = FindObjectOfType<Telemetry>();
        StartCoroutine(UICoroutine());
    }

    public void ClickButton()
    {
        lastSearchedDeviceName = searchBar.text;
    }

    private IEnumerator UICoroutine()
    {
        while (true)
        {
            DeclareVariables();
            CheckMachineError();
            yield return new WaitForSeconds(1f);
        }
    }

    private void DeclareVariables()
    {
        if (!devices.deviceData.ContainsKey("device_name"))
        {
            devices.deviceData.Add("device_name", "MyDevice");
        }

        if (!telemetry.telemetryData.ContainsKey("telemetry_udi"))
        {
            telemetry.telemetryData.Add("telemetry_udi", "telemetryUDI");
            return;
        }

        if (!telemetry.telemetryData.ContainsKey("telemetry_productId"))
        {
            telemetry.telemetryData.Add("telemetry_productId", "telemetryPID");
            return;
        }

        if (!telemetry.telemetryData.ContainsKey("telemetry_tempDiff"))
        {
            telemetry.telemetryData.Add("telemetry_tempDiff", "telemetryTempDiff");
            return;
        }

        if (!telemetry.telemetryData.ContainsKey("telemetry_power"))
        {
            telemetry.telemetryData.Add("telemetry_power", "telemetryPower");
            return;
        }

        if (!telemetry.telemetryData.ContainsKey("telemetry_toolWear"))
        {
            telemetry.telemetryData.Add("telemetry_toolWear", "telemetryToolWear");
            return;
        }

        if (!telemetry.telemetryData.ContainsKey("telemetry_overstrain"))
        {
            telemetry.telemetryData.Add("telemetry_overstrain", "telemetryOverstrain");
            return;
        }

        if (!telemetry.telemetryData.ContainsKey("telemetry_failureType"))
        {
            telemetry.telemetryData.Add("telemetry_failureType", "telemetryFailureType");
            return;
        }

        if (lastSearchedDeviceName != devices.deviceData["device_name"])
        {
            // If the last searched device name is not the current device name, then reset the text fields
            ResetTextFields();
            return;
        }

            /* foreach (KeyValuePair<string, string> entry in devices.deviceData)
            {
                Debug.Log("Key: " + entry.Key + ", Value: " + entry.Value);
            }*/

        deviceID_value.text = devices.deviceData["device_id"];
        udi_value.text = telemetry.telemetryData["telemetry_udi"];
        pid_value.text = telemetry.telemetryData["telemetry_productId"];
        tempdiff_value.text = telemetry.telemetryData["telemetry_tempDiff"];
        power_value.text = telemetry.telemetryData["telemetry_power"];
        toolwear_value.text = telemetry.telemetryData["telemetry_toolWear"];
        overstrain_value.text = telemetry.telemetryData["telemetry_overstrain"];
        failureType_value.text = telemetry.telemetryData["telemetry_failureType"];
    }

    private void ResetTextFields()
    {
        udi_value.text = "N/A";
        pid_value.text = "N/A";
        tempdiff_value.text = "N/A";
        power_value.text = "N/A";
        toolwear_value.text = "N/A";
        overstrain_value.text = "N/A";
        failureType_value.text = "N/A";
        deviceID_value.text = "N/A";
    }

    private void CheckMachineError()
    {
        if (target == "1")
        {
            Debug.Log("There is a machine error.");
        }
    }
}