using System;

namespace Zena.ZKTeco.Models
{
    public class AttTransactionExModel
    {
        public int MachineNumber { get; set; }
        /// <summary>
        /// Primary Key
        /// </summary>
        public int UserIdNum { get; set; }
        public int VerifyMethod { get; set; }
        public DateTime? LogDateTime { get; set; }
        public InOutMode InOutMode { get; set; }
        public int WorkCode { get; set; }

        // Additional Properties
        public string DeviceName { get; set; }
    }
}
