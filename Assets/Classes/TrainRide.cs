using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class TrainRide
{
    [DataMember]
    public string trainRideId { get; set; }
    
    [DataMember]
    public List<long> stations { get; set; }
    
    [DataMember]
    public double lng { get; set; }
    
    [DataMember]
    public double lat { get; set; }
}