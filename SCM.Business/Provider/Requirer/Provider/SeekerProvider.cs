using Microsoft.EntityFrameworkCore;
using SCM.Business.DbModel;
using SCM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Business.Provider
{
    public class SeekerProvider : ISeekerProvider
    {
        private readonly MySqlContext _context;

        public SeekerProvider()
        {
            _context = new MySqlContext();
        }
        public SeekerStatus GetOverallStatus()
        {
            SeekerStatus status = new SeekerStatus();
            try
            {
                var delivered = _context.Requirements.Select(x => x.StatusOfRequest.Value == 100101).Count();
                var totalreq = _context.Requirements.Select(x => x).Count();
                var cancelled = _context.Requirements.Select(x => x.StatusOfRequest.Value == 100102).Count();
                var due = _context.Requirements.Select(x => x.StatusOfRequest.Value == 100103).Count();
                status.TotalDelivered = delivered / totalreq * 100;
                status.TotalCancelled = cancelled / totalreq * 100;
                status.TotalDue = due / totalreq * 100;
                status.TotalRequests = totalreq;
                
                return status;
            }
            catch (Exception)
            {
                return status;
            }
        }

        public async Task<IEnumerable<SeekerLocation>> GetSeekerLocations()
        {
            List<SeekerLocation> locs = await _context.Requirements.Select(x => new SeekerLocation { Latitude = x.Lat, Longitude = x.Long, MobileNo = x.ContactNo, Name = x.RequirerName }).ToListAsync();
            return locs;
        }
    }
}
