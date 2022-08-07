using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Projectiles.XenomiteCrystalBomb
{
    public class XenomiteCrystalBomb_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite crystal");
            Main.projFrames[Projectile.type] = 12;
        }
        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.knockBack = 4f;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = Projectile.timeLeft;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.defDefense >= Projectile.damage * .75 || target.takenDamageMultiplier <= .25)
            {
                SoundEngine.PlaySound(new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalPillar_shatter"), Projectile.position);
                int a = Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X - 2, Projectile.Center.Y), new Vector2(-1f, -1f), Mod.Find<ModProjectile>("XenomiteCrystalBombLeftHalf_Proj").Type, Projectile.damage / 2, 0, Main.myPlayer);
                Main.projectile[a].CritChance = Projectile.CritChance;
                int b = Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X + 2, Projectile.Center.Y), new Vector2(1f, -1f), Mod.Find<ModProjectile>("XenomiteCrystalBombRightHalf_Proj").Type, Projectile.damage / 2, 0, Main.myPlayer);
                Main.projectile[b].CritChance = Projectile.CritChance;
                Projectile.Kill();
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
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalPillar_form"), Projectile.position);
            int a = Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 18), new Vector2(0, 12f), Mod.Find<ModProjectile>($"XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_1_Proj").Type, Projectile.damage / 2, 0, Main.myPlayer);
            Main.projectile[a].CritChance = Projectile.CritChance;
            int b = Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X - 25, Projectile.Center.Y - 9), new Vector2(0, 12f), Mod.Find<ModProjectile>($"XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_2_Proj").Type, Projectile.damage / 2, 0, Main.myPlayer);
            Main.projectile[b].CritChance = Projectile.CritChance;
            int c = Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X + 25, Projectile.Center.Y - 9), new Vector2(0, 12f), Mod.Find<ModProjectile>($"XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_2_Proj").Type, Projectile.damage / 2, 0, Main.myPlayer);
            Main.projectile[c].CritChance = Projectile.CritChance;
            return true;
        }
        public override void AI()
        {
            Projectile.velocity.Y += .25f;
            Projectile.rotation = 0;
            if (++Projectile.frameCounter >= 1)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 12)
                {
                    Projectile.frame = 0;
                }
            }

            int num = Dust.NewDust(new Vector2(Projectile.Center.X - 8, Projectile.Center.Y - 8), Projectile.width, Projectile.height, DustID.CursedTorch, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), .5f);
            Main.dust[num].scale *= 1.5f;
            Main.dust[num].noGravity = true;
            Main.dust[num].color = new Color(0, 98, 93);
            if (Main.rand.NextBool(2))
            {
                Main.dust[num].scale *= 1.5f;
            }
            Lighting.AddLight(Projectile.position, 0f, 0.4f, 0.1f);
        }
    }
}