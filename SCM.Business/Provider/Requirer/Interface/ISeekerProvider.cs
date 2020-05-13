using SCM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Business.Provider
{
    public interface ISeekerProvider
    {
        SeekerStatus GetOverallStatus();

        Task<IEnumerable<SeekerLocation>> GetSeekerLocations();
    }
}
