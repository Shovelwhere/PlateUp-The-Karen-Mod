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
            PlayerOutfitComponent player_outfit_component = player_cosmetic.Visual.AddComponent<PlayerOutfitComponent>();
            player_outfit_component.Renderers.Add(GameObjectUtils.GetChildObject(player_cosmetic.Visual, "Hair").GetComponent<SkinnedMeshRenderer>());
            MaterialUtils.ApplyMaterial<SkinnedMeshRenderer>(player_cosmetic.Visual, "Hair", new Material[] {
                MaterialUtils.GetExistingMaterial("Wax")
            });
        }
    }

    public class MegaKarenHairHat : CustomPlayerCosmetic
    {
        public override string UniqueNameID => "MegaKarenHairHat";
        public override CosmeticType CosmeticType => CosmeticType.Hat;
        public override GameObject Visual => Mod.bundle.LoadAsset<GameObject>("MegaKarenHairHat");
        public override bool BlockHats => true;

        public override void OnRegister(PlayerCosmetic player_cosmetic)
        {
            PlayerOutfitComponent player_outfit_component = player_cosmetic.Visual.AddComponent<PlayerOutfitComponent>();
            
            player_outfit_component.Renderers.Add(GameObjectUtils.GetChildObject(player_cosmetic.Visual, "Hair").GetComponent<SkinnedMeshRenderer>());
            MaterialUtils.ApplyMaterial<SkinnedMeshRenderer>(player_cosmetic.Visual, "Hair", new Material[] {
                MaterialUtils.GetExistingMaterial("Sack")
            });

            player_outfit_component.Renderers.Add(GameObjectUtils.GetChildObject(player_cosmetic.Visual, "Frame").GetComponent<SkinnedMeshRenderer>());
            MaterialUtils.ApplyMaterial<SkinnedMeshRenderer>(player_cosmetic.Visual, "Frame", new Material[] {
                MaterialUtils.GetExistingMaterial("Wood - Dark")
            });

            player_outfit_component.Renderers.Add(GameObjectUtils.GetChildObject(player_cosmetic.Visual, "Lens").GetComponent<SkinnedMeshRenderer>());
            MaterialUtils.ApplyMaterial<SkinnedMeshRenderer>(player_cosmetic.Visual, "Lens", new Material[] {
                MaterialUtils.GetExistingMaterial("Clothing Black Shiny")
            });
        }
    }
}
