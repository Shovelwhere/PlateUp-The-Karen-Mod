using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using TheKarenMod.Hats;

namespace TheKarenMod.CustType
{
    public class KarenCustomerType : CustomCustomerType
    {
        public override string UniqueNameID => "KarenCustomerType";
        public override bool IsGenericGroup => false;
        public override bool RelativeGroupSize => true;
        public override PatienceValues PatienceModifiers => PatienceValues.Ones;
        public override OrderingValues OrderingModifiers => OrderingValues.Ones;
        public override List<PlayerCosmetic> Cosmetics => new List<PlayerCosmetic>()
        {
            GDOUtils.GetCastedGDO<PlayerCosmetic, KarenHairHat>()
        };
        public override List<ICustomerProperty> Properties => new List<ICustomerProperty>();
    }

    public class MegaKarenCustomerType : CustomCustomerType
    {
        public override string UniqueNameID => "MegaKarenCustomerType";
        public override bool IsGenericGroup => false;
        public override bool RelativeGroupSize => true;
        public override PatienceValues PatienceModifiers => PatienceValues.Ones;
        public override OrderingValues OrderingModifiers => new OrderingValues
        {
            StarterModifier = 1f,
            DessertModifier = 1f,
            SidesModifier = 1f,
            ChangeMindModifier = 1f,
            RepeatCourseModifier = 0f,
            GroupOrdersSame = false,
            SidesOptional = false,
            IsOnlyFlatFee = false,
            FlatFee = 0,
            BonusPerDelivery = 0,
            PreventMess = false,
            MessFactor = 2.5f,
            PriceModifier = -0.5f
        };

        public override List<PlayerCosmetic> Cosmetics => new List<PlayerCosmetic>()
        {
            GDOUtils.GetCastedGDO<PlayerCosmetic, MegaKarenHairHat>()
        };
        public override List<ICustomerProperty> Properties => new List<ICustomerProperty>();
    }
}
