using System;
using Verse;

namespace BetterCV
{

	public class PlaceWorker_OnWall : PlaceWorker
	{

		public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
		{
			Building edifice = GridsUtility.GetEdifice(loc, map);
			bool flag = edifice == null;
			AcceptanceReport result;
			if (flag)
			{
				result = Translator.Translate("MessagePlacementOnSupport");
			}
			else
			{
				bool flag2 = edifice.def == null;
				if (flag2)
				{
					result = Translator.Translate("MessagePlacementOnSupport");
				}
				else
				{
					bool isSmoothed = edifice.def.IsSmoothed;
					if (isSmoothed)
					{
						result = AcceptanceReport.WasAccepted;
					}
					else
					{
						bool flag3 = edifice.def.graphicData == null;
						if (flag3)
						{
							result = Translator.Translate("MessagePlacementOnSupport");
						}
						else
						{
							result = (((edifice.def.graphicData.linkFlags) != 0) ? AcceptanceReport.WasAccepted : Translator.Translate("MessagePlacementOnSupport"));
						}
					}
				}
			}
			return result;
		}
	}
}
