using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;

namespace WebApplication1.Services.Interfaces
{
    public interface ILectorService
    {
            Task<ICollection<Lector>?> GetAll();
            Task<Lector?> GetById(int Id);
            Task<bool> CreateLector(LectorAddDto model);
            Task<bool> UpdateLector(int Id, LectorAddDto model);
            Task<bool> DeleteLector(int Id);
            Task<float?> GetMaxGrade(int lectorId);
            Task<float?> GetMinGrade(int lectorId);
            Task<float?> GetAvgGrade(int lectorId);
            Task<Dictionary<string, int>?> GroupAndCountStudentsByNameForLector(int lectorId);
        }
    }


