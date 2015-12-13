using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AATF_15
{
    public class Lookup
    {
        public static Hashtable setup_team_table()
        {
            Hashtable team_table = new Hashtable();
            // since all team IDs are in order we can loop through them
            for (int team_id = 701; team_id <= 892; team_id++)
            {
                // 23 players per team
                for (int i = 1; i <= 23; i++)
                {
                    // the first three digits of a player ID are the team ID, the last two 01-23
                    team_table.Add(team_id * 100 + i, team_id);
                }
            }
            return team_table;
        }

        public static Hashtable setup_teams_4cc()
        {
            Hashtable teams_4cc = new Hashtable();
            int i = 701; // the first team is /3/ with the ID 701
            teams_4cc.Add(i++, "/3/");
            teams_4cc.Add(i++, "/a/");
            teams_4cc.Add(i++, "/adv/");
            teams_4cc.Add(i++, "/an/");
            teams_4cc.Add(i++, "/asp/");
            teams_4cc.Add(i++, "/b/");
            teams_4cc.Add(i++, "/biz/");
            teams_4cc.Add(i++, "/c/");
            teams_4cc.Add(i++, "/cgl/");
            teams_4cc.Add(i++, "/ck/");
            teams_4cc.Add(i++, "/cm/");
            teams_4cc.Add(i++, "/co/");
            teams_4cc.Add(i++, "/d/");
            teams_4cc.Add(i++, "/diy/");
            teams_4cc.Add(i++, "/e/");
            teams_4cc.Add(i++, "/f/");
            teams_4cc.Add(i++, "/fa/");
            teams_4cc.Add(i++, "/fit/");
            teams_4cc.Add(i++, "/g/");
            teams_4cc.Add(i++, "/gd/");
            teams_4cc.Add(i++, "/gif/");
            teams_4cc.Add(i++, "/h/");
            teams_4cc.Add(i++, "/hm/");
            teams_4cc.Add(i++, "/hr/");
            teams_4cc.Add(i++, "/i/");
            teams_4cc.Add(i++, "/ic/");
            teams_4cc.Add(i++, "/int/");
            teams_4cc.Add(i++, "/jp/");
            teams_4cc.Add(i++, "/k/");
            teams_4cc.Add(i++, "/lgbt/");
            teams_4cc.Add(i++, "/lit/");
            teams_4cc.Add(i++, "/m/");
            teams_4cc.Add(i++, "/mlp/");
            teams_4cc.Add(i++, "/mu/");
            teams_4cc.Add(i++, "/n/");
            teams_4cc.Add(i++, "/o/");
            teams_4cc.Add(i++, "/out/");
            teams_4cc.Add(i++, "/po/");
            teams_4cc.Add(i++, "/pol/");
            teams_4cc.Add(i++, "/r9k/");
            teams_4cc.Add(i++, "/s/");
            teams_4cc.Add(i++, "/s4s/");
            teams_4cc.Add(i++, "/sci/");
            teams_4cc.Add(i++, "/soc/");
            teams_4cc.Add(i++, "/sp/");
            teams_4cc.Add(i++, "/t/");
            teams_4cc.Add(i++, "/tg/");
            teams_4cc.Add(i++, "/toy/");
            teams_4cc.Add(i++, "/trv/");
            teams_4cc.Add(i++, "/tv/");
            teams_4cc.Add(i++, "/u/");
            teams_4cc.Add(i++, "/v/");
            teams_4cc.Add(i++, "/vg/");
            teams_4cc.Add(i++, "/vp/");
            teams_4cc.Add(i++, "/vr/");
            teams_4cc.Add(i++, "/w/");
            teams_4cc.Add(i++, "/wg/");
            teams_4cc.Add(i++, "/wsg/");
            teams_4cc.Add(i++, "/x/");
            teams_4cc.Add(i++, "/y/");
            /* TODO: add backup teams (if they have been given a name) */
            teams_4cc.Add(781, "/4ccc/");
            teams_4cc.Add(782, "Pleasure Horn");
            /* TODO: add extra teams (if they have been given a name) */
            return teams_4cc;
        }
    }
}
