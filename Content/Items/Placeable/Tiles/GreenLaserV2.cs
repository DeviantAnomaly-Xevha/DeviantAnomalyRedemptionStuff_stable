using DeviantAnomalyRedemptionStuff_stable.Content.Tiles.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Placeable.Tiles
{
    public class GreenLaserV2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Laser Block (Decorative)");
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<GreenLaserTileV2>(), 0);
            Item.width = 12;
            Item.height = 16;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(0, 0, 2, 0);
            Item.rare = ItemRarityID.LightPurple;
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("LabPlating", out var modItemName))
                {
                    CreateRecipe(4)
                        .AddIngredient(modItemName.Type)
                        .AddIngredient(ItemID.EmeraldGemsparkBlock)
                        .AddTile(TileID.WorkBenches)
                        .Register();
                }
            }
        }
    }
}
