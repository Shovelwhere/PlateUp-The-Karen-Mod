using KitchenLib;
using KitchenData;
using System.Reflection;
using TheKarenMod.Card;
using KitchenLib.References;
using System.Diagnostics;
using UnityEngine;
using KitchenLib.Utils;
using System.Collections.Generic;
using TheKarenMod.Hats;
using KitchenMods;
using System.Linq;
using Kitchen;

namespace TheKarenMod
{
    public class Mod : BaseMod
    {
        public const string MOD_GUID = "WhenisDinner.PlateUp.TheKarenMod";
        public const string MOD_NAME = "TheKarenMod";
        public const string MOD_VERSION = "0.0.1";
        public const string MOD_AUTHOR = "WhenisDinner";
        public const string MOD_GAMEVERSION = ">=1.1.3";

        public static AssetBundle bundle;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];
            AddGameDataObject<KarenCustomerType>();
            AddGameDataObject<KarenCustomerCard>();
            AddGameDataObject<KarenHairHat>();
        }

        protected override void OnInitialise()
        {
            GDOUtils.GetCastedGDO<CustomerType,KarenCustomerType>().Cosmetics.Add(GDOUtils.GetCastedGDO<PlayerCosmetic, KarenHairHat>());
        }
    }
}