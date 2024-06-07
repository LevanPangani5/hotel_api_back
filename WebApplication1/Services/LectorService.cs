using WebApplication1.Data.Model;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApplication1.Data.DTO;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class LectorService : ILectorService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public LectorService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ICollection<Lector>?> GetAll()
        {
            try
            {
                var lectors = await _db.Lectors.ToListAsync();

                return lectors;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Lector?> GetById(int Id)
        {
            try
            {
                var lector = await _db.Lectors.FirstOrDefaultAsync(lector => lector.Id == Id);
                return lector;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> CreateLector(LectorAddDto model)
        {
            var lector = _mapper.Map<Lector>(model);

            try
            {
                await _db.AddAsync(lector);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> UpdateLector(int Id, LectorAddDto model)
        {
            var lector = await GetById(Id);
            try
            {
                if (lector == null)
                {
                    throw new Exception("Lector with such id does not exist");
                }
                _mapper.Map(model, lector);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public async Task<bool> DeleteLector(int Id)
        {
            try
            {
                var lector = await _db.Lectors.FindAsync(Id);
                if (lector != null)
                {
                    _db.Lectors.Remove(lector);
                    await _db.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<float?> GetMaxGrade(int lectorId)
        {
            try
            {
                var lector = await _db.Lectors.Include(l => l.Students).FirstOrDefaultAsync(l => l.Id == lectorId);

                if (lector == null)
                    return null;

                float? max = lector.Students.Max(s => s.Grade);
                return max;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<float?> GetMinGrade(int lectorId)
        {
            try
            {
                var lector = await _db.Lectors.Include(l => l.Students).FirstOrDefaultAsync(l => l.Id == lectorId);

                if (lector == null)
                    return null;

                float? max = lector.Students.Min(s => s.Grade);
                return max;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<float?> GetAvgGrade(int lectorId)
        {
            try
            {
                var lector = await _db.Lectors.Include(l => l.Students).FirstOrDefaultAsync(l => l.Id == lectorId);

                if (lector == null)
                    return null;

                float? max = lector.Students.Average(s => s.Grade);
                return max;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Dictionary<string, int>?> GroupAndCountStudentsByNameForLector(int lectorId)
        {
            try
            {
                var StudentsGroupedByName = await _db.Lectors
                    .Where(l => l.Id == lectorId)
                    .SelectMany(l => l.Students)
                    .GroupBy(s => s.Name)
                    .Select(g => new { Name = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.Name, x => x.Count);
                return StudentsGroupedByName;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
