using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// This component listens for images detected by the <c>XRImageTrackingSubsystem</c>
    /// and overlays some information as well as the source Texture2D on top of the
    /// detected image.
    /// </summary>
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class TrackedImageManager : MonoBehaviour
    {
        [SerializeField]
        string imageName;
        public GameObject infoPrefab;

        ARTrackedImageManager m_TrackedImageManager;

        void Awake()
        {
            m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        }

        void OnEnable()
        {
            m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        void OnDisable()
        {
            m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        void UpdateInfo(ARTrackedImage trackedImage, GameObject infoObject)
        {
            // Update information about the tracked image
            var imageName = trackedImage.referenceImage.name;

            // UI Overlay works fine. Do Not Disturb
            var something  = infoObject.GetComponentInChildren<UIOverlay>();

            // Devices works fine. Do Not Disturb
            var somethingDevices = infoObject.GetComponentInChildren<Devices>();

            // Telemetry works fine. Do Not Disturb
            var somethingTelemetry = infoObject.GetComponentInChildren<Telemetry>();

            // Table History On Test. Dont know if this works.
            var somethingTableHistory = infoObject.GetComponentInChildren<TableHistory>();

            // If anything goes wrong, its the new one.
            somethingDevices.GetInformationByScanning(imageName);
            Debug.Log("apebenda ni" + imageName);
            somethingTelemetry.GetTelemetryByScanning(somethingDevices.deviceData["device_entity_type"], somethingDevices.deviceData["device_id"]);
            Debug.Log("apebenda ni" + somethingTelemetry.telemetryData["telemetry_udi"]);

            something.udi.text = somethingTelemetry.telemetryData["telemetry_udi"];
            something.pid.text = somethingTelemetry.telemetryData["telemetry_productId"];
            something.toolwear.text = somethingTelemetry.telemetryData["telemetry_toolWear"];
            something.power.text = somethingTelemetry.telemetryData["telemetry_power"];
            something.overstrain.text = somethingTelemetry.telemetryData["telemetry_overstrain"];
            something.tempdiff.text = somethingTelemetry.telemetryData["telemetry_tempDiff"];
            something.failuretype.text = somethingTelemetry.telemetryData["telemetry_failureType"];
            something.deviceName.text = imageName;

            something.RadialBar(float.Parse(somethingTelemetry.telemetryData["telemetry_toolWear"]));
            something.SemiRadialBar(float.Parse(somethingTelemetry.telemetryData["telemetry_overstrain"]));
            something.TemperatureBox(float.Parse(somethingTelemetry.telemetryData["telemetry_tempDiff"]));
            something.LinearBar(float.Parse(somethingTelemetry.telemetryData["telemetry_power"]));

            something.IfError(somethingTelemetry.telemetryData["telemetry_target"], somethingTelemetry.telemetryData["telemetry_failureType"]);

            // Test out This currently
            if(somethingTelemetry.telemetryData["telemetry_target"] == "1")
            {
                // imageName = Device Name
                somethingTableHistory.GetRowData(imageName,somethingTelemetry.telemetryData["telemetry_udi"], somethingTelemetry.telemetryData["telemetry_productId"], somethingTelemetry.telemetryData["telemetry_failureType"], somethingTelemetry.telemetryData["telemetry_target"]);
            }

            // Enable/disable the info object based on the tracking state
            if (trackedImage.trackingState != TrackingState.None)
            {
                infoObject.SetActive(true);
            }
            else
            {
                infoObject.SetActive(false);
            }
        }

        void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var trackedImage in eventArgs.added)
            {
                // Give the initial image a reasonable default scale
                trackedImage.transform.localScale = new Vector3(0.2f, 1f, 0.2f);

                // Instantiate the info prefab at the position of the tracked image
                var infoObject = Instantiate(infoPrefab, trackedImage.transform.position, Quaternion.identity);

                UpdateInfo(trackedImage, infoObject);
            }

            foreach (var trackedImage in eventArgs.updated)
            {
                UpdateInfo(trackedImage, trackedImage.gameObject);
            }
        }
    }
}