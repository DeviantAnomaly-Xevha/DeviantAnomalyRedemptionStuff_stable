using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class XenomiteAnomalyHairstyle5 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite anomaly hairstyle 5");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.\n----------\n#3D585A skin color suggested to match when blinking.\nTry Terrasavr.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.rare = ItemRarityID.Green;
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
    public class XenomiteAnomalyHairstyle5WithoutEyeHoles : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite anomaly hairstyle 5 (no eye holes)");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.rare = ItemRarityID.Green;
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
    public class XenomiteAnomalyHairstyle22 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite anomaly hairstyle 22");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.\n----------\n#3D585A skin color suggested to match when blinking.\nTry Terrasavr.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.rare = ItemRarityID.Green;
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
    public class XenomiteAnomalyHairstyle22WithoutEyeHoles : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite anomaly hairstyle 22 (no eye holes)");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.rare = ItemRarityID.Green;
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
}