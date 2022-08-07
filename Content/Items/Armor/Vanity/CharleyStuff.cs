using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Armor.Vanity
{

    [AutoloadEquip(EquipType.Head)]
    public class CharleyHairstyle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charley's hairstyle");
            Tooltip.SetDefault("[c/d3adff:Charley was here!]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.BrightPurpleDye, 1)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
    [AutoloadEquip(EquipType.Head)]
    public class CharleyHairstyle_Xenomite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite anomaly hairstyle - custom");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.\n----------\n#3D585A skin color suggested to match when blinking.\nTry Terrasavr.\n[c/d3adff:Charley was here!]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(0, 0, 1, 25);
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("XenomiteShard", out var modItemName))
                {
                    CreateRecipe()
                        .AddIngredient(modItemName.Type, 5)
                        .AddTile(TileID.Loom)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ItemID.Meteorite, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddTile(TileID.Loom)
                    .Register();
            }
        }
    }
    [AutoloadEquip(EquipType.Head)]
    public class CharleyHairstyle_XenomiteWithoutEyeHoles : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite anomaly hairstyle - custom (no eye holes)");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.\n[c/d3adff:Charley was here!]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(0, 0, 1, 25);
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("XenomiteShard", out var modItemName))
                {
                    CreateRecipe()
                        .AddIngredient(modItemName.Type, 5)
                        .AddTile(TileID.Loom)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ItemID.Meteorite, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddTile(TileID.Loom)
                    .Register();
            }
        }
    }
    [AutoloadEquip(EquipType.Head)]
    public class CharleyMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mothley mask");
            Tooltip.SetDefault("[c/d3adff:Charley was here!]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 26;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.BrightPurpleDye, 1)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}