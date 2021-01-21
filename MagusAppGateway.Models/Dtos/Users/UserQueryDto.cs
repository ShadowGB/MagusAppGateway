using System.ComponentModel;

namespace MagusAppGateway.Models.Dtos
{
    public class UserQueryDto:QueryModelBase
    {
        [DisplayName("姓名")]
        public string Username { get; set; }

        [DisplayName("是否启用")]
        public bool? Enabled { get; set; }
    }
}
