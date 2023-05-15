using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.BLL.Interfaces
{
    public interface ICVService
    {
        void CreateCV(CV cv);
        void UpdateCV(CV cv);
        void DeleteCV(int cvId);
        List<CV> GetCVs();
        CV GetCVById(int cvId);
        List<Education> GetEducationsByCVId(int cvId);
        List<Experience> GetExperiencesByCVId(int cvId);
        List<Skill> GetSkillsByCVId(int cvId);
    }
}
