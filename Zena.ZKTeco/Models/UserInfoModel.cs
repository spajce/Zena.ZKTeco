using System.Collections.Generic;

namespace Zena.ZKTeco.Models
{
    public class UserInfoModel
    {
        public int MachineNumber { get; set; }
        /// <summary>
        /// Primary Key and equavalent to dwEnrollNumber parameter of SDK
        /// </summary>
        public string UserIdNum { get; set; }
        public string Name { get; set; }
        public int Privelege { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }

        public List<UserTmpExModel> FingerTemplates { get; set; }
    }
}
