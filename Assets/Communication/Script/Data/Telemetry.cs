using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Proyecto26;
using Newtonsoft.Json;
using UnityEditor;

public class Telemetry : MonoBehaviour
{
    private string savedToken;
    private string savedRefreshToken;
    private string savedScope;

    private string saved_device_entity_type;
    private string saved_device_id;

    TelemetryData.Root root;
    private Devices devices;
    public Dictionary<string, string> telemetryData = new Dictionary<string, string>();

    public void Start()
    {
        savedToken = PlayerPrefs.GetString("token");
        savedRefreshToken = PlayerPrefs.GetString("refreshToken");
        savedScope = PlayerPrefs.GetString("scope");

        devices = FindObjectOfType<Devices>();

        StartCoroutine(TelemetryCoroutine());
    }

    private IEnumerator TelemetryCoroutine()
    {
        while (true)
        {
            DeclareVariables();
            GetTelemetry();
            yield return new WaitForSeconds(1f);
        }
    }

    private void DeclareVariables()
    {
        if (!devices.deviceData.ContainsKey("device_entity_type"))
        {
            devices.deviceData.Add("device_entity_type", "MyDeviceEntityType");
            return;
        }

        if (!devices.deviceData.ContainsKey("device_id"))
        {
            devices.deviceData.Add("device_id", "MyDeviceID");
            return;
        }

        saved_device_entity_type = devices.deviceData["device_entity_type"];
        saved_device_id = devices.deviceData["device_id"];

    }


    public void GetTelemetry()
    {
        //Debug.Log("Sini kan?" + saved_device_entity_type + saved_device_id);
        // Information for HTTP Headers
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer " + savedToken;
        RestClient.DefaultRequestHeaders["Accept"] = "application/json";

        RestClient.Get("http://192.168.0.137:8080/api/plugins/telemetry/" + saved_device_entity_type + "/" + saved_device_id + "/values/timeseries").Then(res =>
        {
            root = JsonConvert.DeserializeObject<TelemetryData.Root>(res.Text);
            foreach (var udi in root.UDI)
            {
                foreach (var productID in root.ProductID)
                {
                    foreach (var tempDiff in root.TempDiff)
                    {
                        foreach (var power in root.Power)
                        {
                            foreach (var toolwear in root.ToolWear)
                            {
                                foreach (var overstrain in root.Overstrain)
                                {
                                    foreach (var failureType in root.FailureType)
                                    {
                                        foreach (var target in root.Target)
                                        {
                                            // maybe save this as dictionary
                                            telemetryData["telemetry_udi"] = udi.value;
                                            telemetryData["telemetry_productId"] = productID.value;
                                            telemetryData["telemetry_tempDiff"] = tempDiff.value;
                                            telemetryData["telemetry_power"] = power.value;
                                            telemetryData["telemetry_toolWear"] = toolwear.value;
                                            telemetryData["telemetry_overstrain"] = overstrain.value;
                                            telemetryData["telemetry_failureType"] = failureType.value;
                                            telemetryData["telemetry_target"] = target.value;

                                           // Debug.Log("Nilai UDI Sekarang: "+telemetryData["telemetry_udi"]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }).Catch(err =>
        {
            Debug.LogError(err.Message);
            // Insert Visual Design here    
        });
    }

    public void GetTelemetryByScanning(string deviceEntity, string deviceId)
    {
        //Debug.Log("Sini kan?" + saved_device_entity_type + saved_device_id);
        // Information for HTTP Headers
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer " + savedToken;
        RestClient.DefaultRequestHeaders["Accept"] = "application/json";

        RestClient.Get("http://192.168.0.137:8080/api/plugins/telemetry/" + deviceEntity + "/" + deviceId + "/values/timeseries").Then(res =>
        {
            root = JsonConvert.DeserializeObject<TelemetryData.Root>(res.Text);
            foreach (var udi in root.UDI)
            {
                foreach (var productID in root.ProductID)
                {
                    foreach (var tempDiff in root.TempDiff)
                    {
                        foreach (var power in root.Power)
                        {
                            foreach (var toolwear in root.ToolWear)
                            {
                                foreach (var overstrain in root.Overstrain)
                                {
                                    foreach (var failureType in root.FailureType)
                                    {
                                        foreach (var target in root.Target)
                                        {
                                            // maybe save this as dictionary
                                            telemetryData["telemetry_udi"] = udi.value;
                                            telemetryData["telemetry_productId"] = productID.value;
                                            telemetryData["telemetry_tempDiff"] = tempDiff.value;
                                            telemetryData["telemetry_power"] = power.value;
                                            telemetryData["telemetry_toolWear"] = toolwear.value;
                                            telemetryData["telemetry_overstrain"] = overstrain.value;
                                            telemetryData["telemetry_failureType"] = failureType.value;
                                            telemetryData["telemetry_target"] = target.value;

                                            // Debug.Log("Nilai UDI Sekarang: "+telemetryData["telemetry_udi"]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }).Catch(err =>
        {
            Debug.LogError(err.Message);
            // Insert Visual Design here    
        });
    }
}