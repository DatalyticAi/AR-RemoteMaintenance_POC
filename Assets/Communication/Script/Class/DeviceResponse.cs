using System;

[Serializable]
public class DeviceResponse
{
    public class AdditionalInfo
    {
        public bool gateway { get; set; }
        public bool overwriteActivityTime { get; set; }
        public string description { get; set; }
    }

    public class Configuration
    {
        public string type { get; set; }
    }

    public class CustomerId
    {
        public string entityType { get; set; }
        public string id { get; set; }
    }

    public class DeviceData
    {
        public Configuration configuration { get; set; }
        public TransportConfiguration transportConfiguration { get; set; }
    }

    public class DeviceProfileId
    {
        public string entityType { get; set; }
        public string id { get; set; }
    }

    public class Id
    {
        public string entityType { get; set; }
        public string id { get; set; }
    }

    public class Root
    {
        public Id id { get; set; }
        public long createdTime { get; set; }
        public AdditionalInfo additionalInfo { get; set; }
        public TenantId tenantId { get; set; }
        public CustomerId customerId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public DeviceProfileId deviceProfileId { get; set; }
        public DeviceData deviceData { get; set; }
        public object firmwareId { get; set; }
        public object softwareId { get; set; }
        public object externalId { get; set; }
    }

    public class TenantId
    {
        public string entityType { get; set; }
        public string id { get; set; }
    }

    public class TransportConfiguration
    {
        public string type { get; set; }
    }


}


