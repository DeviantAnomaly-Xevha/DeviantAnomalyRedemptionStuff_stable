using DeviantAnomalyRedemptionStuff_stable.Content.Projectiles.XenomiteCrystalBomb;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff_stable.Content.Items.Weapons.Magic
{
    public class XenomiteCrystalBomb1 : ModItem
    {
        public float Charge;
        public static readonly SoundStyle CrystalBomb_shot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalBomb_shot");
        public static readonly SoundStyle CrystalBomb_ChargeLv1 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv2 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv3 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
            Tooltip.SetDefault("Launch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\nPillars can reflect enemy projectiles.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 15));
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = CrystalBomb_shot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Charge = 0f;
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 90f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (player.channel)
            {
                if (Charge < 181f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv1, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv2, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv3, player.position);
                    }
                }
            }
            if (player.channel)
            {
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
            if (!player.channel && Charge > 30f)
            {
                if (player.statMana < Item.mana)
                {
                    Charge = 0f;
                }
                else if (player.statMana >= Item.mana)
                {
                    SoundEngine.PlaySound(CrystalBomb_shot, player.position);
                    player.itemAnimation = player.itemAnimationMax;
                    player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y - player.Center.Y) * player.direction), ((Main.mouseX + Main.screenPosition.X - player.Center.X) * player.direction));
                    if (Charge >= 30f && Charge < 90 && player.statMana >= Item.mana)
                    {
                        player.statMana -= Item.mana;
                    }
                    if (Charge >= 90f && Charge < 180 && player.statMana >= Item.mana * 2)
                    {
                        player.statMana -= Item.mana * 2;
                    }
                    if (Charge >= 180f && player.statMana >= Item.mana * 3)
                    {
                        player.statMana -= Item.mana * 3;
                        int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center, new Vector2((AimDirection.X * Item.shootSpeed) * .625f, (AimDirection.Y - 11f) * player.gravDir), Mod.Find<ModProjectile>("XenomiteCrystalBombCharged_Proj").Type, Item.damage * 3, 0, Main.myPlayer);
                        Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                    }
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

    public class XenomiteCrystalBomb2 : ModItem
    {
        public float Charge;
        public static readonly SoundStyle CrystalBomb_shot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalBomb_shot");
        public static readonly SoundStyle CrystalBomb_ChargeLv1 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv2 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv3 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
            Tooltip.SetDefault("Launch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\nPillars can reflect enemy projectiles.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 15));
        }
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = CrystalBomb_shot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Charge = 0f;
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 90f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (player.channel)
            {
                if (Charge < 181f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv1, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv2, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv3, player.position);
                    }
                }
            }
            if (player.channel)
            {
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
            if (!player.channel && Charge > 30f)
            {
                if (player.statMana < Item.mana)
                {
                    Charge = 0f;
                }
                else if (player.statMana >= Item.mana)
                {
                    SoundEngine.PlaySound(CrystalBomb_shot, player.position);
                    player.itemAnimation = player.itemAnimationMax;
                    player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y - player.Center.Y) * player.direction), ((Main.mouseX + Main.screenPosition.X - player.Center.X) * player.direction));
                    if (Charge >= 30f && Charge < 90 && player.statMana >= Item.mana)
                    {
                        player.statMana -= Item.mana;
                    }
                    if (Charge >= 90f && Charge < 180 && player.statMana >= Item.mana * 2)
                    {
                        player.statMana -= Item.mana * 2;
                    }
                    if (Charge >= 180f && player.statMana >= Item.mana * 3)
                    {
                        player.statMana -= Item.mana * 3;
                        int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center, new Vector2((AimDirection.X * Item.shootSpeed) * .625f, (AimDirection.Y - 11f) * player.gravDir), Mod.Find<ModProjectile>("XenomiteCrystalBombCharged_Proj").Type, Item.damage * 3, 0, Main.myPlayer);
                        Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                    }
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
                        .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb1>())
                        .AddIngredient(modItemName.Type, 5)
                        .AddIngredient(ItemID.HellstoneBar, 5)
                        .AddTile(TileID.MythrilAnvil)
                        .Register();
                }
            }
            else
            {
                CreateRecipe()
                    .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb1>())
                    .AddIngredient(ItemID.MeteoriteBar, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddIngredient(ItemID.HellstoneBar, 5)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }

    public class XenomiteCrystalBomb3 : ModItem
    {
        public float Charge;
        public static readonly SoundStyle CrystalBomb_shot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalBomb_shot");
        public static readonly SoundStyle CrystalBomb_ChargeLv1 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv2 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv3 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
            Tooltip.SetDefault("Launch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\nPillars can reflect enemy projectiles.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 15));
        }
        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = CrystalBomb_shot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Charge = 0f;
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 90f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (player.channel)
            {
                if (Charge < 181f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv1, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv2, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv3, player.position);
                    }
                }
            }
            if (player.channel)
            {
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
            if (!player.channel && Charge > 30f)
            {
                if (player.statMana < Item.mana)
                {
                    Charge = 0f;
                }
                else if (player.statMana >= Item.mana)
                {
                    SoundEngine.PlaySound(CrystalBomb_shot, player.position);
                    player.itemAnimation = player.itemAnimationMax;
                    player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y - player.Center.Y) * player.direction), ((Main.mouseX + Main.screenPosition.X - player.Center.X) * player.direction));
                    if (Charge >= 30f && Charge < 90 && player.statMana >= Item.mana)
                    {
                        player.statMana -= Item.mana;
                    }
                    if (Charge >= 90f && Charge < 180 && player.statMana >= Item.mana * 2)
                    {
                        player.statMana -= Item.mana * 2;
                    }
                    if (Charge >= 180f && player.statMana >= Item.mana * 3)
                    {
                        player.statMana -= Item.mana * 3;
                        int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center, new Vector2((AimDirection.X * Item.shootSpeed) * .625f, (AimDirection.Y - 11f) * player.gravDir), Mod.Find<ModProjectile>("XenomiteCrystalBombCharged_Proj").Type, Item.damage * 3, 0, Main.myPlayer);
                        Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                    }
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
                        .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb2>())
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
                    .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb2>())
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

    public class XenomiteCrystalBomb4 : ModItem
    {
        public float Charge;
        public static readonly SoundStyle CrystalBomb_shot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalBomb_shot");
        public static readonly SoundStyle CrystalBomb_ChargeLv1 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv2 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv3 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
            Tooltip.SetDefault("Launch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\nPillars can reflect enemy projectiles.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 15));
        }
        public override void SetDefaults()
        {
            Item.damage = 160;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.UseSound = CrystalBomb_shot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Charge = 0f;
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 90f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (player.channel)
            {
                if (Charge < 181f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv1, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv2, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv3, player.position);
                    }
                }
            }
            if (player.channel)
            {
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
            if (!player.channel && Charge > 30f)
            {
                if (player.statMana < Item.mana)
                {
                    Charge = 0f;
                }
                else if (player.statMana >= Item.mana)
                {
                    SoundEngine.PlaySound(CrystalBomb_shot, player.position);
                    player.itemAnimation = player.itemAnimationMax;
                    player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y - player.Center.Y) * player.direction), ((Main.mouseX + Main.screenPosition.X - player.Center.X) * player.direction));
                    if (Charge >= 30f && Charge < 90 && player.statMana >= Item.mana)
                    {
                        player.statMana -= Item.mana;
                    }
                    if (Charge >= 90f && Charge < 180 && player.statMana >= Item.mana * 2)
                    {
                        player.statMana -= Item.mana * 2;
                    }
                    if (Charge >= 180f && player.statMana >= Item.mana * 3)
                    {
                        player.statMana -= Item.mana * 3;
                        int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center, new Vector2((AimDirection.X * Item.shootSpeed) * .625f, (AimDirection.Y - 11f) * player.gravDir), Mod.Find<ModProjectile>("XenomiteCrystalBombCharged_Proj").Type, Item.damage * 3, 0, Main.myPlayer);
                        Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                    }
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
                        .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb3>())
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
                    .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb3>())
                    .AddIngredient(ItemID.MeteoriteBar, 5)
                    .AddIngredient(ItemID.BrightGreenDye, 1)
                    .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Adamantite or Titanium Bar", 5)
                    .AddRecipeGroup("DeviantAnomalyRedemptionStuff:Cursed Flame or Ichor", 30)
                    .AddTile(TileID.MythrilAnvil)
                    .Register();
            }
        }
    }

    public class XenomiteCrystalBomb5 : ModItem
    {
        public float Charge;
        public static readonly SoundStyle CrystalBomb_shot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalBomb_shot");
        public static readonly SoundStyle CrystalBomb_ChargeLv1 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv2 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv3 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
            Tooltip.SetDefault("Launch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\nPillars can reflect enemy projectiles.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 15));
        }
        public override void SetDefaults()
        {
            Item.damage = 320;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 16, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = CrystalBomb_shot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Charge = 0f;
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 90f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (player.channel)
            {
                if (Charge < 181f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv1, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv2, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv3, player.position);
                    }
                }
            }
            if (player.channel)
            {
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
            if (!player.channel && Charge > 30f)
            {
                if (player.statMana < Item.mana)
                {
                    Charge = 0f;
                }
                else if (player.statMana >= Item.mana)
                {
                    SoundEngine.PlaySound(CrystalBomb_shot, player.position);
                    player.itemAnimation = player.itemAnimationMax;
                    player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y - player.Center.Y) * player.direction), ((Main.mouseX + Main.screenPosition.X - player.Center.X) * player.direction));
                    if (Charge >= 30f && Charge < 90 && player.statMana >= Item.mana)
                    {
                        player.statMana -= Item.mana;
                    }
                    if (Charge >= 90f && Charge < 180 && player.statMana >= Item.mana * 2)
                    {
                        player.statMana -= Item.mana * 2;
                    }
                    if (Charge >= 180f && player.statMana >= Item.mana * 3)
                    {
                        player.statMana -= Item.mana * 3;
                        int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center, new Vector2((AimDirection.X * Item.shootSpeed) * .625f, (AimDirection.Y - 11f) * player.gravDir), Mod.Find<ModProjectile>("XenomiteCrystalBombCharged_Proj").Type, Item.damage * 3, 0, Main.myPlayer);
                        Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                    }
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
                        .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb4>())
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
                    .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb4>())
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

    public class XenomiteCrystalBomb6 : ModItem
    {
        public float Charge;
        public static readonly SoundStyle CrystalBomb_shot = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/CrystalBomb/CrystalBomb_shot");
        public static readonly SoundStyle CrystalBomb_ChargeLv1 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv1Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv2 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv2Charge");
        public static readonly SoundStyle CrystalBomb_ChargeLv3 = new SoundStyle("DeviantAnomalyRedemptionStuff_stable/Sounds/XenomiteWeapon_Lv3Charge");
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
            Tooltip.SetDefault("Launch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\nPillars can reflect enemy projectiles.\n[c/64ff64:-Can be charged!-]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 15));
        }
        public override void SetDefaults()
        {
            Item.damage = 640;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;
            Item.mana = 5;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 32, 0, 0);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = CrystalBomb_shot;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
            Item.shootSpeed = 12f;
            Item.noUseGraphic = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Charge = 0f;
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Charge >= 1f && Charge < 90f && player.statMana >= Item.mana)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBomb_Proj>();
                damage = Item.damage;
            }
            if (Charge >= 90f && Charge < 180f && player.statMana >= Item.mana * 2)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
            if (Charge >= 180f && player.statMana >= Item.mana * 3)
            {
                type = ModContent.ProjectileType<XenomiteCrystalBombCharged_Proj>();
                damage = Item.damage * 3;
            }
        }
        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();
            if (player.channel)
            {
                if (Charge < 181f)
                {
                    Charge += 1f;
                    if (player.channel && Charge == 30f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv1, player.position);
                    }
                    if (player.channel && Charge == 90f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv2, player.position);
                    }
                    if (player.channel && Charge == 180f)
                    {
                        SoundEngine.PlaySound(CrystalBomb_ChargeLv3, player.position);
                    }
                }
            }
            if (player.channel)
            {
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
            if (!player.channel && Charge > 30f)
            {
                if (player.statMana < Item.mana)
                {
                    Charge = 0f;
                }
                else if (player.statMana >= Item.mana)
                {
                    SoundEngine.PlaySound(CrystalBomb_shot, player.position);
                    player.itemAnimation = player.itemAnimationMax;
                    player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y - player.Center.Y) * player.direction), ((Main.mouseX + Main.screenPosition.X - player.Center.X) * player.direction));
                    if (Charge >= 30f && Charge < 90 && player.statMana >= Item.mana)
                    {
                        player.statMana -= Item.mana;
                    }
                    if (Charge >= 90f && Charge < 180 && player.statMana >= Item.mana * 2)
                    {
                        player.statMana -= Item.mana * 2;
                    }
                    if (Charge >= 180f && player.statMana >= Item.mana * 3)
                    {
                        player.statMana -= Item.mana * 3;
                        int a = Projectile.NewProjectile(Projectile.InheritSource(player), player.Center, new Vector2((AimDirection.X * Item.shootSpeed) * .625f, (AimDirection.Y - 11f) * player.gravDir), Mod.Find<ModProjectile>("XenomiteCrystalBombCharged_Proj").Type, Item.damage * 3, 0, Main.myPlayer);
                        Main.projectile[a].CritChance = (int)player.GetTotalCritChance<MagicDamageClass>();
                    }
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
                        .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb5>())
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
                    .AddIngredient(ModContent.ItemType<XenomiteCrystalBomb5>())
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