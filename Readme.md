********************************************************
 THE 4CHAN CUP AUTOMATED AUTISM TASK FORCE SAVE CHECKER
********************************************************

> im 12 and what is this

This tool is designed to automate save checking 4chan Cup teams to ensure that they meet the current
tournament regulations.


> why.png

Each player in PES14 has 84 fields each, which must all be checked to ensure there is no cheating
(or worse, rigging) within the tournament. Until now, each field had to be manually checked by the
Autism Task Force (ATF). Since there are 23 players per 4cc team, and typically 32 teams in a tournament,
this leaves the ATF having to check 61,824 fields by eye - and that doesn't even include the team-specific
checks such as Formation.

Even with all the autism in the world, alot of mistakes slip through and make it into the final tournament
save, which sucks for everyone involved.


> How does it work?

The Pro-Evo Editing Studio (PEES) contains a feature that allows you to export the Player Table from
your PES save to a CSV file. This tool simply parses this CSV, and applies a set of logic determined
by the ruleset for the current tournament.

These rules are hard-coded into autoATF, and so a new version will be compiled for each tournament. The
ruleset currently loaded will be displayed at the top of the console window.


> How do I use it?

1. Download PEES v0.2.0.0 (Later versions seem to break the csv export function, which we need)
2. Open PEES.ini
3. Change the CsvSeparator to $
4. Load up PEES
5. Load your Edit.bin
6. Go to the Players tab
7. Click the toolbox icon at the end of the search bar
8. Go to Export -> Export All Players in .csv file
9. Select where you want to save the csv file to, and type a name for it
10. Place the new csv file in the same folder as autoATF.exe
11. Open autoATF.ini
12. Change the CSVfilename to the exact name of the CSV file you generated earlier
13. Execute autoATF.exe
14. If everything was set up properly, it should successfully parse the ini and csv file
15. Type the team you want to check (without the slashes)
16. Laugh at how badly that team is rigged
17. When done, just close the console window

If you go back and change something in your save, you'll need to re-export the csv for those changes
to be detected by autoATF.

Also, if you have any issues with some checkers, they can be disabled in the autoATF.ini by setting
the relevant value to 0.


> It says there was an error parsing a player on line [x], what did I do wrong?

Check that line in your CSV file, the csv parser doesn't like it for some reason. The autoATF will still
work without them, but if that player is in the team you're checking you'll get a shitton of errors.

This could be caused by a player having a $ symbol in their name, which is what I've used as the CSV
seperator because as of now it isn't used in any 4cc player names.


> Who made this shit so I can blame them for breaking my save

Currently just me, NBD !WLix8e5EX6, but hopefully more will pitch in if it proves useful.

Also this tool doesn't even touch your actual PES save directly, so if that breaks you dun goof'd
somewhere else.


> Hey Horsefucker, your tool said my team was perfect, but it's clearly rigged! Stop shitting up the cup!

This tool doesn't check everything, only the Player Table you export from PEES. Team-specific things
such as Formation, Tactics, Captain allocation and the like are not covered by this, and so will still
need to be checked manually (until we discover a way to automate that too).


> I'd just like to interject for a moment. What you’re referring to as "autoATF", is in fact, proprietary
software and does not respect our Freedoms. Thus, I will not use it for this application.

This tool is open source, with the hope that fellow /g/entoomen will find any flaws in the logic that
may lead to loopholes. The FileHelpers Library that is used to parse the CSV file is also open source.
Both Repositories are linked from the wiki, so your Freedoms are safe, Stallman.


> Your code is awful, literally ass

I made this in three days with 6 weeks C# experience, its not going to be a masterpiece by any means. Many of
the functions could more than likely be done 10x more efficiently and with 3 less redstone, but I purposefully
made them verbose to enhance readability for when the inevitable rule changes come along. Performance wasn't
even vaguely considered, since even at it's worst this tool is still infinity times faster than save checking
manually.

Also I do it >for free.


> Why should I use this? I enjoy scouring through masses of data for minor mistakes!

Nobody is forcing you, we're just trying to make your life easier. The hope is that managers can use this
to check their saves are legit BEFORE export submission. You're not going to be banned forever for not using
autoATF. However it should drastically cut down on the number of errors the ATF has to manually fix, and
thus reduce unnecessary drama.


> But I'm from /4ccg/! I love unnecessary drama!

Each to their own then.