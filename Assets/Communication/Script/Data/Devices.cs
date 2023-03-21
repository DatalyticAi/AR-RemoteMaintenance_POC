using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;
using Newtonsoft.Json;
using UnityEngine.UI;

public class Devices : MonoBehaviour
{
    public string savedToken;
    public string savedRefreshToken;
    public string savedScope;

    private string deviceNameVariable;

    // Take Data from Device Response
    private DeviceResponse.Root dr_root;

    public InputField deviceName;
    public Dictionary<string, string> deviceData = new Dictionary<string, string>();

    public static Devices Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        savedToken = PlayerPrefs.GetString("token");
        savedRefreshToken = PlayerPrefs.GetString("refreshToken");
        savedScope = PlayerPrefs.GetString("scope");
    }

    public void FindInformation()
    {
        GetInformation();
    }

    private void GetInformation()
    {
        // Put deviceName.text as a single variable;
        deviceNameVariable = deviceName.text;

        // Information for HTTP Headers
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer " + savedToken;
        RestClient.DefaultRequestHeaders["Accept"] = "application/json";

        RestClient.Get("http://192.168.0.137:8080/api/tenant/devices?deviceName=" + deviceNameVariable).Then(res =>
        {
            dr_root = JsonConvert.DeserializeObject<DeviceResponse.Root>(res.Text);

            //  save this as dictionary
            deviceData["device_name"] = dr_root.name;
            deviceData["device_id"] = dr_root.id.id;
            deviceData["device_entity_type"] = dr_root.id.entityType;
            deviceData["device_type"] = dr_root.type;
            deviceData["device_tenant_id"] = dr_root.tenantId.id;
            deviceData["device_customer_id"] = dr_root.customerId.id;
            deviceData["device_deviceprofile_id"] = dr_root.deviceProfileId.id;

        }).Catch(err =>
        {
            Debug.LogError(err.Message);
        });
    }

    public void GetInformationByScanning(string name)
    {
        Debug.Log("Ha Masin");
        // Put deviceName.text as a single variable;
        deviceNameVariable = name;

        // Information for HTTP Headers
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer " + savedToken;
        RestClient.DefaultRequestHeaders["Accept"] = "application/json";

        RestClient.Get("http://192.168.0.137:8080/api/tenant/devices?deviceName=" + deviceNameVariable).Then(res =>
        {
            dr_root = JsonConvert.DeserializeObject<DeviceResponse.Root>(res.Text);

            //  save this as dictionary
            deviceData["device_name"] = dr_root.name;
            deviceData["device_id"] = dr_root.id.id;
            deviceData["device_entity_type"] = dr_root.id.entityType;
            deviceData["device_type"] = dr_root.type;
            deviceData["device_tenant_id"] = dr_root.tenantId.id;
            deviceData["device_customer_id"] = dr_root.customerId.id;
            deviceData["device_deviceprofile_id"] = dr_root.deviceProfileId.id;

        }).Catch(err =>
        {
            Debug.LogError(err.Message);
        });
    }

    public Dictionary<string, string> GetDeviceData()
    {
        return deviceData;
    }

    public void ClearDeviceData()
    {
        deviceData.Clear();
    }
}