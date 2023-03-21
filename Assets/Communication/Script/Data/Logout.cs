using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Proyecto26;
using Newtonsoft.Json;
public class Logout : MonoBehaviour
{
    private string savedToken;
    private string savedRefreshToken;
    private string savedScope;
    private string savedDeviceName;

    public void Start()
    {
        savedToken = PlayerPrefs.GetString("token");
        savedRefreshToken = PlayerPrefs.GetString("refreshToken");
        savedScope = PlayerPrefs.GetString("scope");
    }
    public void LogoutSession()
    {
        ResetUser();
        ResetDevices();
        ResetTelemetry();
        ResetTenant();
        SceneManager.LoadScene("login");
    }

    void ResetUser()
    {
        PlayerPrefs.SetString("username", null);
        PlayerPrefs.SetString("password", null);

        PlayerPrefs.SetString("token", null);
        PlayerPrefs.SetString("refreshToken", null);
        PlayerPrefs.SetString("scope", null);
        PlayerPrefs.Save();
    }

    void ResetDevices()
    {
        PlayerPrefs.SetString("device_name", null);
        PlayerPrefs.SetString("device_id", null);
        PlayerPrefs.SetString("device_entity_type", null);
        PlayerPrefs.SetString("device_type", null);
        PlayerPrefs.SetString("device_tenant_id", null);
        PlayerPrefs.SetString("device_customer_id", null);
        PlayerPrefs.SetString("device_deviceprofile_id", null);
        PlayerPrefs.Save();
    }

    void ResetTenant()
    {
        PlayerPrefs.SetString("tenant_name", null);
        PlayerPrefs.SetString("tenant_id", null);
        PlayerPrefs.SetString("tenant_profile_id", null);
        PlayerPrefs.Save();
    }

    void ResetTelemetry()
    {
        PlayerPrefs.SetString("telemetry_udi", null);
        PlayerPrefs.SetString("telemetry_productId", null);
        PlayerPrefs.SetString("telemetry_tempDiff", null);
        PlayerPrefs.SetString("telemetry_power", null);
        PlayerPrefs.SetString("telemetry_toolWear", null);
        PlayerPrefs.SetString("telemetry_overstrain", null);
        PlayerPrefs.SetString("telemetry_failureType", null);
        PlayerPrefs.SetString("telemetry_target", null);
        PlayerPrefs.Save();
    }


}


