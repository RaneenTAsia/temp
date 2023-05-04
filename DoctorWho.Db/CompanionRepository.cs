using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class CompanionRepository
    {
        private DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public Companion CreateCompanion(Companion companion)
        {
            if ((_context.Companions?.FindAsync(companion)) == null)
            {
                _context.Companions?.Add(companion);
                _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Companion with this Id already exists");
            }
            return companion;
        }
        public Companion UpdateCompanion(Companion companion)
        {
            if ((_context.Companions?.FindAsync(companion)) == null)
            {
                throw new Exception("No Companion with this Id exists");
            }
            _context.Companions.Update(companion);
            _context.SaveChangesAsync();

            return companion;
        }

        public void DeleteCompanion(Companion companion)
        {
            if ((_context.Companions?.FindAsync(companion)) == null)
            {
                throw new Exception("No Episode with this Id exists");
            }
            _context.Companions.Remove(companion);
            _context.SaveChangesAsync();
        }


        public Companion GetCompanionWithId(int companionId)
        {
            var companion = _context.Companions.Find(companionId);
            if (companion == null)
            {
                throw new Exception("Companion with this Id does not exist");
            }
            return companion;
        }
    }
}
