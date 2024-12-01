using LCAnomalyCore.Comp;
using LCAnomalyCore.Comp.Pawns;
using LCAnomalyCore.Util;

namespace LC_SevenSin.Comp
{
    public class CompSevenSinEntity : LC_CompEntity
    {
        protected override float StudySuccessRateCalculate(CompPawnStatus studier, EAnomalyWorkType workType)
        {
            float baseRate = base.StudySuccessRateCalculate(studier, workType);
            float workTypeRate = 0;
            float finalRate = 0;

            switch (workType)
            {
                case EAnomalyWorkType.Instinct:
                    //本能：70%
                    switch (studier.GetPawnStatusELevel(EPawnStatus.Fortitude))
                    {
                        default:
                            workTypeRate = 0.7f;
                            break;
                    }
                    break;
                case EAnomalyWorkType.Insight:
                    //洞察：70%
                    switch (studier.GetPawnStatusELevel(EPawnStatus.Prudence))
                    {
                        default:
                            workTypeRate = 0.7f;
                            break;
                    }
                    break;
                case EAnomalyWorkType.Attachment:
                    //沟通：70%
                    switch (studier.GetPawnStatusELevel(EPawnStatus.Temperance))
                    {
                        default:
                            workTypeRate = 0.7f;
                            break;
                    }
                    break;
                case EAnomalyWorkType.Repression:
                    //压迫：70%
                    switch (studier.GetPawnStatusELevel(EPawnStatus.Justice))
                    {
                        default:
                            workTypeRate = 0.7f;
                            break;
                    }
                    break;
            }

            finalRate = baseRate + workTypeRate;

            //成功率不能超过95%
            if (finalRate > 0.95f)
                finalRate = 0.95f;

            return finalRate;
        }
    }
}