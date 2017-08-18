namespace SystemForAll.Session
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class LocationEntity
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Key]
        public int Id { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }
        [DataMember]
        public Guid? Session { get; set; }
        [DataMember]
        [Column("Location")]
        public DbGeometry Location1 { get; set; }
        [DataMember]
        public DbGeometry Globals { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Type { get; set; }
        [DataMember]
        public double? Latitude { get; set; }
        [DataMember]
        public double? Longitude { get; set; }
        [DataMember]
        public DbGeography Geo { get; set; }
    }
}
