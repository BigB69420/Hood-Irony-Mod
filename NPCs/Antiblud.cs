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
    public class Antiblud : ModNPC
    {
        public const string ShopName = "Shop";
        public override void SetStaticDefaults()
        {
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

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ModContent.ItemType<Items.SkullEmoji>())
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
                "Henri",
                "Jaxon",
                "Bryon",
                "Dirk",
                "Moses",
                "Talon"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName;
            }
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)

                .Add(new Item(ModContent.ItemType<Items.Weapons.Skullyoyo>()) { shopCustomPrice = Item.buyPrice(gold: 1) }, Condition.DownedMoonLord)
                .Add(new Item(ModContent.ItemType<Items.GrimaceShake>()) { shopCustomPrice = Item.buyPrice(gold: 1) })
                .Add(new Item(ItemID.SlimySaddle) { shopCustomPrice = Item.buyPrice(gold: 10) }, Condition.DownedKingSlime)
                .Add(new Item(ItemID.HoneyedGoggles) { shopCustomPrice = Item.buyPrice(gold: 10) }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.HardySaddle) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.FuzzyCarrot) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.GolfCart) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.SuperheatedBlood) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.Hardmode)
                .Add(new Item(ItemID.AncientHorn) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.Hardmode)
                .Add(new Item(ItemID.WolfMountItem) { shopCustomPrice = Item.buyPrice(gold: 35) }, Condition.Hardmode)
                .Add(new Item(ItemID.BlessedApple) { shopCustomPrice = Item.buyPrice(gold: 40) }, Condition.Hardmode)
                .Add(new Item(ItemID.ScalyTruffle) { shopCustomPrice = Item.buyPrice(gold: 40) }, Condition.Hardmode)
                .Add(new Item(ItemID.QueenSlimeMountSaddle) { shopCustomPrice = Item.buyPrice(gold: 40) }, Condition.DownedQueenSlime)
                .Add(new Item(ItemID.ReindeerBells) { shopCustomPrice = Item.buyPrice(gold: 45) }, Condition.DownedIceQueen)
                .Add(new Item(ItemID.BrainScrambler) { shopCustomPrice = Item.buyPrice(gold: 55) }, Condition.DownedMartians)
                .Add(new Item(ItemID.CosmicCarKey) { shopCustomPrice = Item.buyPrice(gold: 80) }, Condition.DownedMartians)
                .Add(new Item(ItemID.WitchBroom) { shopCustomPrice = Item.buyPrice(gold: 80) }, Condition.DownedMourningWood)
                .Add(new Item(ItemID.ShrimpyTruffle) { shopCustomPrice = Item.buyPrice(gold: 80) }, Condition.DownedDukeFishron)
                .Add(new Item(ItemID.DrillContainmentUnit) { shopCustomPrice = Item.buyPrice(gold: 500) }, Condition.DownedMoonLord)
                .Add(new Item(ItemID.DarkMageBookMountItem) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.DownedOldOnesArmyAny, Condition.InMasterMode)
                .Add(new Item(ItemID.WallOfFleshGoatMountItem) { shopCustomPrice = Item.buyPrice(gold: 30) }, Condition.Hardmode, Condition.InMasterMode)
                .Add(new Item(ItemID.PirateShipMountItem) { shopCustomPrice = Item.buyPrice(gold: 55) }, Condition.DownedPirates, Condition.InMasterMode)
                .Add(new Item(ItemID.SpookyWoodMountItem) { shopCustomPrice = Item.buyPrice(gold: 45) }, Condition.DownedMourningWood, Condition.InMasterMode)
                .Add(new Item(ItemID.SantankMountItem) { shopCustomPrice = Item.buyPrice(gold: 45) }, Condition.DownedSantaNK1, Condition.InMasterMode);


            npcShop.Register();
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Antiblud>());
            switch (Main.rand.Next(7))
            {
                case 0:
                    return "I heard the Barrington's have great status, their battle won't be in vain!";
                case 1:
                    return "These people are so friendly! But the constant spawning of bosses really kills the mood";
                case 2:
                    return "Why is my brother so unfunny? And why does he mumble absolute garbage?";
                case 3:
                    return "My developer must be pretty unfunny, this life is so hollow";
                case 4:
                    return "Thanks for letting me come here, everyone is so welcoming! Though my brother always kills the vibe";
                case 5:
                    return "Wow, the Barringtons were truly magnificent people, truly astounding";
                case 6:
                    return "My true king is the son of Dirk";
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
            projType = ProjectileID.HolyArrow;
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