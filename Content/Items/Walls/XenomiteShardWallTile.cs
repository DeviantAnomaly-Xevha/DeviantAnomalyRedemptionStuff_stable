using Microsoft.Xna.Framework;
using DeviantAnomalyRedemptionStuff_stable.Content.Items.Placeable.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Walls
{
    public class XenomiteShardWallTile : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            DustType = DustID.GreenTorch;
            ItemDrop = ModContent.ItemType<XenomiteShardWall>();
            AddMapEntry(new Color(32, 158, 88));
        }
    }
}