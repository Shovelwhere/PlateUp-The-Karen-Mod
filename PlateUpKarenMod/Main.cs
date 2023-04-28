using KitchenLib;
using KitchenData;
using System.Reflection;
using TheKarenMod.Card;
using UnityEngine;
using KitchenLib.Utils;
using TheKarenMod.Hats;
using KitchenMods;
using System.Linq;
using TheKarenMod.CustType;
using KitchenLib.References;

namespace TheKarenMod
{
    public class Mod : BaseMod
    {
        public const string MOD_GUID = "Shovelwhere.PlateUp.TheKarenMod";
        public const string MOD_NAME = "TheKarenMod";
        public const string MOD_VERSION = "0.0.1";
        public const string MOD_AUTHOR = "Shovelwhere";
        public const string MOD_GAMEVERSION = ">=1.1.3";

        public static AssetBundle bundle;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];
            AddGameDataObject<KarenHairHat>();
            AddGameDataObject<MegaKarenHairHat>();
            AddGameDataObject<KarenCustomerType>();
            AddGameDataObject<MegaKarenCustomerType>();
            AddGameDataObject<KarenCustomerCard>();
            AddGameDataObject<HomeOwnersAssociationCard>();
        }
    }
}