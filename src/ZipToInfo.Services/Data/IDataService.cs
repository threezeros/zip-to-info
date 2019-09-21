using ZipToInfo.Models;

namespace ZipToInfo.Data
{
    public interface IDataService
    {
         ZipInfo GetInfoForZip(string zipCode);
    }
}