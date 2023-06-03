namespace CVBuilderAuth.Models
{
    public class CombinedViewModel
    {
        public IEnumerable<UserCvInfo> UserCvInfoData { get; set; }
        public IEnumerable<CvExperience> CvExperienceData { get; set;}
        public IEnumerable<CvLanguageSkill> CvLanguageSkillData { get; set;}
        public IEnumerable<CvSkill> CvSkillsData { get; set;}
        public IEnumerable<CvEducation> CvEducationData { get; set; }
    }
}
