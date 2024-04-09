using System.Numerics;

namespace demoCRUD.Models
{
    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class ConnectionSetting
    {
        public string MasterPGConnection { get; set; }
    }

}
