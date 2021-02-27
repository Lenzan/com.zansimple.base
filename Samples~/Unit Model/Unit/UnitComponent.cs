using System.Collections.Generic;
using System.Linq;

namespace Framework
{
	
	public class UnitComponent: Entity
	{
		public Dictionary<long, Unit> idUnits = new Dictionary<long, Unit>();
		public Unit MyUnit;
	}
}