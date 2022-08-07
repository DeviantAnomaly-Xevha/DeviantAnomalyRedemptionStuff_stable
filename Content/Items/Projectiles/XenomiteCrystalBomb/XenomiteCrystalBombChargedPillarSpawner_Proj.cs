using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Projectiles.XenomiteCrystalBomb
{
    public class XenomiteCrystalBombChargedPillarSpawner_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite crystal pillar");
        }
        public override void SetDefaults()
        {
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.timeLeft = 7;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            SoundEngine.PlaySound(new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalPillar_form"), Projectile.position);

            if (Main.rand.Next(1, 3) == 1)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 18f), new Vector2(0f, 12f), Mod.Find<ModProjectile>($"XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_1_Proj").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Main.projectile[a].CritChance = Projectile.CritChance;
                Main.projectile[a].friendly = true;
                Main.projectile[a].hostile = false;
                Main.projectile[a].ignoreWater = false;
                Main.projectile[a].tileCollide = true;
            }
            else
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 9f), new Vector2(0f, 12f), Mod.Find<ModProjectile>($"XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_2_Proj").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Main.projectile[a].CritChance = Projectile.CritChance;
                Main.projectile[a].friendly = true;
                Main.projectile[a].hostile = false;
                Main.projectile[a].ignoreWater = false;
                Main.projectile[a].tileCollide = true;
            }
        }
    }
}