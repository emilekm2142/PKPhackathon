using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class TrainRide
{
    [DataMember]
    public string trainRideId { get; set; }
    
    [DataMember]
    public List<long> pointIds { get; set; }
    
    [DataMember]
    public long lastVisitedPointId { get; set; }
}