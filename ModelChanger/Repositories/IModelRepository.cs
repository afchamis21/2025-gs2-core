using ModelChanger.Entities;

namespace ModelChanger.Repositories;

public interface IModelRepository
{
    Task<IEnumerable<Model>> GetAllAsync();
    Task<Model?> GetByIdAsync(int id);
    Task<Model> AddAsync(Model model);
    Task<Model> UpdateAsync(Model model);
    Task<bool> DeleteAsync(int id);
}