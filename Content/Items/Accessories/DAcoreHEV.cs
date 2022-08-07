using DeviantAnomalyRedemptionStuff_stable.Content.Items.Armor.Vanity;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Accessories
{
    public class DAcoreHEV : ModItem
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
            DisplayName.SetDefault("Xenomite Anomaly Core+");
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                Tooltip.SetDefault("Transforms the holder into an aberration\nGreatly extends underwater breathing\nGrants immunity to Radioactive Fallout and all infection debuffs\nFeminine form (DA)\n[c/ff6464:-Does not grant immunity to the Abandoned Lab and Wasteland water!-]\n[c/ff6464:-Does not grant protection against radiation build-up!-]\n[c/ff6464:'HEVSuit' and 'WastelandWaterImmunity' benefits aren't possible at the moment]\n[c/6464ff:Currently grants immunity to radiation ailments]");
            }
            else
            {
                Tooltip.SetDefault("Transforms the holder into an aberration\nGreatly extends underwater breathing\nGrants immunity to toxins\nFeminine form (DA)");
            }
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 35));
            SetupDrawing();
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;
            Item.value = Item.buyPrice(1, 0, 5, 0);
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.canBePlacedInVanityRegardlessOfConditions = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var p = player.GetModPlayer<DACoreHEVPlayer>();
            p.HideVanity = hideVisual;
            p.VanityOn = true;
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModBuff>("HeavyRadiationDebuff", out var modBuff1) && otherMod.TryFind<ModBuff>("RadioactiveFalloutDebuff", out var modBuff2) && otherMod.TryFind<ModBuff>("GreenRashesDebuff", out var modBuff3) && otherMod.TryFind<ModBuff>("GlowingPustulesDebuff", out var modBuff4) && otherMod.TryFind<ModBuff>("FleshCrystalsDebuff", out var modBuff5) && otherMod.TryFind<ModBuff>("ShockDebuff", out var modBuff6))
                {
                    player.buffImmune[modBuff1.Type] = true;
                    player.buffImmune[modBuff2.Type] = true;
                    player.buffImmune[modBuff3.Type] = true;
                    player.buffImmune[modBuff4.Type] = true;
                    player.buffImmune[modBuff5.Type] = true;
                    player.buffImmune[modBuff6.Type] = true;
                }
                if (otherMod.TryFind<ModBuff>("HeadacheDebuff", out var radDebuff1) && otherMod.TryFind<ModBuff>("FatigueDebuff", out var radDebuff2) && otherMod.TryFind<ModBuff>("NauseaDebuff", out var radDebuff3) && otherMod.TryFind<ModBuff>("HairLossDebuff", out var radDebuff4) && otherMod.TryFind<ModBuff>("SkinBurnDebuff", out var radDebuff5) && otherMod.TryFind<ModBuff>("FeverDebuff", out var radDebuff6) && otherMod.TryFind<ModBuff>("RadiationDebuff", out var radDebuff7))
                {
                    player.buffImmune[radDebuff1.Type] = true;
                    player.buffImmune[radDebuff2.Type] = true;
                    player.buffImmune[radDebuff3.Type] = true;
                    player.buffImmune[radDebuff4.Type] = true;
                    player.buffImmune[radDebuff5.Type] = true;
                    player.buffImmune[radDebuff6.Type] = true;
                    player.buffImmune[radDebuff7.Type] = true;
                }
                else {}
            }
            else
            {
                player.buffImmune[BuffID.Poisoned] = true;
                player.buffImmune[BuffID.Venom] = true;
            }
            player.accDivingHelm = true;
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("HEVSuit", out var HEVSuit))
                {
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<DAcore>())
                        .AddIngredient(HEVSuit.Type, 1)
                        .AddTile(TileID.TinkerersWorkbench)
                        .Register();
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<DAcoreMHEV>())
                        .AddTile(TileID.TinkerersWorkbench)
                        .Register();
                }
            }
            else
            {}
        }
    }
    public class DAcoreMHEV : ModItem
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
            DisplayName.SetDefault("Xenomite Anomaly Core+");
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                Tooltip.SetDefault("Transforms the holder into an aberration\nGreatly extends underwater breathing\nGrants immunity to Radioactive Fallout and all infection debuffs\nMasculine form (DA)\n[c/ff6464:-Does not grant immunity to the Abandoned Lab and Wasteland water!-]\n[c/ff6464:-Does not grant protection against radiation build-up!-]\n[c/ff6464:'HEVSuit' and 'WastelandWaterImmunity' benefits aren't possible at the moment]\n[c/6464ff:Currently grants immunity to radiation ailments]");
            }
            else
            {
                Tooltip.SetDefault("Transforms the holder into an aberration\nGreatly extends underwater breathing\nGrants immunity to toxins\nFeminine form (DA)");
            }
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 35));
            SetupDrawing();
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;
            Item.value = Item.buyPrice(1, 0, 5, 0);
            Item.rare = ItemRarityID.Purple;
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
                if (otherMod.TryFind<ModBuff>("HeavyRadiationDebuff", out var modBuff1) && otherMod.TryFind<ModBuff>("RadioactiveFalloutDebuff", out var modBuff2) && otherMod.TryFind<ModBuff>("GreenRashesDebuff", out var modBuff3) && otherMod.TryFind<ModBuff>("GlowingPustulesDebuff", out var modBuff4) && otherMod.TryFind<ModBuff>("FleshCrystalsDebuff", out var modBuff5) && otherMod.TryFind<ModBuff>("ShockDebuff", out var modBuff6))
                {
                    player.buffImmune[modBuff1.Type] = true;
                    player.buffImmune[modBuff2.Type] = true;
                    player.buffImmune[modBuff3.Type] = true;
                    player.buffImmune[modBuff4.Type] = true;
                    player.buffImmune[modBuff5.Type] = true;
                    player.buffImmune[modBuff6.Type] = true;
                }
                if (otherMod.TryFind<ModBuff>("HeadacheDebuff", out var radDebuff1) && otherMod.TryFind<ModBuff>("FatigueDebuff", out var radDebuff2) && otherMod.TryFind<ModBuff>("NauseaDebuff", out var radDebuff3) && otherMod.TryFind<ModBuff>("HairLossDebuff", out var radDebuff4) && otherMod.TryFind<ModBuff>("SkinBurnDebuff", out var radDebuff5) && otherMod.TryFind<ModBuff>("FeverDebuff", out var radDebuff6) && otherMod.TryFind<ModBuff>("RadiationDebuff", out var radDebuff7))
                {
                    player.buffImmune[radDebuff1.Type] = true;
                    player.buffImmune[radDebuff2.Type] = true;
                    player.buffImmune[radDebuff3.Type] = true;
                    player.buffImmune[radDebuff4.Type] = true;
                    player.buffImmune[radDebuff5.Type] = true;
                    player.buffImmune[radDebuff6.Type] = true;
                    player.buffImmune[radDebuff7.Type] = true;
                }
                else { }
            }
            else
            {
                player.buffImmune[BuffID.Poisoned] = true;
                player.buffImmune[BuffID.Venom] = true;
            }
            player.accDivingHelm = true;
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("HEVSuit", out var HEVSuit))
                {
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<DAcoreM>())
                        .AddIngredient(HEVSuit.Type, 1)
                        .AddTile(TileID.TinkerersWorkbench)
                        .Register();
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<DAcoreHEV>())
                        .AddTile(TileID.TinkerersWorkbench)
                        .Register();
                }
            }
            else
            { }
        }
    }
    public class DACoreHEVPlayer : ModPlayer
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
                if (item.type == ModContent.ItemType<DAcoreHEV>())
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
                var DAcoreHEV = ModContent.GetInstance<DAcoreHEV>();
                Player.head = EquipLoader.GetEquipSlot(Mod, DAcoreHEV.Name, EquipType.Head);
                Player.body = EquipLoader.GetEquipSlot(Mod, DAcoreHEV.Name, EquipType.Body);
                Player.legs = EquipLoader.GetEquipSlot(Mod, DAcoreHEV.Name, EquipType.Legs);
            }
        }
    }
    public class DACoreMHEVPlayer : ModPlayer
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
                if (item.type == ModContent.ItemType<DAcoreMHEV>())
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
                var DAcoreMHEV = ModContent.GetInstance<DAcoreMHEV>();
                Player.head = EquipLoader.GetEquipSlot(Mod, DAcoreMHEV.Name, EquipType.Head);
                Player.body = EquipLoader.GetEquipSlot(Mod, DAcoreMHEV.Name, EquipType.Body);
                Player.legs = EquipLoader.GetEquipSlot(Mod, DAcoreMHEV.Name, EquipType.Legs);
            }
        }
    }
}