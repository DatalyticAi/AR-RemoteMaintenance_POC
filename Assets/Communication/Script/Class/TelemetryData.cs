using System;
using System.Collections.Generic;

[Serializable]
public class TelemetryData
{
    public class AirTemp
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class FailureType
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class Overstrain
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class Power
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class ProcessTemp
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class ProductID
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class ProductType
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class Root
    {
        public List<UDI> UDI { get; set; }
        public List<ProductID> ProductID { get; set; }
        public List<ProductType> ProductType { get; set; }
        public List<AirTemp> AirTemp { get; set; }
        public List<ProcessTemp> ProcessTemp { get; set; }
        public List<TempDiff> TempDiff { get; set; }
        public List<RPM> RPM { get; set; }
        public List<RP> RPS { get; set; }
        public List<Torque> Torque { get; set; }
        public List<Power> Power { get; set; }
        public List<ToolWear> ToolWear { get; set; }
        public List<Overstrain> Overstrain { get; set; }
        public List<Target> Target { get; set; }
        public List<FailureType> FailureType { get; set; }
    }

    public class RP
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class RPM
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class Target
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class TempDiff
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class ToolWear
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class Torque
    {
        public long ts { get; set; }
        public string value { get; set; }
    }

    public class UDI
    {
        public long ts { get; set; }
        public string value { get; set; }
    }


}
