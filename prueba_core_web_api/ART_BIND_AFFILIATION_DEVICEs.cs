
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_core_web_api
{
    public class ART_BIND_AFFILIATION_DEVICEs
    {
        [ForeignKey("IAF_ID")]
        public decimal IAFF_ID { get; set; }
        public decimal IDEV_ID { get; set; }
        public DateTime DBNB_START { get; set; }
        public DateTime? DBNB_END { get; set; }
    }
}
