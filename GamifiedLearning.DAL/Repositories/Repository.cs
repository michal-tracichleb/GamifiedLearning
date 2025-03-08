using GamifiedLearning.DAL.Interfaces;
using GamifiedLearning.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifiedLearning.DAL.Repositories
{
    internal class Repository<Model> : IRepository<Model> where Model : class, IModelBase
    {
        protected readonly GamifiedLearningDBContext _context;

        public Repository(GamifiedLearningDBContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Model>> GetAllAsync()
        {
            return await _context.Set<Model>().ToListAsync();
        }

        public ICollection<Model> GetAll()
        {
            return _context.Set<Model>().ToList();
        }

        public async Task<Model?> GetAsync(int id)
        {
            return await _context.Set<Model>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Model? Get(int id)
        {
            return _context.Set<Model>().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Model> AddAsync(Model model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Model Add(Model model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }

        public async Task<ICollection<Model>> AddRangeAsync(ICollection<Model> model)
        {
            await _context.AddRangeAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public ICollection<Model> AddRange(ICollection<Model> model)
        {
            _context.AddRange(model);
            _context.SaveChanges();
            return model;
        }

        public async Task UpdateAsync(Model model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }

        public void Update(Model model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }

        public async Task UpdateRangeAsync(ICollection<Model> model)
        {
            _context.UpdateRange(model);
            await _context.SaveChangesAsync();
        }

        public void UpdateRange(ICollection<Model> model)
        {
            _context.UpdateRange(model);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Model model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }

        public void Delete(Model model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Set<Model>().Any(x => x.Id == id);
        }
    }
}