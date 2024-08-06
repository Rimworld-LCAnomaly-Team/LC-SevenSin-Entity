using LCAnomalyLibrary.Comp;
using LCAnomalyLibrary.Util;
using RimWorld;
using Verse;

namespace LC_SevenSin.Comp
{
    public class CompSevenSinEntity : LC_CompEntity
    {
        protected override LC_StudyResult CheckFinalStudyQuality(Pawn studier, EAnomalyWorkType workType)
        {
            //每级智力提供5%成功率，4级智力提供20%成功率
            float successRate_Intellectual = studier.skills.GetSkill(SkillDefOf.Intellectual).Level * 0.05f;
            //叠加基础成功率，此处是80%，叠加完应是100%
            float finalSuccessRate = successRate_Intellectual + Props.studySucessRateBase;
            //成功率不能超过95%
            if (finalSuccessRate >= 1f)
                finalSuccessRate = 0.95f;

            return Rand.Chance(finalSuccessRate) ? LC_StudyResult.Good : LC_StudyResult.Normal;
        }

        public override bool CheckStudierSkillRequire(Pawn studier)
        {
            if (studier.skills.GetSkill(SkillDefOf.Intellectual).Level < 1)
            {
                //Log.Message($"工作：{studier.Name}的技能{SkillDefOf.Intellectual.defName.Translate()}等级不足1，工作固定无法成功");
                return false;
            }

            return true;
        }
    }
}