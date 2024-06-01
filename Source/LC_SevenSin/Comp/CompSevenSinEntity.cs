using LCAnomalyLibrary.Comp;
using RimWorld;
using Verse;

namespace LC_SevenSin.Comp
{
    public class CompSevenSinEntity : LC_CompEntity
    {
        public override void Notify_Escaped()
        {
        }

        public override void Notify_Studied(Pawn studier)
        {
            if (studier == null)
                return;

            CheckIfStudySuccess(studier);
        }

        public override void PostPostMake()
        {
            biosignature = Rand.Int;
        }

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
        }

        protected override bool CheckIfFinalStudySuccess(Pawn studier)
        {
            //每级智力提供5%成功率，4级智力提供20%成功率
            float successRate_Intellectual = studier.skills.GetSkill(SkillDefOf.Intellectual).Level * 0.05f;
            //叠加基础成功率，此处是80%，叠加完应是100%
            float finalSuccessRate = successRate_Intellectual + Props.studySucessRateBase;

            return Rand.Chance(finalSuccessRate);
        }

        protected override bool CheckStudierSkillRequire(Pawn studier)
        {
            if (studier.skills.GetSkill(SkillDefOf.Intellectual).Level < 1)
            {
                Log.Message($"研究者{studier.Name}的技能{SkillDefOf.Intellectual.defName.Translate()}不足1，研究固定无法成功");
                return false;
            }

            return true;
        }

        protected override void StudyEvent_Failure(Pawn studier)
        {
            base.StudyEvent_Failure(studier);
        }

        protected override void StudyEvent_Success(Pawn studier)
        {
            base.StudyEvent_Success(studier);
        }
    }
}
