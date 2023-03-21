using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TableHistory : MonoBehaviour
{
    [SerializeField]
    public Text UDI_Text;
    public Text ProductID_Text;
    public Text Target_Text;
    public Text FailureType_Text;

    public Text f_count_power;
    public Text f_count_overstrain;
    public Text f_count_twear;
    public Text f_count_hdiss;

    public GameObject newRow;
    public VerticalLayoutGroup verticalLayoutGroup;


    public string udi;
    public string productId;
    public string target;
    public string failureType;

    private int f_power;
    private int f_twear;
    private int f_hdiss;
    private int f_overstrain;

    private string previousUdi = "";

    public void GetRowData(string device_name, string udi, string productId, string failureType, string target)
    {
        if (udi != null && productId != null && failureType != null && target != null)
        {

            // The variable are working fine. To make it appear, just unhide the prefab that is in the scene.
            UDI_Text.text = udi;
            ProductID_Text.text = productId;
            FailureType_Text.text = failureType;
            Target_Text.text = target;

            // There are value that are being passed here
            Debug.Log("Monster" + udi + productId + failureType + target);

            // Save the inserted value into a List
            List<ErrorLog> errorLogList = new List<ErrorLog>();
            ErrorLog errorLog = new ErrorLog { erl_device_name = device_name,erl_udi = udi, erl_productId = productId, erl_type = failureType, erl_status = target };

            string json = JsonUtility.ToJson(errorLogList);
            string path = Application.persistentDataPath + "/errorloglist.json";
            File.WriteAllText(path,json);

            if (target == "1" && udi != previousUdi)
            {
                
                Instantiate(newRow, verticalLayoutGroup.transform);

                // Count and update once per inserted data is working fine. Do not disturb
                previousUdi = udi;

                switch (failureType)
                {
                    case "Power Failure":
                        f_power++;
                        f_count_power.text = f_power.ToString();
                        break;
                    case "Tool Wear Failure":
                        f_twear++;
                        f_count_twear.text = f_twear.ToString();
                        break;
                    case "Heat Dissipation Failure":
                        f_hdiss++;
                        f_count_hdiss.text = f_hdiss.ToString();
                        break;
                    case "Overstrain Failure":
                        f_overstrain++;
                        f_count_overstrain.text = f_overstrain.ToString();
                        break;
                }

                // Save data 
            }
        }

    }

}
