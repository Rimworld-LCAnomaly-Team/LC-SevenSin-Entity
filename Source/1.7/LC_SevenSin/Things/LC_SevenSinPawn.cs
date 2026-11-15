using LC_SevenSin.Comp;
using LCAnomalyCore.Comp;

namespace LC_SevenSin.Things
{
    public class LC_SevenSinPawn : LC_EntityBasePawn
    {
        public LC_SevenSinPawn()
        {

        }

        protected override void Tick()
        {
            //收容状态下丢下就出逃
            if (Spawned && CarriedBy == null && EntityComp != null && !EntityComp.Escaped)
            {
                GetComp<CompSevenSinEntity>()?.Notify_Escaped();
            }

            base.Tick();
        }
    }
}
