using DeviantAnomalyRedemptionStuff_stable.Content.Projectiles.Buster.Xenomite;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Weapons.Magic
{
    public class XenomiteBuster1 : ModItem
    {
        public float BasicShotController;
        public float Charge;
        public float AnimationTimer;
        public float ChargeShotCooldown;
        public float Lv3ShotTimer;
        public static readonly SoundStyle XenomiteWeapon_Lv1Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv2Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv3Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public static readonly SoundStyle Buster_Lv1_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv1_shoot");
        public static readonly SoundStyle Buster_Lv2_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv2_shoot");
        public static readonly SoundStyle Buster_Lv3_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv3_shoot");
        public static readonly SoundStyle Buster_Lv4_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv4_shoot");
        public static readonly SoundStyle Buster_basic_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_basic_hit");
        public static readonly SoundStyle Buster_boss_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_boss_hit");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Buster");
            Tooltip.SetDefault("Fires Xenomite energy bullets.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = Buster_Lv1_shoot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            position += AimDirection * 8f;
            if (player.channel && BasicShotController <= 1f)
            {
                return true;
            }
            return false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 30f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv2_Proj>();
                damage = Item.damage * 2;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv3_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 4)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv4_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (ChargeShotCooldown > 0f)
            {
                ChargeShotCooldown -= 1f;
            }
            if (player.channel)
            {
                if (BasicShotController < 2f)
                {
                    BasicShotController += 1f;
                }
                if (BasicShotController == 1f)
                {
                    AnimationTimer = 20f;
                }
                if (Charge < 181f && ChargeShotCooldown <= 0f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv1Charge, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv2Charge, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv3Charge, player.position);
                    }
                }
                int variable_A = Main.rand.Next(0, 50);
                int variable_B = Main.rand.Next(0, 50);
                int variable_C = Main.rand.Next(0, 50);
                int variable_D = Main.rand.Next(0, 50);

                if (Charge >= 30f && Charge < 90f)//charge level dust
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A))/10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 1.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 1.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 1.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 1.5f;
                    }
                }
                else if (Charge >= 90f && Charge < 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2f;
                    }
                }
                else if (Charge >= 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2.5f;
                    }
                }
            }
            if (!player.channel)
            {
                if (BasicShotController > 0f)
                {
                    BasicShotController = 0f;
                }
                if (Charge > 0f)
                {
                    if (Charge >= 30f)
                    {
                        if (AimDirection.X > 0f)
                        {
                            player.direction = 1;
                        }
                        else if (AimDirection.X < 0f)
                        {
                            player.direction = -1;
                        }
                        if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
                        {
                            player.statMana -= Item.mana * 2;
                            SoundEngine.PlaySound(Buster_Lv2_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv2_Proj").Type, Item.damage * 2, 4, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 30f;
                        }
                        if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
                        {
                            player.statMana -= Item.mana * 3;
                            SoundEngine.PlaySound(Buster_Lv3_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv3_Proj").Type, Item.damage * 3, 6, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 20f;
                        }
                        if (Charge >= 180f && player.statMana >= Item.mana * 4)
                        {
                            player.statMana -= Item.mana * 4;
                            SoundEngine.PlaySound(Buster_Lv4_shoot, player.position);
                            ChargeShotCooldown = 20f;
                            Lv3ShotTimer = 10f;
                        }
                        AnimationTimer = 20f;
                    }
                    Charge = 0f;
                }
            }
            if (AnimationTimer > 0f)
            {
                AnimationTimer -= 1f;
            }
            if (Lv3ShotTimer > 0f)
            {
                Lv3ShotTimer -= 1f;
            }
            if (Lv3ShotTimer == 9f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 6f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 3f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
        }
        public override void HoldItemFrame(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (AnimationTimer > 0f)
            {
                if (AimDirection.X > -0.7315 && AimDirection.X < 0.7315 && AimDirection.Y < 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 2;
                }
                else if (AimDirection.X > -0.8255 && AimDirection.X < 0.8255 && AimDirection.Y > 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 4;
                }
                else
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 3;
                }
            }
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("XenomiteShard", out var modItemName))
                {
                    CreateRecipe()
                        .AddIngredient(modItemName.Type, 10)
                        .AddIngredient(ItemID.MeteoriteBar, 7)
                        .AddTile(TileID.Anvils)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ItemID.MeteoriteBar, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddTile(TileID.Anvils)
                    .Register();
            }
        }
    }
    public class XenomiteBuster2 : ModItem
    {
        public float BasicShotController;
        public float Charge;
        public float AnimationTimer;
        public float ChargeShotCooldown;
        public float Lv3ShotTimer;
        public static readonly SoundStyle XenomiteWeapon_Lv1Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv2Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv3Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public static readonly SoundStyle Buster_Lv1_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv1_shoot");
        public static readonly SoundStyle Buster_Lv2_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv2_shoot");
        public static readonly SoundStyle Buster_Lv3_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv3_shoot");
        public static readonly SoundStyle Buster_Lv4_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv4_shoot");
        public static readonly SoundStyle Buster_basic_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_basic_hit");
        public static readonly SoundStyle Buster_boss_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_boss_hit");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Buster");
            Tooltip.SetDefault("Fires Xenomite energy bullets.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = Buster_Lv1_shoot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            position += AimDirection * 8f;
            if (player.channel && BasicShotController <= 1f)
            {
                return true;
            }
            return false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 30f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv2_Proj>();
                damage = Item.damage * 2;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv3_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 4)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv4_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (ChargeShotCooldown > 0f)
            {
                ChargeShotCooldown -= 1f;
            }
            if (player.channel)
            {
                if (BasicShotController < 2f)
                {
                    BasicShotController += 1f;
                }
                if (BasicShotController == 1f)
                {
                    AnimationTimer = 20f;
                }
                if (Charge < 181f && ChargeShotCooldown <= 0f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv1Charge, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv2Charge, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv3Charge, player.position);
                    }
                }
                int variable_A = Main.rand.Next(0, 50);
                int variable_B = Main.rand.Next(0, 50);
                int variable_C = Main.rand.Next(0, 50);
                int variable_D = Main.rand.Next(0, 50);

                if (Charge >= 30f && Charge < 90f)//charge level dust
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A))/10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 1.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 1.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 1.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 1.5f;
                    }
                }
                else if (Charge >= 90f && Charge < 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2f;
                    }
                }
                else if (Charge >= 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2.5f;
                    }
                }
            }
            if (!player.channel)
            {
                if (BasicShotController > 0f)
                {
                    BasicShotController = 0f;
                }
                if (Charge > 0f)
                {
                    if (Charge >= 30f)
                    {
                        if (AimDirection.X > 0f)
                        {
                            player.direction = 1;
                        }
                        else if (AimDirection.X < 0f)
                        {
                            player.direction = -1;
                        }
                        if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
                        {
                            player.statMana -= Item.mana * 2;
                            SoundEngine.PlaySound(Buster_Lv2_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv2_Proj").Type, Item.damage * 2, 4, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 30f;
                        }
                        if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
                        {
                            player.statMana -= Item.mana * 3;
                            SoundEngine.PlaySound(Buster_Lv3_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv3_Proj").Type, Item.damage * 3, 6, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 20f;
                        }
                        if (Charge >= 180f && player.statMana >= Item.mana * 4)
                        {
                            player.statMana -= Item.mana * 4;
                            SoundEngine.PlaySound(Buster_Lv4_shoot, player.position);
                            ChargeShotCooldown = 20f;
                            Lv3ShotTimer = 10f;
                        }
                        AnimationTimer = 20f;
                    }
                    Charge = 0f;
                }
            }
            if (AnimationTimer > 0f)
            {
                AnimationTimer -= 1f;
            }
            if (Lv3ShotTimer > 0f)
            {
                Lv3ShotTimer -= 1f;
            }
            if (Lv3ShotTimer == 9f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 6f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 3f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
        }
        public override void HoldItemFrame(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (AnimationTimer > 0f)
            {
                if (AimDirection.X > -0.7315 && AimDirection.X < 0.7315 && AimDirection.Y < 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 2;
                }
                else if (AimDirection.X > -0.8255 && AimDirection.X < 0.8255 && AimDirection.Y > 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 4;
                }
                else
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 3;
                }
            }
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("XenomiteShard", out var modItemName))
                {
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<XenomiteBuster1>())
                        .AddIngredient(modItemName.Type, 10)
                        .AddIngredient(ItemID.HellstoneBar, 5)
                        .AddTile(TileID.MythrilAnvil)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<XenomiteBuster1>())
                    .AddIngredient(ItemID.MeteoriteBar, 5)
                    .AddIngredient(ItemID.HellstoneBar, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
    public class XenomiteBuster3 : ModItem
    {
        public float BasicShotController;
        public float Charge;
        public float AnimationTimer;
        public float ChargeShotCooldown;
        public float Lv3ShotTimer;
        public static readonly SoundStyle XenomiteWeapon_Lv1Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv2Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv3Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public static readonly SoundStyle Buster_Lv1_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv1_shoot");
        public static readonly SoundStyle Buster_Lv2_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv2_shoot");
        public static readonly SoundStyle Buster_Lv3_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv3_shoot");
        public static readonly SoundStyle Buster_Lv4_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv4_shoot");
        public static readonly SoundStyle Buster_basic_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_basic_hit");
        public static readonly SoundStyle Buster_boss_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_boss_hit");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Buster");
            Tooltip.SetDefault("Fires Xenomite energy bullets.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = Buster_Lv1_shoot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            position += AimDirection * 8f;
            if (player.channel && BasicShotController <= 1f)
            {
                return true;
            }
            return false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 30f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv2_Proj>();
                damage = Item.damage * 2;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv3_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 4)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv4_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (ChargeShotCooldown > 0f)
            {
                ChargeShotCooldown -= 1f;
            }
            if (player.channel)
            {
                if (BasicShotController < 2f)
                {
                    BasicShotController += 1f;
                }
                if (BasicShotController == 1f)
                {
                    AnimationTimer = 20f;
                }
                if (Charge < 181f && ChargeShotCooldown <= 0f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv1Charge, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv2Charge, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv3Charge, player.position);
                    }
                }
                int variable_A = Main.rand.Next(0, 50);
                int variable_B = Main.rand.Next(0, 50);
                int variable_C = Main.rand.Next(0, 50);
                int variable_D = Main.rand.Next(0, 50);

                if (Charge >= 30f && Charge < 90f)//charge level dust
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A))/10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 1.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 1.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 1.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 1.5f;
                    }
                }
                else if (Charge >= 90f && Charge < 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2f;
                    }
                }
                else if (Charge >= 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2.5f;
                    }
                }
            }
            if (!player.channel)
            {
                if (BasicShotController > 0f)
                {
                    BasicShotController = 0f;
                }
                if (Charge > 0f)
                {
                    if (Charge >= 30f)
                    {
                        if (AimDirection.X > 0f)
                        {
                            player.direction = 1;
                        }
                        else if (AimDirection.X < 0f)
                        {
                            player.direction = -1;
                        }
                        if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
                        {
                            player.statMana -= Item.mana * 2;
                            SoundEngine.PlaySound(Buster_Lv2_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv2_Proj").Type, Item.damage * 2, 4, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 30f;
                        }
                        if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
                        {
                            player.statMana -= Item.mana * 3;
                            SoundEngine.PlaySound(Buster_Lv3_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv3_Proj").Type, Item.damage * 3, 6, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 20f;
                        }
                        if (Charge >= 180f && player.statMana >= Item.mana * 4)
                        {
                            player.statMana -= Item.mana * 4;
                            SoundEngine.PlaySound(Buster_Lv4_shoot, player.position);
                            ChargeShotCooldown = 20f;
                            Lv3ShotTimer = 10f;
                        }
                        AnimationTimer = 20f;
                    }
                    Charge = 0f;
                }
            }
            if (AnimationTimer > 0f)
            {
                AnimationTimer -= 1f;
            }
            if (Lv3ShotTimer > 0f)
            {
                Lv3ShotTimer -= 1f;
            }
            if (Lv3ShotTimer == 9f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 6f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 3f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
        }
        public override void HoldItemFrame(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (AnimationTimer > 0f)
            {
                if (AimDirection.X > -0.7315 && AimDirection.X < 0.7315 && AimDirection.Y < 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 2;
                }
                else if (AimDirection.X > -0.8255 && AimDirection.X < 0.8255 && AimDirection.Y > 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 4;
                }
                else
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 3;
                }
            }
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("XenomiteItem", out var modItemName))
                {
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<XenomiteBuster2>())
                        .AddIngredient(modItemName.Type, 5)
                        .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", 5)
                        .AddIngredient(ItemID.SoulofFright, 5)
                        .AddIngredient(ItemID.SoulofMight, 5)
                        .AddIngredient(ItemID.SoulofSight, 5)
                        .AddTile(TileID.MythrilAnvil)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<XenomiteBuster2>())
                    .AddIngredient(ItemID.MeteoriteBar, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", 5)
                    .AddIngredient(ItemID.SoulofFright, 5)
                    .AddIngredient(ItemID.SoulofMight, 5)
                    .AddIngredient(ItemID.SoulofSight, 5)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
    public class XenomiteBuster4 : ModItem
    {
        public float BasicShotController;
        public float Charge;
        public float AnimationTimer;
        public float ChargeShotCooldown;
        public float Lv3ShotTimer;
        public static readonly SoundStyle XenomiteWeapon_Lv1Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv2Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv3Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public static readonly SoundStyle Buster_Lv1_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv1_shoot");
        public static readonly SoundStyle Buster_Lv2_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv2_shoot");
        public static readonly SoundStyle Buster_Lv3_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv3_shoot");
        public static readonly SoundStyle Buster_Lv4_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv4_shoot");
        public static readonly SoundStyle Buster_basic_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_basic_hit");
        public static readonly SoundStyle Buster_boss_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_boss_hit");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Buster");
            Tooltip.SetDefault("Fires Xenomite energy bullets.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 160;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.UseSound = Buster_Lv1_shoot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            position += AimDirection * 8f;
            if (player.channel && BasicShotController <= 1f)
            {
                return true;
            }
            return false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 30f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv2_Proj>();
                damage = Item.damage * 2;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv3_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 4)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv4_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (ChargeShotCooldown > 0f)
            {
                ChargeShotCooldown -= 1f;
            }
            if (player.channel)
            {
                if (BasicShotController < 2f)
                {
                    BasicShotController += 1f;
                }
                if (BasicShotController == 1f)
                {
                    AnimationTimer = 20f;
                }
                if (Charge < 181f && ChargeShotCooldown <= 0f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv1Charge, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv2Charge, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv3Charge, player.position);
                    }
                }
                int variable_A = Main.rand.Next(0, 50);
                int variable_B = Main.rand.Next(0, 50);
                int variable_C = Main.rand.Next(0, 50);
                int variable_D = Main.rand.Next(0, 50);

                if (Charge >= 30f && Charge < 90f)//charge level dust
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A))/10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 1.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 1.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 1.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 1.5f;
                    }
                }
                else if (Charge >= 90f && Charge < 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2f;
                    }
                }
                else if (Charge >= 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2.5f;
                    }
                }
            }
            if (!player.channel)
            {
                if (BasicShotController > 0f)
                {
                    BasicShotController = 0f;
                }
                if (Charge > 0f)
                {
                    if (Charge >= 30f)
                    {
                        if (AimDirection.X > 0f)
                        {
                            player.direction = 1;
                        }
                        else if (AimDirection.X < 0f)
                        {
                            player.direction = -1;
                        }
                        if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
                        {
                            player.statMana -= Item.mana * 2;
                            SoundEngine.PlaySound(Buster_Lv2_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv2_Proj").Type, Item.damage * 2, 4, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 30f;
                        }
                        if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
                        {
                            player.statMana -= Item.mana * 3;
                            SoundEngine.PlaySound(Buster_Lv3_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv3_Proj").Type, Item.damage * 3, 6, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 20f;
                        }
                        if (Charge >= 180f && player.statMana >= Item.mana * 4)
                        {
                            player.statMana -= Item.mana * 4;
                            SoundEngine.PlaySound(Buster_Lv4_shoot, player.position);
                            ChargeShotCooldown = 20f;
                            Lv3ShotTimer = 10f;
                        }
                        AnimationTimer = 20f;
                    }
                    Charge = 0f;
                }
            }
            if (AnimationTimer > 0f)
            {
                AnimationTimer -= 1f;
            }
            if (Lv3ShotTimer > 0f)
            {
                Lv3ShotTimer -= 1f;
            }
            if (Lv3ShotTimer == 9f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 6f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 3f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
        }
        public override void HoldItemFrame(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (AnimationTimer > 0f)
            {
                if (AimDirection.X > -0.7315 && AimDirection.X < 0.7315 && AimDirection.Y < 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 2;
                }
                else if (AimDirection.X > -0.8255 && AimDirection.X < 0.8255 && AimDirection.Y > 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 4;
                }
                else
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 3;
                }
            }
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("XenomiteItem", out var modItemName) && otherMod.TryFind<ModItem>("Bioweapon", out var modItemName2) && otherMod.TryFind<ModItem>("ToxicBile", out var modItemName3))
                {
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<XenomiteBuster3>())
                        .AddIngredient(modItemName.Type, 5)
                        .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", 5)
                        .AddRecipeGroup("Redemption:BioweaponBile", 30)
                        .AddTile(TileID.MythrilAnvil)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<XenomiteBuster3>())
                    .AddIngredient(ItemID.MeteoriteBar, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", 5)
                    .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Cursed Flame or Ichor", 30)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }
    public class XenomiteBuster5 : ModItem
    {
        public float BasicShotController;
        public float Charge;
        public float AnimationTimer;
        public float ChargeShotCooldown;
        public float Lv3ShotTimer;
        public static readonly SoundStyle XenomiteWeapon_Lv1Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv2Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv3Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public static readonly SoundStyle Buster_Lv1_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv1_shoot");
        public static readonly SoundStyle Buster_Lv2_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv2_shoot");
        public static readonly SoundStyle Buster_Lv3_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv3_shoot");
        public static readonly SoundStyle Buster_Lv4_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv4_shoot");
        public static readonly SoundStyle Buster_basic_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_basic_hit");
        public static readonly SoundStyle Buster_boss_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_boss_hit");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Buster");
            Tooltip.SetDefault("Fires Xenomite energy bullets.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 320;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 16, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = Buster_Lv1_shoot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            position += AimDirection * 8f;
            if (player.channel && BasicShotController <= 1f)
            {
                return true;
            }
            return false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 30f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv2_Proj>();
                damage = Item.damage * 2;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv3_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 4)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv4_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (ChargeShotCooldown > 0f)
            {
                ChargeShotCooldown -= 1f;
            }
            if (player.channel)
            {
                if (BasicShotController < 2f)
                {
                    BasicShotController += 1f;
                }
                if (BasicShotController == 1f)
                {
                    AnimationTimer = 20f;
                }
                if (Charge < 181f && ChargeShotCooldown <= 0f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv1Charge, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv2Charge, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv3Charge, player.position);
                    }
                }
                int variable_A = Main.rand.Next(0, 50);
                int variable_B = Main.rand.Next(0, 50);
                int variable_C = Main.rand.Next(0, 50);
                int variable_D = Main.rand.Next(0, 50);

                if (Charge >= 30f && Charge < 90f)//charge level dust
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A))/10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 1.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 1.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 1.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 1.5f;
                    }
                }
                else if (Charge >= 90f && Charge < 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2f;
                    }
                }
                else if (Charge >= 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2.5f;
                    }
                }
            }
            if (!player.channel)
            {
                if (BasicShotController > 0f)
                {
                    BasicShotController = 0f;
                }
                if (Charge > 0f)
                {
                    if (Charge >= 30f)
                    {
                        if (AimDirection.X > 0f)
                        {
                            player.direction = 1;
                        }
                        else if (AimDirection.X < 0f)
                        {
                            player.direction = -1;
                        }
                        if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
                        {
                            player.statMana -= Item.mana * 2;
                            SoundEngine.PlaySound(Buster_Lv2_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv2_Proj").Type, Item.damage * 2, 4, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 30f;
                        }
                        if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
                        {
                            player.statMana -= Item.mana * 3;
                            SoundEngine.PlaySound(Buster_Lv3_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv3_Proj").Type, Item.damage * 3, 6, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 20f;
                        }
                        if (Charge >= 180f && player.statMana >= Item.mana * 4)
                        {
                            player.statMana -= Item.mana * 4;
                            SoundEngine.PlaySound(Buster_Lv4_shoot, player.position);
                            ChargeShotCooldown = 20f;
                            Lv3ShotTimer = 10f;
                        }
                        AnimationTimer = 20f;
                    }
                    Charge = 0f;
                }
            }
            if (AnimationTimer > 0f)
            {
                AnimationTimer -= 1f;
            }
            if (Lv3ShotTimer > 0f)
            {
                Lv3ShotTimer -= 1f;
            }
            if (Lv3ShotTimer == 9f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 6f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 3f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
        }
        public override void HoldItemFrame(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (AnimationTimer > 0f)
            {
                if (AimDirection.X > -0.7315 && AimDirection.X < 0.7315 && AimDirection.Y < 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 2;
                }
                else if (AimDirection.X > -0.8255 && AimDirection.X < 0.8255 && AimDirection.Y > 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 4;
                }
                else
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 3;
                }
            }
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("XenomiteItem", out var modItemName))
                {
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<XenomiteBuster4>())
                        .AddIngredient(modItemName.Type, 5)
                        .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", 5)
                        .AddIngredient(ItemID.FragmentNebula, 5)
                        .AddIngredient(ItemID.FragmentSolar, 5)
                        .AddIngredient(ItemID.FragmentStardust, 5)
                        .AddIngredient(ItemID.FragmentVortex, 5)
                        .AddTile(TileID.LunarCraftingStation)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<XenomiteBuster4>())
                    .AddIngredient(ItemID.MeteoriteBar, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", 5)
                    .AddIngredient(ItemID.FragmentNebula, 5)
                    .AddIngredient(ItemID.FragmentSolar, 5)
                    .AddIngredient(ItemID.FragmentStardust, 5)
                    .AddIngredient(ItemID.FragmentVortex, 5)
                    .AddTile(TileID.LunarCraftingStation)
                    .Register();
            }
        }
    }
    public class XenomiteBuster6 : ModItem
    {
        public float BasicShotController;
        public float Charge;
        public float AnimationTimer;
        public float ChargeShotCooldown;
        public float Lv3ShotTimer;
        public static readonly SoundStyle XenomiteWeapon_Lv1Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv2Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle XenomiteWeapon_Lv3Charge = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public static readonly SoundStyle Buster_Lv1_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv1_shoot");
        public static readonly SoundStyle Buster_Lv2_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv2_shoot");
        public static readonly SoundStyle Buster_Lv3_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv3_shoot");
        public static readonly SoundStyle Buster_Lv4_shoot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_Lv4_shoot");
        public static readonly SoundStyle Buster_basic_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_basic_hit");
        public static readonly SoundStyle Buster_boss_hit = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/Buster/Buster_boss_hit");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Buster");
            Tooltip.SetDefault("Fires Xenomite energy bullets.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 640;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 32, 0, 0);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = Buster_Lv1_shoot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            position += AimDirection * 8f;
            if (player.channel && BasicShotController <= 1f)
            {
                return true;
            }
            return false;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 30f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv1_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv2_Proj>();
                damage = Item.damage * 2;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv3_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 4)
            {
                type = ModContent.ProjectileType<XenomiteBusterLv4_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (ChargeShotCooldown > 0f)
            {
                ChargeShotCooldown -= 1f;
            }
            if (player.channel)
            {
                if (BasicShotController < 2f)
                {
                    BasicShotController += 1f;
                }
                if (BasicShotController == 1f)
                {
                    AnimationTimer = 20f;
                }
                if (Charge < 181f && ChargeShotCooldown <= 0f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv1Charge, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv2Charge, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(XenomiteWeapon_Lv3Charge, player.position);
                    }
                }
                int variable_A = Main.rand.Next(0, 50);
                int variable_B = Main.rand.Next(0, 50);
                int variable_C = Main.rand.Next(0, 50);
                int variable_D = Main.rand.Next(0, 50);

                if (Charge >= 30f && Charge < 90f)//charge level dust
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A))/10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 1.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 1.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 1.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(0, 98, 93);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 1.5f;
                    }
                }
                else if (Charge >= 90f && Charge < 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(43, 194, 48);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2f;
                    }
                }
                else if (Charge >= 180f)
                {
                    int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                    Main.dust[a].noGravity = true;
                    Main.dust[a].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[a].scale *= 2.5f;
                    }

                    int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                    Main.dust[b].noGravity = true;
                    Main.dust[b].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[b].scale *= 2.5f;
                    }

                    int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                    Main.dust[c].noGravity = true;
                    Main.dust[c].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[c].scale *= 2.5f;
                    }

                    int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                    Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                    Main.dust[d].noGravity = true;
                    Main.dust[d].color = new Color(185, 242, 84);
                    if (Main.rand.NextBool(2))
                    {
                        Main.dust[d].scale *= 2.5f;
                    }
                }
            }
            if (!player.channel)
            {
                if (BasicShotController > 0f)
                {
                    BasicShotController = 0f;
                }
                if (Charge > 0f)
                {
                    if (Charge >= 30f)
                    {
                        if (AimDirection.X > 0f)
                        {
                            player.direction = 1;
                        }
                        else if (AimDirection.X < 0f)
                        {
                            player.direction = -1;
                        }
                        if (Charge >= 30f && Charge < 90f && player.statMana >= Item.mana * 2)
                        {
                            player.statMana -= Item.mana * 2;
                            SoundEngine.PlaySound(Buster_Lv2_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv2_Proj").Type, Item.damage * 2, 4, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 30f;
                        }
                        if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 3)
                        {
                            player.statMana -= Item.mana * 3;
                            SoundEngine.PlaySound(Buster_Lv3_shoot, player.position);
                            int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv3_Proj").Type, Item.damage * 3, 6, Main.myPlayer);
                            Main.projectile[a].spriteDirection = player.direction;
                            Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                            ChargeShotCooldown = 20f;
                        }
                        if (Charge >= 180f && player.statMana >= Item.mana * 4)
                        {
                            player.statMana -= Item.mana * 4;
                            SoundEngine.PlaySound(Buster_Lv4_shoot, player.position);
                            ChargeShotCooldown = 20f;
                            Lv3ShotTimer = 10f;
                        }
                        AnimationTimer = 20f;
                    }
                    Charge = 0f;
                }
            }
            if (AnimationTimer > 0f)
            {
                AnimationTimer -= 1f;
            }
            if (Lv3ShotTimer > 0f)
            {
                Lv3ShotTimer -= 1f;
            }
            if (Lv3ShotTimer == 9f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 6f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
            if (Lv3ShotTimer == 3f)
            {
                int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center + AimDirection * 8f, new Vector2(AimDirection.X * Item.shootSpeed, AimDirection.Y * Item.shootSpeed * player.gravDir), Mod.Find<ModProjectile>("XenomiteBusterLv4_Proj").Type, Item.damage * 3, 7, Main.myPlayer);
                Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
            }
        }
        public override void HoldItemFrame(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (AnimationTimer > 0f)
            {
                if (AimDirection.X > -0.7315 && AimDirection.X < 0.7315 && AimDirection.Y < 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 2;
                }
                else if (AimDirection.X > -0.8255 && AimDirection.X < 0.8255 && AimDirection.Y > 0f)
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 4;
                }
                else
                {
                    player.bodyFrame.Y = player.bodyFrame.Height * 3;
                }
            }
        }
        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("Redemption", out var otherMod))
            {
                if (otherMod.TryFind<ModItem>("XenomiteItem", out var modItemName) && otherMod.TryFind<ModItem>("PZTrophy", out var modItemName2))
                {
                    CreateRecipe()
                        .AddIngredient(ModContent.ItemType<XenomiteBuster5>())
                        .AddIngredient(modItemName.Type, 5)
                        .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", 5)
                        .AddIngredient(modItemName2.Type)
                        .AddTile(TileID.LunarCraftingStation)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<XenomiteBuster5>())
                    .AddIngredient(ItemID.MeteoriteBar, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", 5)
                    .AddIngredient(ItemID.BossTrophyBetsy)
                    .AddIngredient(ItemID.PumpkingTrophy)
                    .AddIngredient(ItemID.SantaNK1Trophy)
                    .AddIngredient(ItemID.FlyingDutchmanTrophy)
                    .AddIngredient(ItemID.MartianSaucerTrophy)
                    .AddTile(TileID.LunarCraftingStation)
                    .Register();
            }
        }
    }
}