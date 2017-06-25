using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AATF
{
    public class Lookup
    {
        public static Hashtable setup_team_table()
        {
            Hashtable teamplayer_table = new Hashtable();

            // since all team IDs are in order we can loop through them
            for (int team_id = 701; team_id <= 892; team_id++)
            {
                // 23 players per team
                for (int i = 1; i <= 23; i++)
                {
                    teamplayer teamplayer_entry = new teamplayer();

                    // the first three digits of a player ID are the team ID, the last two 01-23
                    teamplayer_entry.teamplayer_table_team = team_id;
                    teamplayer_entry.teamplayer_table_index = i;
                    teamplayer_entry.teamplayer_table_player = team_id * 100 + i;

                    teamplayer_table.Add(teamplayer_entry.teamplayer_table_player, teamplayer_entry);
                }
            }
            return teamplayer_table;
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
            teams_4cc.Add(i++, "/his/");
            teams_4cc.Add(i++, "/p/");
            /* Backups (18) are 763-780 - note that /his/ and /p/ are newcomers
             * VGLs (50) are 781-830
             * Invitationals (32) are 831-902 */
            teams_4cc.Add(i++, "/b1/");
            teams_4cc.Add(i++, "/b2/");
            teams_4cc.Add(i++, "/b3/");
            teams_4cc.Add(i++, "/b4/");
            teams_4cc.Add(i++, "/b5/");
            teams_4cc.Add(i++, "/b6/");
            teams_4cc.Add(i++, "/b7/");
            teams_4cc.Add(i++, "/b8/");
            teams_4cc.Add(i++, "/b9/");
            teams_4cc.Add(i++, "/b10/");
            teams_4cc.Add(i++, "/b11/");
            teams_4cc.Add(i++, "/b12/");
            teams_4cc.Add(i++, "/b13/");
            teams_4cc.Add(i++, "/b14/");
            teams_4cc.Add(i++, "/b15/");
            teams_4cc.Add(i++, "/b16/");
            teams_4cc.Add(i++, "/b17/");
            teams_4cc.Add(i++, "/b18/");
            teams_4cc.Add(i++, "/v1/");
            teams_4cc.Add(i++, "/v2/");
            teams_4cc.Add(i++, "/v3/");
            teams_4cc.Add(i++, "/v4/");
            teams_4cc.Add(i++, "/v5/");
            teams_4cc.Add(i++, "/v6/");
            teams_4cc.Add(i++, "/v7/");
            teams_4cc.Add(i++, "/v8/");
            teams_4cc.Add(i++, "/v9/");
            teams_4cc.Add(i++, "/v10/");
            teams_4cc.Add(i++, "/v11/");
            teams_4cc.Add(i++, "/v12/");
            teams_4cc.Add(i++, "/v13/");
            teams_4cc.Add(i++, "/v14/");
            teams_4cc.Add(i++, "/v15/");
            teams_4cc.Add(i++, "/v16/");
            teams_4cc.Add(i++, "/v17/");
            teams_4cc.Add(i++, "/v18/");
            teams_4cc.Add(i++, "/v19/");
            teams_4cc.Add(i++, "/v20/");
            teams_4cc.Add(i++, "/v21/");
            teams_4cc.Add(i++, "/v22/");
            teams_4cc.Add(i++, "/v23/");
            teams_4cc.Add(i++, "/v24/");
            teams_4cc.Add(i++, "/v25/");
            teams_4cc.Add(i++, "/v26/");
            teams_4cc.Add(i++, "/v27/");
            teams_4cc.Add(i++, "/v28/");
            teams_4cc.Add(i++, "/v29/");
            teams_4cc.Add(i++, "/v30/");
            teams_4cc.Add(i++, "/v31/");
            teams_4cc.Add(i++, "/v32/");
            teams_4cc.Add(i++, "/v33/");
            teams_4cc.Add(i++, "/v34/");
            teams_4cc.Add(i++, "/v35/");
            teams_4cc.Add(i++, "/v36/");
            teams_4cc.Add(i++, "/v37/");
            teams_4cc.Add(i++, "/v38/");
            teams_4cc.Add(i++, "/v39/");
            teams_4cc.Add(i++, "/v40/");
            teams_4cc.Add(i++, "/v41/");
            teams_4cc.Add(i++, "/v42/");
            teams_4cc.Add(i++, "/v43/");
            teams_4cc.Add(i++, "/v44/");
            teams_4cc.Add(i++, "/v45/");
            teams_4cc.Add(i++, "/v46/");
            teams_4cc.Add(i++, "/v47/");
            teams_4cc.Add(i++, "/v48/");
            teams_4cc.Add(i++, "/v49/");
            teams_4cc.Add(i++, "/v50/");
            teams_4cc.Add(i++, "/i1/");
            teams_4cc.Add(i++, "/i2/");
            teams_4cc.Add(i++, "/i3/");
            teams_4cc.Add(i++, "/i4/");
            teams_4cc.Add(i++, "/i5/");
            teams_4cc.Add(i++, "/i6/");
            teams_4cc.Add(i++, "/i7/");
            teams_4cc.Add(i++, "/i8/");
            teams_4cc.Add(i++, "/i9/");
            teams_4cc.Add(i++, "/i10/");
            teams_4cc.Add(i++, "/i11/");
            teams_4cc.Add(i++, "/i12/");
            teams_4cc.Add(i++, "/i13/");
            teams_4cc.Add(i++, "/i14/");
            teams_4cc.Add(i++, "/i15/");
            teams_4cc.Add(i++, "/i16/");
            teams_4cc.Add(i++, "/i17/");
            teams_4cc.Add(i++, "/i18/");
            teams_4cc.Add(i++, "/i19/");
            teams_4cc.Add(i++, "/i20/");
            teams_4cc.Add(i++, "/i21/");
            teams_4cc.Add(i++, "/i22/");
            teams_4cc.Add(i++, "/i23/");
            teams_4cc.Add(i++, "/i24/");
            teams_4cc.Add(i++, "/i25/");
            teams_4cc.Add(i++, "/i26/");
            teams_4cc.Add(i++, "/i27/");
            teams_4cc.Add(i++, "/i28/");
            teams_4cc.Add(i++, "/i29/");
            teams_4cc.Add(i++, "/i30/");
            teams_4cc.Add(i++, "/i31/");
            teams_4cc.Add(i++, "/i32/");
            teams_4cc.Add(i++, "/i33/");
            teams_4cc.Add(i++, "/i34/");
            teams_4cc.Add(i++, "/i35/");
            teams_4cc.Add(i++, "/i36/");
            teams_4cc.Add(i++, "/i37/");
            teams_4cc.Add(i++, "/i38/");
            teams_4cc.Add(i++, "/i39/");
            teams_4cc.Add(i++, "/i40/");
            teams_4cc.Add(i++, "/i41/");
            teams_4cc.Add(i++, "/i42/");
            teams_4cc.Add(i++, "/i43/");
            teams_4cc.Add(i++, "/i44/");
            teams_4cc.Add(i++, "/i45/");
            teams_4cc.Add(i++, "/i46/");
            teams_4cc.Add(i++, "/i47/");
            teams_4cc.Add(i++, "/i48/");
            teams_4cc.Add(i++, "/i49/");
            teams_4cc.Add(i++, "/i50/");
            teams_4cc.Add(i++, "/i51/");
            teams_4cc.Add(i++, "/i52/");
            teams_4cc.Add(i++, "/i53/");
            teams_4cc.Add(i++, "/i54/");
            teams_4cc.Add(i++, "/i55/");
            teams_4cc.Add(i++, "/i56/");
            teams_4cc.Add(i++, "/i57/");
            teams_4cc.Add(i++, "/i58/");
            teams_4cc.Add(i++, "/i59/");
            teams_4cc.Add(i++, "/i60/");
            teams_4cc.Add(i++, "/i61/");
            teams_4cc.Add(i++, "/i62/");
            teams_4cc.Add(i++, "/i63/");
            teams_4cc.Add(i++, "/i64/");
            teams_4cc.Add(i++, "/i65/");
            teams_4cc.Add(i++, "/i66/");
            teams_4cc.Add(i++, "/i67/");
            teams_4cc.Add(i++, "/i68/");
            teams_4cc.Add(i++, "/i69/");
            teams_4cc.Add(i++, "/i70/");
            teams_4cc.Add(i++, "/i71/");
            teams_4cc.Add(i++, "/i72/");
            return teams_4cc;
        }
    }
}
