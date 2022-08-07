using DeviantAnomalyRedemptionStuff_stable.Content.Items.Armor.Vanity;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Accessories
{
    public class DAcore : ModItem
    {
        public override void Load()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, Item.ModItem, null, new EquipTexture());
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, Item.ModItem, null, new EquipTexture());
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, Item.ModItem, null, new EquipTexture());
            }
        }
        private void SetupDrawing()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                int equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
                int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);

                ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
                ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
                ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
                ArmorIDs.Legs.Sets.OverridesLegs[equipSlotLegs] = true;
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Anomaly Core");
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                Tooltip.SetDefault("Transforms the holder into an aberration\nGrants immunity to the infection\nFeminine form (DA)");
            }
            else
            {
                Tooltip.SetDefault("Transforms the holder into an aberration\nGrants immunity to toxins\nFeminine form (DA)");
            }
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            SetupDrawing();
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;
            Item.value = Item.buyPrice(0, 0, 5, 0);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.canBePlacedInVanityRegardlessOfConditions = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var p = player.GetModPlayer<DACorePlayer>();
            p.HideVanity = hideVisual;
            p.VanityOn = true;
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModBuff>("GreenRashesDebuff", out var modBuff1) && otherMod.TryFind<ModBuff>("GlowingPustulesDebuff", out var modBuff2) && otherMod.TryFind<ModBuff>("FleshCrystalsDebuff", out var modBuff3) && otherMod.TryFind<ModBuff>("ShockDebuff", out var modBuff4))
                {
                    player.buffImmune[modBuff1.Type] = true;
                    player.buffImmune[modBuff2.Type] = true;
                    player.buffImmune[modBuff3.Type] = true;
                    player.buffImmune[modBuff4.Type] = true;
                }
            }
            else
            {
                player.buffImmune[BuffID.Poisoned] = true;
                player.buffImmune[BuffID.Venom] = true;
            }
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("CrystalSerum", out var modItem))
                {
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<DeviantAnomalyHead>())
                        .AddIngredient(ModContent.ItemType<DeviantAnomalyBody>())
                        .AddIngredient(ModContent.ItemType<DeviantAnomalyLegs>())
                        .AddIngredient(modItem.Type, 10)
                        .AddTile(TileID.Anvils)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<DeviantAnomalyHead>())
                    .AddIngredient(ModContent.ItemType<DeviantAnomalyBody>())
                    .AddIngredient(ModContent.ItemType<DeviantAnomalyLegs>())
                    .AddIngredient(ItemID.Bezoar, 1)
                    .AddTile(TileID.Anvils)
                    .Register();
            }
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<DAcoreM>())
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
    public class DAcoreM : ModItem
    {
        public override void Load()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, Item.ModItem, null, new EquipTexture());
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, Item.ModItem, null, new EquipTexture());
                EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, Item.ModItem, null, new EquipTexture());
            }
        }
        private void SetupDrawing()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                int equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
                int equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);

                ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
                ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
                ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
                ArmorIDs.Legs.Sets.OverridesLegs[equipSlotLegs] = true;
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Anomaly Core");
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                Tooltip.SetDefault("Transforms the holder into an aberration\nGrants immunity to the infection\nMasculine form (DA)");
            }
            else
            {
                Tooltip.SetDefault("Transforms the holder into an aberration\nGrants immunity to toxins\nMasculine form (DA)");
            }
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            SetupDrawing();
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;
            Item.value = Item.buyPrice(0, 0, 5, 0);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.canBePlacedInVanityRegardlessOfConditions = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var p = player.GetModPlayer<DACoreMHEVPlayer>();
            p.HideVanity = hideVisual;
            p.VanityOn = true;
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModBuff>("GreenRashesDebuff", out var modBuff1) && otherMod.TryFind<ModBuff>("GlowingPustulesDebuff", out var modBuff2) && otherMod.TryFind<ModBuff>("FleshCrystalsDebuff", out var modBuff3) && otherMod.TryFind<ModBuff>("ShockDebuff", out var modBuff4))
                {
                    player.buffImmune[modBuff1.Type] = true;
                    player.buffImmune[modBuff2.Type] = true;
                    player.buffImmune[modBuff3.Type] = true;
                    player.buffImmune[modBuff4.Type] = true;
                }
            }
            else
            {
                player.buffImmune[BuffID.Poisoned] = true;
                player.buffImmune[BuffID.Venom] = true;
            }
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("CrystalSerum", out var modItem))
                {
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<DeviantAnomalyHead>())
                        .AddIngredient(ModContent.ItemType<DeviantAnomalyBody>())
                        .AddIngredient(ModContent.ItemType<DeviantAnomalyLegs>())
                        .AddIngredient(modItem.Type, 10)
                        .AddTile(TileID.Anvils)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<DeviantAnomalyHead>())
                    .AddIngredient(ModContent.ItemType<DeviantAnomalyBody>())
                    .AddIngredient(ModContent.ItemType<DeviantAnomalyLegs>())
                    .AddIngredient(ItemID.Bezoar, 1)
                    .AddTile(TileID.Anvils)
                    .Register();
            }
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<DAcore>())
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
    public class DACorePlayer : ModPlayer
    {
        public bool HideVanity;
        public bool ForceVanity;
        public bool VanityOn;
        public override void ResetEffects()
        {
            VanityOn = HideVanity = ForceVanity = false;
        }
        public override void UpdateVisibleVanityAccessories()
        {
            for (int n = 13; n < 18 + Player.GetAmountOfExtraAccessorySlotsToShow(); n++)
            {
                Item item = Player.armor[n];
                if (item.type == ModContent.ItemType<DAcore>())
                {
                    HideVanity = false;
                    ForceVanity = true;
                }
            }
        }
        public override void FrameEffects()
        {
            if ((VanityOn || ForceVanity) && !HideVanity)
            {
                var DAcore = ModContent.GetInstance<DAcore>();
                Player.head = EquipLoader.GetEquipSlot(Mod, DAcore.Name, EquipType.Head);
                Player.body = EquipLoader.GetEquipSlot(Mod, DAcore.Name, EquipType.Body);
                Player.legs = EquipLoader.GetEquipSlot(Mod, DAcore.Name, EquipType.Legs);
            }
        }
    }
    public class DACoreMPlayer : ModPlayer
    {
        public bool HideVanity;
        public bool ForceVanity;
        public bool VanityOn;
        public override void ResetEffects()
        {
            VanityOn = HideVanity = ForceVanity = false;
        }
        public override void UpdateVisibleVanityAccessories()
        {
            for (int n = 13; n < 18 + Player.GetAmountOfExtraAccessorySlotsToShow(); n++)
            {
                Item item = Player.armor[n];
                if (item.type == ModContent.ItemType<DAcoreM>())
                {
                    HideVanity = false;
                    ForceVanity = true;
                }
            }
        }
        public override void FrameEffects()
        {
            if ((VanityOn || ForceVanity) && !HideVanity)
            {
                var DAcoreM = ModContent.GetInstance<DAcoreM>();
                Player.head = EquipLoader.GetEquipSlot(Mod, DAcoreM.Name, EquipType.Head);
                Player.body = EquipLoader.GetEquipSlot(Mod, DAcoreM.Name, EquipType.Body);
                Player.legs = EquipLoader.GetEquipSlot(Mod, DAcoreM.Name, EquipType.Legs);
            }
        }
    }
}