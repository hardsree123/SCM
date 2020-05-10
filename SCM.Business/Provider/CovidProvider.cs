using Microsoft.EntityFrameworkCore;
using SCM.Business.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Business.Provider
{
    public class CovidProvider : ICovidProvider
    {
        private readonly MySqlContext _context;
        
        private static readonly string[] Countries = new[]
        {
            "India", "Brazil", "Euthopia", "Canada", "USA", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public CovidProvider()
        {
            _context = new MySqlContext();
        }

        public async Task<IEnumerable<Covid>> GetCovid()
        {
            return await _context.Covid.ToListAsync();
        }

        //public async Task<IEnumerable<Covid>> GetCovid(string country)
        //{
        //    return await _context.Covid.Select(x => x.Country.ToLower().Equals(country.ToLower())).ToListAsync();
        //}

        public IEnumerable<Covid> GetCovidList()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Covid
            {
                Date = DateTime.Now.AddDays(index),
                Lat = rng.Next(-20, 55),
                Long = rng.Next(-20, 55),
                Country = Countries[rng.Next(Countries.Length)],
            })
            .ToArray();
        }

        public async Task<Covid> GetCovid(uint id)
        {
            var covid = await _context.Covid.FindAsync(id);

            return covid;
        }

        public async Task<int> PutCovid(uint id, Covid covid)
        {
            if (id != covid.ForecastId)
            {
                return -2;
            }

            _context.Entry(covid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CovidExists(id))
                {
                    return -1;
                }
                else
                {
                    throw;
                }
            }

            return 0;
        }

        // POST: api/Covids
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<Covid> PostCovid(Covid covid)
        {
            _context.Covid.Add(covid);
            await _context.SaveChangesAsync();

            return covid;
        }

        // DELETE: api/Covids/5
        public async Task<Covid> DeleteCovid(uint id)
        {
            var covid = await _context.Covid.FindAsync(id);
            if (covid == null)
            {
                return covid;
            }

            _context.Covid.Remove(covid);
            await _context.SaveChangesAsync();

            return covid;
        }

        private bool CovidExists(uint id)
        {
            return _context.Covid.Any(e => e.ForecastId == id);
        }
    }
}
