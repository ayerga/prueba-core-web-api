using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba_core_web_api
{
    public class ART_AFFILIATIONs
    {
        [Key]
        public decimal IAFF_ID { get; set; }
        public string SAFF_NAME { get; set; }
        public decimal? IAFF_PARENT_AFFILIATION { get; set; }
        public DateTime? DAFF_START { get; set; }
        public DateTime? DAFF_END { get; set; }
        public string SAFF_TYPE { get; set; }
    }
}
