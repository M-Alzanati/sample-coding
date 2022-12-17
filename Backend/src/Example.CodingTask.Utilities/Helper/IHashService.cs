using System.Threading.Tasks;

namespace Example.CodingTask.Utilities.Helper
{
    public interface IHashService
    {
        Task<string> HashText(string plainText);
    }
}
