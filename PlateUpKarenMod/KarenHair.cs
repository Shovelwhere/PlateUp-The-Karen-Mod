using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TheKarenMod.Hats
{
    public class KarenHairHat : CustomPlayerCosmetic
    {
        public override string UniqueNameID => "KarenHairHat";
        public override CosmeticType CosmeticType => CosmeticType.Hat;
        public override GameObject Visual => Mod.bundle.LoadAsset<GameObject>("KarenHairHat");
        public override bool BlockHats => true;

        public override void OnRegister(PlayerCosmetic player_cosmetic)
        {
            GameObject Prefab = player_cosmetic.Visual;
            PlayerOutfitComponent player_outfit_component = Prefab.AddComponent<PlayerOutfitComponent>();
            player_outfit_component.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Hair").GetComponent<SkinnedMeshRenderer>());
            MaterialUtils.ApplyMaterial<SkinnedMeshRenderer>(Prefab, "Hair", new Material[] {
                MaterialUtils.GetExistingMaterial("Wax")
            });


        }
    }
}
