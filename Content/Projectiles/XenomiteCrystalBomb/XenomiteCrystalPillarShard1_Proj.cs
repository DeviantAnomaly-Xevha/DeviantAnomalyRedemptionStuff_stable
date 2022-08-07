using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Projectiles.XenomiteCrystalBomb
{
    public class XenomiteCrystalPillarShard1_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.timeLeft = 120;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindNPCsAndTiles.Add(index);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AI()
        {
            Projectile.velocity.Y += 0.25f;
            Projectile.rotation = 0;
            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 2)
                {
                    Projectile.frame = 0;
                }
            }
        }
    }
}