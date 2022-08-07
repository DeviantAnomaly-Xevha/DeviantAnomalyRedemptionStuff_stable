using Terraria.ModLoader;
using Terraria.ID;
using DeviantAnomalyRedemptionStuff_stable.Content.Walls;
using Terraria.GameContent.Creative;
using Terraria;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Placeable.Tiles
{
    public class XenomiteShardWall : ModItem
    {
        public int infectionTimer;
        public bool glowingPustules;
        public bool fleshCrystals;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Shard Wall");
            Tooltip.SetDefault("Holding this may infect you.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlacableWall((ushort)ModContent.WallType<XenomiteShardWallTile>());
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
        }
        public override void HoldItem(Player player)
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModBuff>("AntibodiesDebuff", out var antibodiesBuff) && otherMod.TryFind<ModBuff>("GreenRashesDebuff", out var greenRashes) && otherMod.TryFind<ModBuff>("GlowingPustulesDebuff", out var glowingPustules) && otherMod.TryFind<ModBuff>("FleshCrystalsDebuff", out var fleshCrystals) && otherMod.TryFind<ModBuff>("ShockDebuff", out var shockDebuff))
                {
                    if (player.HasBuff(greenRashes.Type))
                    {
                        infectionTimer++;
                        if (player.HasBuff(antibodiesBuff.Type))
                        {
                            player.ClearBuff(greenRashes.Type);
                            infectionTimer = 0;
                        }
                        if (infectionTimer >= 3600)
                        {
                            player.ClearBuff(greenRashes.Type);
                            player.AddBuff(glowingPustules.Type, 10000);
                            infectionTimer = 0;
                        }
                    }
                    else if (player.HasBuff(glowingPustules.Type))
                    {
                        infectionTimer++;
                        if (infectionTimer >= 3600)
                        {
                            player.ClearBuff(glowingPustules.Type);
                            player.AddBuff(fleshCrystals.Type, 10000);
                            infectionTimer = 0;
                        }
                    }
                    else if (player.HasBuff(fleshCrystals.Type))
                    {
                        infectionTimer++;
                        if (infectionTimer >= 3600)
                        {
                            player.AddBuff(shockDebuff.Type, 10000);
                            infectionTimer = 0;
                        }
                    }
                    else
                    {
                        if (infectionTimer >= 3000)
                        {
                            player.AddBuff(antibodiesBuff.Type, 18000);
                        }
                        infectionTimer = 0;
                    }
                }
            }
            else {}
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("XenomiteShard", out var modItemName))
                {
                    CreateRecipe(4)
                        .AddIngredient(modItemName.Type)
                        .AddTile(TileID.WorkBenches)
                        .Register();
                    CreateRecipe(1)
                        .AddIngredient(ModContent.ItemType<XenomiteShardWallUnsafe>())
                        .AddTile(TileID.WorkBenches)
                        .Register();
                }
            }
        }
    }
}