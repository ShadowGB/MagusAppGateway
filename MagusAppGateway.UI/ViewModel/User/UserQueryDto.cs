namespace MagusAppGateway.UI.ViewModel
{
    public class UserQueryDto : QueryModelBase
    {
        public string Username { get; set; }

        public bool? Enabled { get; set; }
    }
}
