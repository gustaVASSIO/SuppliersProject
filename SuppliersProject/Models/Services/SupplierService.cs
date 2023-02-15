using Microsoft.EntityFrameworkCore;
using SuppliersProject.Data;
using System.Runtime.InteropServices;

namespace SuppliersProject.Models.Services
{
    public class SupplierService
    {
        private Context _context;
        public SupplierService(Context context) {
            _context = context;
        }
        public  async Task<List<Supplier>> ListAllAsync() {
            return await _context.Supplier.ToListAsync();
        }
        public async Task CreateAsync(Supplier supplier) {
            _context.Add(supplier);
            await _context.SaveChangesAsync();          
        }

        public async Task<Supplier> FindById(int id) {
            return await _context.Supplier.FirstOrDefaultAsync(s=>s.Id == id);
        }
        public async Task DeleteAsync(Supplier supplier) {
            _context.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Supplier supplier) {
            _context.Update(supplier);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> VerifySupplierExist(int id)
        {
            Supplier supplier = await this.FindById(id);
            if (supplier == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
