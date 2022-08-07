using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DeviantAnomalyRedemptionStuff_stable.Content.Items.Armor.Vanity;

namespace DeviantAnomalyRedemptionStuff_stable
{
	public class DeviantAnomalyRedemptionStuff_stable : Mod
	{
		public static DeviantAnomalyRedemptionStuff_stable Instance { get; private set; }

		public static int xevhaFemLegID;
		public static int xevhaMaleLegID;
		public static int xevhaTransformFemLegID;
		public static int xevhaTransformMaleLegID;

		public DeviantAnomalyRedemptionStuff_stable()
        {
			Instance = this;
        }
		public override void Load()
        {
			if (!Main.dedServ)
			{
				xevhaFemLegID = EquipLoader.AddEquipTexture(this, "DeviantAnomalyRedemptionStuff_stable/Content/Items/Armor/Vanity/DeviantAnomalyLegs_FemaleLegs", EquipType.Legs, ModContent.GetInstance<DeviantAnomalyLegs>());
				xevhaMaleLegID = EquipLoader.AddEquipTexture(this, "DeviantAnomalyRedemptionStuff_stable/Content/Items/Armor/Vanity/DeviantAnomalyLegs_Legs", EquipType.Legs, ModContent.GetInstance<DeviantAnomalyLegs>());
			}
        }
        public override void AddRecipeGroups()
        {
			RecipeGroup DARSGoldOrPlatinumBar = new RecipeGroup(() => "Gold or Platinum Bar", new int[]
			{
				ItemID.AdamantiteBar,
				ItemID.TitaniumBar
			});
			RecipeGroup.RegisterGroup("DeviantAnomalyRedemptionStuff:Gold or Platinum Bar", DARSGoldOrPlatinumBar);

			RecipeGroup DARSAdamantiteOrTitaniumBar = new RecipeGroup(() => "Adamantite or Titanium Bar", new int[]
			{
				ItemID.AdamantiteBar,
				ItemID.TitaniumBar
			});
			RecipeGroup.RegisterGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", DARSAdamantiteOrTitaniumBar);

			RecipeGroup DARSCursedFlameOrIchor = new RecipeGroup(() => "Cursed Flame or Ichor", new int[]
			{
				ItemID.CursedFlame,
				ItemID.Ichor
			});
			RecipeGroup.RegisterGroup("DeviantAnomalyRedemptionStuff:Cursed Flame or Ichor", DARSCursedFlameOrIchor);

			RecipeGroup DARSVineReference = new RecipeGroup(() => "some kind of vine", new int[]
			{
				ItemID.Vine,
				ItemID.VineRope,
				ItemID.VineRopeCoil
			});
			RecipeGroup.RegisterGroup("DeviantAnomalyRedemptionStuff:some kind of vine", DARSVineReference);
		}
        public override void AddRecipes()
		{
			Recipe.Create(ItemID.Tombstone)
				.AddIngredient(ItemID.StoneBlock, 25)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.GraveMarker)
				.AddIngredient(ItemID.Wood, 20)
				.AddRecipeGroup("DeviantAnomalyRedemptionStuff:some kind of vine", 5)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.CrossGraveMarker)
				.AddIngredient(ItemID.Wood, 25)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.Headstone)
				.AddIngredient(ItemID.StoneBlock, 25)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.Gravestone)
				.AddIngredient(ItemID.StoneBlock, 20)
				.AddRecipeGroup("DeviantAnomalyRedemptionStuff:some kind of vine", 5)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.Obelisk)
				.AddIngredient(ItemID.Obsidian, 25)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.RichGravestone1)
				.AddIngredient(ItemID.Obsidian, 20)
				.AddRecipeGroup("DeviantAnomalyRedemptionStuff:Gold or Platinum Bar", 2)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.RichGravestone2)
				.AddIngredient(ItemID.Obsidian, 20)
				.AddRecipeGroup("DeviantAnomalyRedemptionStuff:Gold or Platinum Bar", 2)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.RichGravestone3)
				.AddIngredient(ItemID.Obsidian, 20)
				.AddRecipeGroup("DeviantAnomalyRedemptionStuff:Gold or Platinum Bar", 2)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.RichGravestone4)
				.AddIngredient(ItemID.Obsidian, 20)
				.AddRecipeGroup("DeviantAnomalyRedemptionStuff:Gold or Platinum Bar", 2)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			Recipe.Create(ItemID.RichGravestone5)
				.AddIngredient(ItemID.Obsidian, 20)
				.AddRecipeGroup("DeviantAnomalyRedemptionStuff:Gold or Platinum Bar", 2)
				.AddTile(TileID.HeavyWorkBench)
				.Register();
		}
	}
}