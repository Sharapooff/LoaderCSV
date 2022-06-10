using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LoaderCSV.Models
{
    public class TableParam
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Int16 MS { get; set; }
        public int PKM_Seconds { get; set; }
        public float? thrust_brake { get; set; }
        public decimal? voltage { get; set; }
        public decimal? generator_ov_current { get; set; }
        public decimal? current_compressor_motor { get; set; }
        public int? temperature_B1 { get; set; }   
        public int? temperature_A5 { get; set; }
        public decimal? ETD_current { get; set; }
        public Int16? rail_TNVD { get; set; }
        public int? rotation_frequency { get; set; }

    }
}
