using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Projectiles.Buster.Xenomite
{
    internal class XenomiteBusterLv1_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Buster shot");
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 120;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.boss && target.life > 0)
            {
                SoundEngine.PlaySound(new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_basic_hit"), Projectile.position);
            }
            else if (target.boss)
            {
                SoundEngine.PlaySound(new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_boss_hit"), Projectile.position);
            }
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y), Projectile.velocity, Mod.Find<ModProjectile>("XenomiteBusterLv1_and_Lv4_Hit_Proj").Type, 0, 0, Main.myPlayer);
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModBuff>("GreenRashesDebuff", out var modBuff1))
                {
                    target.AddBuff(modBuff1.Type, 100, false);
                    if (Main.rand.NextBool(5))
                    {
                        if (otherMod.TryFind<ModBuff>("GlowingPustulesDebuff", out var modBuff2))
                        {
                            target.AddBuff(modBuff2.Type, 50, false);
                        }
                    }
                }
            }
            else
            {
                target.AddBuff(BuffID.Poisoned, 100, false);
                if (Main.rand.NextBool(5))
                {
                    target.AddBuff(BuffID.Venom, 50, false);
                }
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            base.DrawHeldProjInFrontOfHeldItemAndArms = true;
            Main.player[Projectile.owner].heldProj = Projectile.whoAmI;
            Tile tile = Framing.GetTileSafely((int)(Projectile.Center.X * 0.0625f), (int)(Projectile.Center.Y * 0.0625f));
            if (tile != null && tile.HasUnactuatedTile == true && Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType])
            {
                Projectile.Kill();
            }
            Lighting.AddLight(Projectile.position, 0f,0.38f,0.36f);
        }
    }
}