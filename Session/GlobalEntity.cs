namespace SystemForAll.Session
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class GlobalEntity
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataMember]
        public Guid User { get; set; }

        [DataMember]
        public Guid Session { get; set; }

        [DataMember]
        public Guid Location { get; set; }

        [DataMember]
        public Guid? Unit { get; set; }

        [DataMember]
        public double? Point0 { get; set; }

        [DataMember]
        public double? Point1 { get; set; }

        [DataMember]        
        public double? Point2 { get; set; }

        [DataMember]
        public double? Point3 { get; set; }
        [DataMember]
        public double? Point4 { get; set; }
        [DataMember]
        public double? Point5 { get; set; }
        [DataMember]
        public double? Point6 { get; set; }
        [DataMember]
        public double? Point7 { get; set; }
        [DataMember]
        public double? Point8 { get; set; }
        [DataMember]
        public double? Point9 { get; set; }
        [DataMember]
        public double? Point10 { get; set; }
        [DataMember]
        public double? Point11 { get; set; }
        [DataMember]
        public double? Point12 { get; set; }
        [DataMember]
        public double? Point13 { get; set; }
        [DataMember]
        public double? Point14 { get; set; }
        [DataMember]
        public double? Point15 { get; set; }
        [DataMember]
        public double? Point16 { get; set; }
        [DataMember]
        public double? Point17 { get; set; }
        [DataMember]
        public double? Point18 { get; set; }
        [DataMember]
        public double? Point19 { get; set; }
        [DataMember]
        public double? Point20 { get; set; }
        [DataMember]
        public double? Point21 { get; set; }
        [DataMember]
        public double? Point22 { get; set; }
        [DataMember]
        public double? Point23 { get; set; }
        [DataMember]
        public double? Point24 { get; set; }
        [DataMember]
        public double? Point25 { get; set; }
        [DataMember]
        public double? Point26 { get; set; }
        [DataMember]
        public int? Geometry_Type { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Method { get; set; }
        [DataMember]
        public int? Height { get; set; }
        [DataMember]
        public int? Width { get; set; }
        [DataMember]
        public int? Weight { get; set; }
        [DataMember]
        public int? Dimension { get; set; }
        [DataMember]
        public int? Coordinate_Dimension { get; set; }
        [DataMember]
        public int? Spatial_Dimension { get; set; }
        [DataMember]
        public DbGeometry Envelope { get; set; }
    }
}
