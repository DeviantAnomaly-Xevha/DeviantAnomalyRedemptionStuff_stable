using DeviantAnomalyRedemptionStuff_stable.Content.Items.Placeable.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Tiles.Tiles
{
    public class GreenLaserTileV2 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
            Main.tileLighted[Type] = true;
            DustType = DustID.Electric;
            ItemDrop = ModContent.ItemType<GreenLaserV2>();
            MinPick = 0;
            MineResist = 3f;
            HitSound = SoundID.Tink;
            AddMapEntry(new Color(0, 246, 83));
		}
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Vector2 zero = new(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
                zero = Vector2.Zero;

            int height = tile.TileFrameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(ModContent.Request<Texture2D>("DeviantAnomalyRedemptionStuff_stable/Content/Tiles/Tiles/GreenLaserTileV2_Glow").Value, new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.0f;
            g = 0.3f;
            b = 0.0f;
        }
        public override bool CanExplode(int i, int j) => false;
    }
}