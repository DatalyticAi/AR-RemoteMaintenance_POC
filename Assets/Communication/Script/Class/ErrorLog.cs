using System;
using System.Collections.Generic;

[Serializable]

public class ErrorLog
{
    public string erl_device_name { get; set; } 
    public string erl_udi { get; set; }
    public string erl_productId { get; set; }
    public string erl_status { get; set; }
    public string erl_type { get; set; }
}