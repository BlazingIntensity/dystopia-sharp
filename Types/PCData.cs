using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Types
{
    public class PCData
    {
        //PC_DATA* next;
        public CharData Familiar { get; set; }
        public CharData Partner { get; set; }
        public CharData Propose { get; set; }
        public CharData Pfile { get; set; }
        public ObjectData ChObj { get; set; }
        public ObjectData Memorised { get; set; }
        public BoardData Board { get; set; } /* The current board */
        public DateTime[] LastNote { get; set; } // [MAX_BOARD]; /* last note for the boards */
        public NoteData InProgress { get; set; }
        public List<AliasData> Alias { get; set; }
        public string[] LastDecap { get; set; } //[2];
        public string Pwd { get; set; }
        public string Bamfin { get; set; }
        public string Bamfout { get; set; }
        public string Title { get; set; }
        public string Conception { get; set; }
        public string Parents { get; set; }
        public string CParents { get; set; }
        public string Marriage { get; set; }
        public string SwitchName { get; set; }
        public string DecapMessage { get; set; }
        public string LoginMessage { get; set; }
        public string LogoutMessage { get; set; }
        public string AvatarMessage { get; set; }
        public string TimeMessage { get; set; }
        public short Revision { get; set; }
        // public short Alias_count { get; set; }
        public short RuneCount { get; set; }
        public short Souls { get; set; }
        public short UpgradeLevel { get; set; }
        public short MeanParadoxCounter { get; set; }
        public short RelRank { get; set; }
        public short Faith { get; set; }
        public short Safe_counter { get; set; }
        public short PermStr { get; set; }
        public short PermInt { get; set; }
        public short PermWis { get; set; }
        public short PermDex { get; set; }
        public short PermCon { get; set; }
        public short ModStr { get; set; }
        public short ModInt { get; set; }
        public short ModWis { get; set; }
        public short ModDex { get; set; }
        public short ModCon { get; set; }
        public int JFlags { get; set; }
        public int QuestsRun { get; set; }
        public int QuestsTotal { get; set; }
        public int Quest { get; set; }
        public int Kingdom { get; set; }
        public int Pagelen { get; set; }
        public int Sit_safe { get; set; }
        public short Mortal { get; set; }
        public int[] Powers { get; set; } //[20]
        public int[] Stats { get; set; } //[12]
        public int DiscPoints { get; set; }
        public int DiscResearch { get; set; }
        public bool Lwrgen { get; set; }
        public short Wolf { get; set; }
        public short Rank { get; set; }
        public short Demonic_a { get; set; }
        public int[] Language { get; set; } //[2]
        public short[] Stage { get; set; } //[3]
        public short[] Wolfform { get; set; } //[2] 
        public int[] Score { get; set; } //[6]
        public short[] Disc_a { get; set; } //[11]
        public int[] Genes { get; set; } //[10]
        public short FakeSkill { get; set; }
        public short FakeStance { get; set; }
        public short FakeHit { get; set; }
        public short FakeDam { get; set; }
        public short FakeHP { get; set; }
        public short FakeMana { get; set; }
        public short FakeMove { get; set; }
        public int FakeAC { get; set; }
        public Vnum ObjVNum { get; set; }
        public short[] Condition { get; set; } //[3]
        public short[] Learned { get; set; } //[MAX_SKILL]
        public short[] StatAbility { get; set; } //[4]
        public short[] StatAmount { get; set; } //[4]
        public short[] StatDuration { get; set; } //[4]
        public short Exhaustion { get; set; }
        public short Followers { get; set; }
        public int Awins { get; set; }     /*  ARENA number of wins     */
        public int Alosses { get; set; }   /*  ARENA number of losses  */
        public int Comm { get; set; }
        public int Security { get; set; }       /* OLC - Builder security */
        public int Bounty { get; set; }

        public PCData()
        {
            LastDecap = new string[2];
        }
    }
}
