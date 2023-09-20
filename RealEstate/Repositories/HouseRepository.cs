using Microsoft.EntityFrameworkCore;
using RealEstate.Database;
using RealEstate.Entites;
using RealEstate.Respositories;

namespace RealEstate.Repositories
{
    public class HouseRepository : IHouseRespository
    {
        private readonly REDbContext _context;
        public HouseRepository(REDbContext context)
        {
            _context = context;
        }

        public async Task<House> AddAsync(House house)
        {
            var entity = await _context.AddAsync(house);
            return entity.Entity;
        }

        public Task DeleteAsync(House house)
        {
            _context.Remove(house); // o remove não faz o await
            return Task.CompletedTask; // certificar que a Task está completa uma vez que a função não retorna nada
        }

        public async Task<House?> FindByIdAsync(int id)
        {
            return await _context.Houses.FindAsync(id);
        }
 

        public async Task<IEnumerable<House>> FindAllAsync()
        {
            return await _context.Houses.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
