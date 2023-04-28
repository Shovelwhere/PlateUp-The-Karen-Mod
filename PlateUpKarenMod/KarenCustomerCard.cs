using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using TheKarenMod.CustType;


namespace TheKarenMod.Card
{
    public class KarenCustomerCard : CustomUnlockCard
    {
        public override string UniqueNameID => "KarenCustomerCard";
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("The Karen", "Seated Karens will lose patience when other groups are served before them", "Can I speak to the manager?"))
        };

        public override List<UnlockEffect> Effects => new List<UnlockEffect>
        {
            new StatusEffect()
            {
                Status = (RestaurantStatus)VariousUtils.GetID("karen")
            },

            new EnableGroupEffect()
            {
                Probability = 0.1f,
                EnableType = GDOUtils.GetCastedGDO<CustomerType, KarenCustomerType>()
            }
        };
    }

    public class HomeOwnersAssociationCard : CustomUnlockCard
    {
        public override string UniqueNameID => "HomeOwnersAssociationCard";
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, LocalisationUtils.CreateUnlockInfo("Home Owner's Association", "Some Karens become Mega Karens, who pay less, make more mess, and change their orders up to two times", "Do you know who I am?"))
        };

        public override List<UnlockEffect> Effects => new List<UnlockEffect>
        {
            new EnableGroupEffect()
            {
                Probability = 0.1f,
                EnableType = GDOUtils.GetCastedGDO<CustomerType, MegaKarenCustomerType>()
            }
        };

        public override List<Unlock> HardcodedRequirements => new List<Unlock>
        {
            GDOUtils.GetCastedGDO<Unlock, KarenCustomerCard>()
        };
    }
}
