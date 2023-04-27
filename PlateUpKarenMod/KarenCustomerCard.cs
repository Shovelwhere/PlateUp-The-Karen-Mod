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
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;

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
}
