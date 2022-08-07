using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Projectiles.XenomiteCrystalBomb
{
    public class XenomiteCrystalBombChargedLeftHalf_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite crystal");
            Main.projFrames[Projectile.type] = 12;
        }
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 16;
            Projectile.aiStyle = 1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalPillar_form"), Projectile.position);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 18), new Vector2(0, 12f), Mod.Find<ModProjectile>($"XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_1_Proj").Type, Projectile.damage, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X - 25, Projectile.Center.Y - 9), new Vector2(0, 12f), Mod.Find<ModProjectile>($"XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_2_Proj").Type, Projectile.damage, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X + 25, Projectile.Center.Y - 9), new Vector2(0, 12f), Mod.Find<ModProjectile>($"XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_2_Proj").Type, Projectile.damage, 0, Main.myPlayer);
            return true;
        }
        public override void AI()
        {
            Projectile.velocity.Y += 0.25f;
            Projectile.rotation = 0;

            if (++Projectile.frameCounter >= 1)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 12)
                {
                    Projectile.frame = 0;
                }
            }
            Lighting.AddLight(Projectile.position, 0f, 0.4f, 0.1f);
        }
    }
}