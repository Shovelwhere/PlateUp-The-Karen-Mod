using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;

namespace TheKarenMod.CustType
{
    public class KarenCustomerType : CustomCustomerType
    {
        public override string UniqueNameID => "KarenCustomerType";
        public override bool IsGenericGroup => false;
        public override bool RelativeGroupSize => true;
        public override PatienceValues PatienceModifiers => PatienceValues.Ones;
        public override OrderingValues OrderingModifiers => OrderingValues.Ones;
        public override List<PlayerCosmetic> Cosmetics => new List<PlayerCosmetic>();
        public override List<ICustomerProperty> Properties => new List<ICustomerProperty>();
    }
}
