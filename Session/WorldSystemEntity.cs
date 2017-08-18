namespace SystemForAll.Session
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    [Table("WorldSystem")]
    public partial class WorldSystemEntity
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Spatial_Reference_Id { get; set; }
        [DataMember]
        public string Well_Known_Text { get; set; }
        [DataMember]
        public double? Coordinate_System { get; set; }
        [DataMember]
        [StringLength(10)]
        public string Datum { get; set; }
        [DataMember]
        [StringLength(10)]
        public string Prime_Meridan { get; set; }
        [DataMember]
        [StringLength(10)]
        public string Projection { get; set; }
        [DataMember]
        [StringLength(10)]
        public string Unit_of_Measure { get; set; }
        [DataMember]
        [StringLength(10)]
        public string Authority_Name { get; set; }
        [DataMember]
        [StringLength(10)]
        public string Unit_Conversion_Factor { get; set; }
    }
}
