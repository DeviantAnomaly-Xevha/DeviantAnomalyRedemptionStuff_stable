using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class FlanCap : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Flancap");
            Tooltip.SetDefault("The overexaggerated swagger of a gay vampire.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.BrightYellowDye, 1)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}