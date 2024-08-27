using BanSach.DataAccess.Data;
using BanSach.DataAccess.Repository.IRepository;
using BanSach.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSach.DataAccess.Repository
{
    public class CompanypeRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       

        public void Update(Company company)
        {
            _db.Companys.Update(company);
        }
    }
}
