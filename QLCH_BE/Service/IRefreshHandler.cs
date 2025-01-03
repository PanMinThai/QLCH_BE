namespace QLCH_BE.Service
{
    public interface IRefreshHandler
    {
        Task<string> GenerateToken(string username);
    }
}
