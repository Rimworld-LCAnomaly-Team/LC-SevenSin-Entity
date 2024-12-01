using LC_SevenSin.Comp;
using LCAnomalyCore.Comp;

namespace LC_SevenSin.Things
{
    public class LC_SevenSinPawn : LC_EntityBasePawn
    {
        public LC_SevenSinPawn()
        {

        }

        public override void Tick()
        {
            //收容状态下丢下就出逃
            if (CarriedBy == null)
            {
                GetComp<CompSevenSinEntity>()?.Notify_Escaped();
            }

            base.Tick();
        }
    }
}