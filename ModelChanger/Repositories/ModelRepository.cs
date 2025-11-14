using Microsoft.EntityFrameworkCore;
using ModelChanger.Data;
using ModelChanger.Entities;

namespace ModelChanger.Repositories;

public class ModelRepository:IModelRepository
{
    private readonly AppDbContext _context;

    public ModelRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Model>> GetAllAsync()
    {
        return await _context.Models.AsNoTracking().ToListAsync();
    }

    public async Task<Model?> GetByIdAsync(int id)
    {
        return await _context.Models.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Model> AddAsync(Model model)
    {
        _context.Models.Add(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<Model> UpdateAsync(Model model)
    {
        _context.Models.Update(model);
        await _context.SaveChangesAsync();
        return model;    
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleted = await _context.Models.Where(m => m.Id == id)
            .ExecuteDeleteAsync();

        return deleted > 0;
    }
}