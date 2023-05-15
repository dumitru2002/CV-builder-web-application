using System.Collections.Generic;
using System.Linq;
using CVBuilder.DAL;
using CVBuilder.Models;

namespace CVBuilder.BLL
{
    public class CVService : ICVService
    {
        private readonly ApplicationDbContext _dbContext;

        public CVService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCV(CV cv)
        {
            _dbContext.CVs.Add(cv);
            _dbContext.SaveChanges();
        }

        public void UpdateCV(CV cv)
        {
            _dbContext.CVs.Update(cv);
            _dbContext.SaveChanges();
        }

        public void DeleteCV(int cvId)
        {
            CV cv = _dbContext.CVs.Find(cvId);
            _dbContext.CVs.Remove(cv);
            _dbContext.SaveChanges();
        }

        public List<CV> GetCVs()
        {
            return _dbContext.CVs.ToList();
        }

        public CV GetCVById(int cvId)
        {
            return _dbContext.CVs.Find(cvId);
        }
    }
}
