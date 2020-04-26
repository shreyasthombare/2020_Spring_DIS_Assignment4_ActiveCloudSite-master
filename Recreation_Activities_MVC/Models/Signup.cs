using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace IEXTrading.Models
{
    public class Signup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        
        public string first_name { get; set; }
        [Column(TypeName = "nvarchar(200)")]

        public string last_name { get; set; }
        [Column(TypeName = "int")]
        public int age { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Email { get; set; }
        public string activity { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string recreation_center { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string days_of_week { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string times { get; set; }

    }

    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
           [DataMember(Name = "label")]
           public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
}
