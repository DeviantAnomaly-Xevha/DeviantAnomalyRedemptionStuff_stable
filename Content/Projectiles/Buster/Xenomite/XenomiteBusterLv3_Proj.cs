using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Projectiles.Buster.Xenomite
{
    internal class XenomiteBusterLv3_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Buster shot");
            Main.projFrames[Projectile.type] = 6;
        }
        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.width = 42;
            Projectile.height = 42;
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
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModBuff>("GreenRashesDebuff", out var modBuff1))
                {
                    target.AddBuff(modBuff1.Type, 300, false);
                    if (Main.rand.NextBool(5))
                    {
                        if (otherMod.TryFind<ModBuff>("GlowingPustulesDebuff", out var modBuff2))
                        {
                            target.AddBuff(modBuff2.Type, 150, false);
                        }
                    }
                }
            }
            else
            {
                target.AddBuff(BuffID.Poisoned, 300, false);
                if (Main.rand.NextBool(5))
                {
                    target.AddBuff(BuffID.Venom, 150, false);
                }
            }
            if (target.life > 0)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y), Projectile.velocity / 1000f, Mod.Find<ModProjectile>("XenomiteBusterLv3_Hit_Proj").Type, 0, 0, Main.myPlayer);
                Main.projectile[a].rotation = Projectile.rotation;
                Projectile.Kill();
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
            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 6)
                {
                    Projectile.frame = 0;
                }
            }
            Tile tile = Framing.GetTileSafely((int)(Projectile.Center.X * 0.0625f), (int)(Projectile.Center.Y * 0.0625f));
            if (tile != null && tile.HasUnactuatedTile == true && Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType])
            {
                Projectile.Kill();
            }
            Lighting.AddLight(Projectile.position, 0.17f, 0.76f, 0.19f);
        }
    }
}