using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class AuthorRepository
    {

        private DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public Author CreateAuthor(Author author)
        {
            if ((_context.Authors?.FindAsync(author)) == null)
            {
                _context.Authors?.Add(author);
                _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Author with this Id already exists");
            }
            return author;
        }
        public Author UpdateAuthor(Author author)
        {
            if ((_context.Authors?.FindAsync(author)) == null)
            {
                throw new Exception("No Author with this Id exists");
            }
            _context.Authors.Update(author);
            _context.SaveChangesAsync();

            return author;
        }

        public void DeleteAuthor(Author author)
        {
            if ((_context.Authors?.FindAsync(author)) == null)
            {
                throw new Exception("No Doctor with this Id exists");
            }
            _context.Authors.Remove(author);
            _context.SaveChangesAsync();
        }
    }
}
