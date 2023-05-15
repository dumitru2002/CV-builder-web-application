using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using CVBuilder.BLL.Entities;
using CVBuilder.BLL.Interfaces;
using CVBuilder.DAL;

namespace CVBuilder.BLL.Services
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

        public List<Education> GetEducationsByCVId(int cvId)
        {
            return _dbContext.Educations.Where(e => e.CVId == cvId).ToList();
        }

        public List<Experience> GetExperiencesByCVId(int cvId)
        {
            return _dbContext.Experiences.Where(e => e.CVId == cvId).ToList();
        }

        public List<Skill> GetSkillsByCVId(int cvId)
        {
            return _dbContext.Skills.Where(s => s.CVId == cvId).ToList();
        }
    }
}

