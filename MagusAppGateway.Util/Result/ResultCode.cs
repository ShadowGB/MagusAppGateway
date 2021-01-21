using System.ComponentModel;

namespace MagusAppGateway.Util.Result
{
    public enum ResultCode
    {
        [Description("失败")]
        Fail = 0,

        [Description("成功")]
        Success = 1
    }
}
