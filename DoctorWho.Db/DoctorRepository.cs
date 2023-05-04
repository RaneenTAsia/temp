using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class DoctorRepository
    {
        private DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public Doctor CreateDoctor(Doctor doctor)
        {
            if ((_context.Doctors?.FindAsync(doctor)) == null)
            {
                _context.Doctors?.Add(doctor);
                _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Doctor with this Id already exists");
            }
            return doctor;
        }
        public Doctor UpdateDoctor(Doctor doctor)
        {
            if ((_context.Doctors?.FindAsync(doctor)) == null)
            {
                throw new Exception("No Doctor with this Id exists");
            }
            _context.Doctors.Update(doctor);
            _context.SaveChangesAsync();

            return doctor;
        }

        public void DeleteDoctor(Doctor doctor)
        {
            if ((_context.Doctors?.FindAsync(doctor)) == null)
            {
                throw new Exception("No Doctor with this Id exists");
            }
            _context.Doctors.Remove(doctor);
            _context.SaveChangesAsync();
        }


        public List<Doctor> GetAvailableDoctors()
        {
            return _context.Doctors.ToList();
        }


    }
}
