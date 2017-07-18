using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF
{
    public class Check_Cards
    {
        public static void check_cards(player line, team squad)
        {
            uint total_cards = 0;
            bool captaincy = false;
            
            // Count how many (non-free) Style Cards the player has
            uint freeIndex = 0;
            for (uint i = 0; i < line.Cards_Style.Length; ++i)
            {
                // if the skill is marked as free, skip it and advance to the next free skill
                if (freeIndex < constants.free_styles.Length && i == constants.free_styles[freeIndex]) { freeIndex++; }
                // otherwise check and increment it
                else if (line.Cards_Style[i] == 1) { total_cards++; }
            }

            // Count how many (non-free) Skill Cards the player has
            freeIndex = 0;
            // likewise, trick cards
            uint trickIndex = 0; uint trickCount = 0;
            for (uint i = 0; i < line.Cards_Skills.Length; ++i)
            {
                // check if card is free
                if (freeIndex < constants.free_skills.Length && i == constants.free_skills[freeIndex]) { freeIndex++; }
                // check if card is a trick
                else if (trickIndex < constants.trick_cards.Length && i == constants.trick_cards[trickIndex])
                {
                    trickCount += (uint)line.Cards_Skills[i];
                    trickIndex++;
                }
                // otherwise add card to total
                else { total_cards += (uint)line.Cards_Skills[i]; }
            }


            // Captains are allowed a free Captaincy card
            if(line.is_captain)
            {
                squad.captains++;

                if (line.Cards_Skills[25] == 1)
                {
                    total_cards--;

                    Console.WriteLine(line.id + "\t" + line.name + " is Captain (Has free CAPTAINCY card)");
                }
                else
                {
                    Console.WriteLine(line.id + "\t" + line.name + " is Captain");
                }
            }

            // check required cards
            for (uint i = 0; i < constants.required_styles.Length; ++i)
            {
                uint card = constants.required_styles[i];
                if (line.Cards_Style[card] == 0)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " missing required style card " + card + " [" + constants.style_names[card] + "]");
                    variables.errors++;
                }
            }
            for (uint i = 0; i < constants.required_skills.Length; ++i)
            {
                uint card = constants.required_skills[i];
                if (line.Cards_Skills[card] == 0)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " missing required skill card " + card + " [" + constants.skill_names[card] + "]");
                    variables.errors++;
                }
            }

            // Check the card counts
            if ((line.is_regular) || (line.is_regular_system1))
            {
                if (total_cards > constants.cards_limit_regular)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has too many Cards (Has " + total_cards + ", can only have " + constants.cards_limit_regular + " max)");
                    variables.errors++;
                }
            }
            else if ((line.is_silver) || (line.is_silver_system1))
            {
                trickCount = Math.Min(trickCount, constants.trick_cards_silver);
                if (trickCount > 0)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has " + trickCount + " free trick card(s)");
                }
                if (total_cards-trickCount > constants.cards_limit_silver)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has too many regular Cards (Has " + (total_cards - trickCount) + ", can only have " + constants.cards_limit_silver + " max and " + constants.trick_cards_silver + " free trick(s))");
                    variables.errors++;
                }
            }
            else if ((line.is_gold) || (line.is_gold_system1))
            {
                trickCount = Math.Min(trickCount, constants.trick_cards_gold);
                if (trickCount > 0)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has " + trickCount + " free trick card(s)");
                }
                if (total_cards - trickCount > constants.cards_limit_gold)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has too many regular Cards (Has " + total_cards + ", can only have " + constants.cards_limit_gold + " max and " + constants.trick_cards_gold + " free trick(s))");
                    variables.errors++;
                }
            }
            else if ((line.is_goalkeeper) || (line.is_goalkeeper_system1))
            {
                if (total_cards > constants.cards_limit_goalkeeper)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has too many Cards (Has " + total_cards + ", can only have " + constants.cards_limit_goalkeeper + " max)");
                    variables.errors++;
                }
            }
            else { }
        }

        public static void check_captaincy(team squad)
        {
            if(squad.captains <= 0)
            {
                Console.WriteLine(squad.team_name + " has no player set as Captain. I really don't know how they managed this.");
                variables.errors++;
            }
            else if (squad.captains == 1)
            {
                // Only 1 captain is allowed
            }
            else if (squad.captains > 1)
            {
                Console.WriteLine(squad.team_name + " has " + squad.captains + " players set as Captain. This isn't possible in PES, so congrats.");
                variables.errors++;
            }
            else
            {
                Console.WriteLine("oh god how did this get here i am not good with computer");
                variables.errors++;
            }
        }
    }
}
