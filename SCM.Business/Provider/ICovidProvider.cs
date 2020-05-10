using SCM.Business.DbModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCM.Business.Provider
{
    public interface ICovidProvider
    {
        Task<IEnumerable<Covid>> GetCovid();
        //Task<IEnumerable<Covid>> GetCovid(string Country);
        IEnumerable<Covid> GetCovidList();
        Task<Covid> GetCovid(uint id);
        Task<int> PutCovid(uint id, Covid covid);
        Task<Covid> PostCovid(Covid covid);
        Task<Covid> DeleteCovid(uint id);
    }
}