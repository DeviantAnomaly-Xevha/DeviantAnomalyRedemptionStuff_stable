using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Projectiles.XenomiteCrystalBomb
{
    public class XenomiteCrystalPillar_1_1_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite crystal pillar");
            Main.projFrames[Projectile.type] = 11;
        }
        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.width = 26;
            Projectile.height = 50;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 300;
            Projectile.ignoreWater = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
        }
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindNPCsAndTiles.Add(index);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
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
            SoundEngine.PlaySound(new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalPillar_shatter"), Projectile.position);

            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(0f - Main.rand.Next(1, 8), 0f - Main.rand.Next(1, 4)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(0f - Main.rand.Next(1, 6), 0f - Main.rand.Next(1, 8)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(1f - Main.rand.Next(0, 2), 0f - Main.rand.Next(1, 12)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(0f + Main.rand.Next(1, 6), 0f - Main.rand.Next(1, 8)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(0f + Main.rand.Next(1, 8), 0f - Main.rand.Next(1, 4)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
            Projectile.Kill();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate = -1;
            Projectile.maxPenetrate = -1;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.velocity = Vector2.Zero;

            return false;
        }
        public override void Kill(int timeLeft)
        {
            base.Kill(timeLeft);
            SoundEngine.PlaySound(new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalPillar_shatter"), Projectile.position);

            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(0f - Main.rand.Next(1, 8), 0f - Main.rand.Next(1, 4)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(0f - Main.rand.Next(1, 6), 0f - Main.rand.Next(1, 8)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(1f - Main.rand.Next(0, 2), 0f - Main.rand.Next(1, 12)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(0f + Main.rand.Next(1, 6), 0f - Main.rand.Next(1, 8)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), new Vector2(Projectile.Center.X, Projectile.Center.Y - 16f), new Vector2(0f + Main.rand.Next(1, 8), 0f - Main.rand.Next(1, 4)), Mod.Find<ModProjectile>($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj").Type, 0, 0, Main.myPlayer);
        }
        public override void AI()
        {
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
            Projectile.rotation = 0;

            if (++Projectile.frame <= 10)
            {
                if (++Projectile.frameCounter >= 1)
                {
                    Projectile.frameCounter = 0;
                }
            }
            else
            {
                Projectile.frame = 10;
            }
            for (int i = 0; i < Main.maxProjectiles; ++i)
            {
                Projectile p = Main.projectile[i];
                if (p.active && p.hostile && p.getRect().Intersects(Projectile.getRect()))
                {
                    p.velocity *= -1;
                    p.hostile = false;
                    p.friendly = true;
                    p.owner = Projectile.owner;
                }
            }
            Lighting.AddLight(Projectile.position, 0f, 0.4f, 0.1f);
        }
    }
}