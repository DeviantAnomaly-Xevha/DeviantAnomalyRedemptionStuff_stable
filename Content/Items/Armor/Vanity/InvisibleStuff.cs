using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Body)]
    public class DARSInvisibleBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Invisible Suit");
            Tooltip.SetDefault("'What a design! What colors! These are indeed royal robes!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 20;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddTile(TileID.Loom)
                .Register();
        }
    }
    [AutoloadEquip(EquipType.Legs)]
    public class DARSInvisibleLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Invisible Pants");
            Tooltip.SetDefault("'Feels like I'm wearing nothing at all!'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 12;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}