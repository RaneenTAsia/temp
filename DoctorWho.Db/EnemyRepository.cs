using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class EnemyRepository
    {
        private DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public Enemy CreateEnemy(Enemy enemy)
        {
            if ((_context.Enemies?.FindAsync(enemy)) == null)
            {
                _context.Enemies?.Add(enemy);
                _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Enemy with this Id already exists");
            }
            return enemy;
        }
        public Enemy UpdateEnemy(Enemy enemy)
        {
            if ((_context.Enemies?.FindAsync(enemy)) == null)
            {
                throw new Exception("No Enemy with this Id exists");
            }
            _context.Enemies.Update(enemy);
            _context.SaveChangesAsync();

            return enemy;
        }

        public void DeleteEnemy(Enemy enemy)
        {
            if ((_context.Enemies?.FindAsync(enemy)) == null)
            {
                throw new Exception("No Enemy with this Id exists");
            }
            _context.Enemies.Remove(enemy);
            _context.SaveChangesAsync();
        }

        public Enemy GetEnemyWithId(int enemyId)
        {
            var enemy = _context.Enemies.Find(enemyId);
            if (enemy == null)
            {
                throw new Exception("Enemy with this Id does not exist");
            }
            return enemy;
        }
    }
}
