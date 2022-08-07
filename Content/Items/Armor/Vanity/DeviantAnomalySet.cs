using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class DeviantAnomalyHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xevha's head");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.\n----------\n#3D585A skin color suggested to match when blinking.\nTry Terrasavr.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
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
    public class DeviantAnomalyHeadWithoutEyeHoles : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xevha's head (no eye holes)");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
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
    public class DeviantAnomalyHeadOldStyle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xevha's head (old hairstyle)");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.\n----------\n#3D585A skin color suggested to match when blinking.\nTry Terrasavr.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;
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
    public class DeviantAnomalyHeadOldStyleWithoutEyeHoles : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xevha's head (old hairstyle, no eye holes)");
            Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;
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
    [AutoloadEquip(EquipType.Body)]
    public class DeviantAnomalyBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xevha's body");
            Tooltip.SetDefault("You are one with the crystals.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Body.Sets.HidesArms[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body)] = true;
            ArmorIDs.Body.Sets.HidesTopSkin[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body)] = true;
            ArmorIDs.Body.Sets.HidesBottomSkin[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body)] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 20;
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
    [AutoloadEquip(EquipType.Legs)]
    public class DeviantAnomalyLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xevha's Legs");
            Tooltip.SetDefault("What's up with your feet?");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Legs.Sets.OverridesLegs[EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs)] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 12;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 1, 25);
            Item.vanity = true;
        }
        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            if (!male) equipSlot = DeviantAnomalyRedemptionStuff_stable.xevhaFemLegID;
            if (male) equipSlot = DeviantAnomalyRedemptionStuff_stable.xevhaMaleLegID;
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
    public class DeviantAnomalyHairstyle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xevha's hairstyle");
            Tooltip.SetDefault("99.9% Xenomite-free");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 1, 25);
            Item.vanity = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.GreenDye, 1)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}