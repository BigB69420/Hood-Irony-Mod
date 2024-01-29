using System;
using System.Collections.Generic;
using HoodIrony.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;

namespace HoodIrony.NPCs
{
    [AutoloadHead]
    public class Blud : ModNPC
    {
        public const string ShopName = "Shop";
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shlawg");
            NPC.Happiness
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Hate)
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Nurse, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Hate)
            ;
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 35;
            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 14;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 6;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.CopperShortsword)
                    {
                        return true;
                    }
                    if (item.type == ItemID.CopperPickaxe)
                    {
                        return true;
                    }
                    if (item.type == ItemID.Gel)
                    {
                        return true;
                    }
                    if (item.type == ItemID.Torch)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Blud"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = ShopName;
            }
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)

                .Add(new Item(ModContent.ItemType<Items.SkullEmoji>()) { shopCustomPrice = Item.buyPrice(gold: 10) })
                .Add(new Item(ModContent.ItemType<Items.GrimaceShake>()) { shopCustomPrice = Item.buyPrice(gold: 1) })
                .Add(new Item(ModContent.ItemType<Items.Weapons.Skullyoyo>()) { shopCustomPrice = Item.buyPrice(gold: 1) }, Condition.DownedMoonLord)
                .Add(new Item(ItemID.WallOfFleshGoatMountItem) { shopCustomPrice = Item.buyPrice(platinum: 1) }, Condition.Hardmode)
                .Add(new Item(ItemID.KingSlimeBossBag) { shopCustomPrice = Item.buyPrice(gold: 10) }, Condition.DownedKingSlime)
                .Add(new Item(ItemID.EyeOfCthulhuBossBag) { shopCustomPrice = Item.buyPrice(gold: 10) }, Condition.DownedEyeOfCthulhu)
                .Add(new Item(ItemID.EaterOfWorldsBossBag) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.BrainOfCthulhuBossBag) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.SkeletronBossBag) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.DeerclopsBossBag) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedDeerclops)
                .Add(new Item(ItemID.QueenBeeBossBag) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.WallOfFleshBossBag) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.Hardmode)
                .Add(new Item(ItemID.QueenSlimeBossBag) { shopCustomPrice = Item.buyPrice(gold: 35) }, Condition.DownedQueenSlime)
                .Add(new Item(ItemID.DestroyerBossBag) { shopCustomPrice = Item.buyPrice(gold: 40) }, Condition.DownedDestroyer)
                .Add(new Item(ItemID.TwinsBossBag) { shopCustomPrice = Item.buyPrice(gold: 40) }, Condition.DownedTwins)
                .Add(new Item(ItemID.SkeletronPrimeBossBag) { shopCustomPrice = Item.buyPrice(gold: 40) }, Condition.DownedSkeletronPrime)
                .Add(new Item(ItemID.FairyQueenBossBag) { shopCustomPrice = Item.buyPrice(gold: 85) }, Condition.DownedEmpressOfLight)
                .Add(new Item(ItemID.FishronBossBag) { shopCustomPrice = Item.buyPrice(gold: 85) }, Condition.DownedDukeFishron)
                .Add(new Item(ItemID.PlanteraBossBag) { shopCustomPrice = Item.buyPrice(gold: 70) }, Condition.DownedPlantera)
                .Add(new Item(ItemID.GolemBossBag) { shopCustomPrice = Item.buyPrice(gold: 85) }, Condition.DownedGolem)
                .Add(new Item(ItemID.FragmentSolar) { shopCustomPrice = Item.buyPrice(gold: 3) }, Condition.DownedSolarPillar)
                .Add(new Item(ItemID.FragmentNebula) { shopCustomPrice = Item.buyPrice(gold: 3) }, Condition.DownedNebulaPillar)
                .Add(new Item(ItemID.FragmentStardust) { shopCustomPrice = Item.buyPrice(gold: 3) }, Condition.DownedStardustPillar)
                .Add(new Item(ItemID.FragmentVortex) { shopCustomPrice = Item.buyPrice(gold: 3) }, Condition.DownedVortexPillar)
                .Add(new Item(ItemID.MoonLordBossBag) { shopCustomPrice = Item.buyPrice(gold: 100) }, Condition.DownedMoonLord);

            npcShop.Register();
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Blud>());
            switch (Main.rand.Next(5))
            {
                case 0:
                    return "Where is Blud walking?";
                case 1:
                    return "He was running from a cop car!";
                case 2:
                    return "Blud walked ... miles";
                case 3:
                    return "Blud really said...";
                case 4:
                    return "Chat is this real?";
                default:
                    return "Huh?";
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 15;
            knockback = 2f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 5;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.JestersArrow;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<Items.SkullEmoji>(), 1, false, 0, false, false);
        }
    }
}