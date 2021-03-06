﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Commands
{
#if false
    const   struct cmd_type    cmd_table[] =
    {
        /*
         * Common movement commands.
         */

        /* Name             Function    Min Position     Level  Log      Class,DiscLevel,DiscName*/

        { "north",  do_north, POS_STANDING,  0,  LOG_NORMAL, 0,0,0 },
        { "east",   do_east,  POS_STANDING,	 0,  LOG_NORMAL, 0,0,0 },
        { "south",  do_south, POS_STANDING,	 0,  LOG_NORMAL, 0,0,0 },
        { "west",   do_west,  POS_STANDING,	 0,  LOG_NORMAL, 0,0,0 },
        { "up",     do_up,    POS_STANDING,	 0,  LOG_NORMAL, 0,0,0 },
        { "down",   do_down,  POS_STANDING,	 0,  LOG_NORMAL, 0,0,0 },

        /*
         * Common other commands.
         * Placed here so one and two letter abbreviations work.
         */
        { "cast",		do_cast,				POS_FIGHTING,	0,  LOG_NORMAL, 0,0,0},
        { "call",		do_call,	POS_SLEEPING,	 0,  LOG_NORMAL, 0,0,0},
        { "consider",		do_consider,POS_SITTING,	 0,  LOG_NORMAL, 0,0,0},
        { "chi",            do_chi,POS_FIGHTING,3, LOG_NORMAL,64,0,0 },
        { "mesmerise",	do_command,	POS_SITTING,	 3,  LOG_ALWAYS, 8, DISC_VAMP_DOMI,2 },
        { "command",	do_command,	POS_SITTING,	 3, LOG_ALWAYS, 8,DISC_VAMP_DOMI,1},
        { "crack",		do_crack,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "diagnose",	do_diagnose,POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "dismount",	do_dismount,POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "enter",		do_enter,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "exits",		do_exits,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "get",		do_get,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "medit",    do_medit,       POS_DEAD,   10,  LOG_NORMAL, 0, 0,0 },
        { "inventory",	do_inventory,POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "kill",		do_kill,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "combatswitch",	do_combatswitch,	POS_FIGHTING, 0, LOG_NORMAL, 0,0,0},
        { "look",		do_look,	POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0	},
        { "ls",			do_look,	POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0	},
        { "meditate",		do_meditate,POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0	},
        { "mount",		do_mount,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "order",		do_order,	POS_SITTING,	 1,  LOG_ALWAYS, 0,0,0	},
        { "rest",		do_rest,	POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0	},
        { "reimb",           do_reimb,        POS_MEDITATING,  12,  LOG_NORMAL, 0,0,0  },   
        { "sit",		do_sit,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "stand",		do_stand,	POS_SLEEPING,	 0,  LOG_NORMAL, 0,0,0	},
        { "tell",		do_tell,	POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0	},
        { "whisper",		do_whisper,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "wield",		do_wear,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "wizhelp",		do_wizhelp,	POS_DEAD,	 	 4,  LOG_NORMAL, 0,0,0	},
        { "version",		do_version,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "linkdead",	do_linkdead, POS_DEAD, 7, LOG_NORMAL, 0,0,0},

        /*
         * Informational commands.
         */
        { "affects",          do_affects,       POS_DEAD,                0,  LOG_NORMAL, 0,0,0},
        { "areas",		do_areas,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0},
        { "commands",		do_commands,POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0},
        { "credits",		do_credits,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0},
        { "equipment",	do_equipment,POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0},
        { "examine",		do_examine,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0},
        { "help",		do_help,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0},
        { "idea",		do_idea,	POS_DEAD,	  	 0,  LOG_NORMAL, 0,0,0},
        { "report",		do_report,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0},
        { "reply",          do_reply,       POS_MEDITATING,  0,  LOG_NORMAL, 0,0,0 },
        { "autostance",	do_autostance,	POS_STANDING,	0, LOG_NORMAL,0,0,0},
        { "mastery",        do_mastery,     POS_STANDING,   3, LOG_ALWAYS,0,0,0},
        { "upgrade",        do_upgrade,    POS_STANDING,    3, LOG_ALWAYS,0,0,0},
        { "expcalc",        do_exp,  POS_FIGHTING,      1,  LOG_NORMAL,0,0,0},
        { "pkpowers",       do_pkpowers, POS_STANDING,    0,  LOG_NORMAL,0,0,0}, 
        { "gensteal",       do_gensteal, POS_STANDING,    3,  LOG_NORMAL,0,0,0},
        { "setstance",      do_setstance, POS_STANDING,   0,  LOG_NORMAL,0,0,0},
        { "mudstat",	do_mudstat,   POS_DEAD,       2,  LOG_NORMAL,0,0,0},
        { "level",            do_level,  POS_FIGHTING,      0, LOG_NORMAL,0,0,0},
        { "top",            do_top,  POS_FIGHTING,      0,  LOG_NORMAL, 0,0,0},
        { "topclear",       do_topclear, POS_DEAD,        12, LOG_NORMAL, 0,0,0},
        { "selfclass",     do_classself,  POS_STANDING,      3,  LOG_ALWAYS, 0,0,0},
        { "score",		do_score,	POS_DEAD,	 	 0,LOG_NORMAL, 0,0,0},
        { "spit",           do_spit,    POS_SITTING,       3,  LOG_NORMAL, 8,DISC_VAMP_QUIE,1},
        { "tongue",         do_tongue,  POS_FIGHTING,      3,  LOG_NORMAL, 8,DISC_VAMP_SERP,4},
        { "mindblast",      do_mindblast,POS_STANDING,     3,  LOG_NORMAL, 8,DISC_VAMP_PRES,2},
        { "stat",           do_stat,    POS_DEAD,          3,  LOG_NORMAL, 0,0,0},
        { "skill",		do_skill,	POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0 },
        { "spells",		do_spell,	POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0 },
        { "socials",		do_socials,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0 },
        { "time",		do_time,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0 },
        { "typo",		do_typo,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0 },
        { "who",		do_who,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0 },
        { "wizlist",		do_wizlist,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0 },
        { "xemot",		do_huh,	POS_DEAD,	 	 1,  LOG_NORMAL, 0,0,0 },
        { "xemote",		do_xemote,	POS_SITTING,	 1,  LOG_NORMAL, 0,0,0 },
        { "xsocial",		do_huh,	POS_DEAD,	 	 1,  LOG_NORMAL, 0,0,0 },
        { "xsocials",		do_xsocials,POS_DEAD,	 	 1,  LOG_NORMAL, 0,0,0 },
        { "group",          do_group,       POS_DEAD,                0,  LOG_NORMAL, 0,0,0  },

        /*
         * Configuration commands.
         */
        { "alignment",	do_alignment,POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "alias",          do_alias,  POS_STANDING,         2,  LOG_ALWAYS, 0,0,0 },
        { "config",		do_config,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "compres",      do_compres,    POS_DEAD,        0,  LOG_NORMAL, 0,0,0 },
        { "compress",      do_compress,    POS_DEAD,        0,  LOG_NORMAL, 0,0,0 },
        { "description",	do_description,POS_DEAD,	 0,  LOG_NORMAL, 0,0,0	},
        { "password",		do_password,POS_DEAD,	 	 0,  LOG_NEVER, 0,0,0	},
        { "title",		do_title,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "ansi",		do_ansi,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "autoexit",		do_autoexit,POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "autoloot",		do_autoloot,POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "autosac",		do_autosac,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "blank",		do_blank,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "brief1",		 do_brief,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "brief2",          do_brief2,       POS_DEAD,                0,  LOG_NORMAL, 0,0,0  },
        { "brief3",          do_brief3,       POS_DEAD,                0,  LOG_NORMAL, 0,0,0  },
        { "brief4",          do_brief4,       POS_DEAD,                0,  LOG_NORMAL, 0,0,0  },
        { "cprompt",		do_cprompt,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "prompt",		do_prompt,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},

        /*
         * Communication commands.
         */
        { "flame",		do_flame,       POS_DEAD,                0,  LOG_NORMAL,0,0,0   },
        { "chat",		do_chat,	POS_DEAD,	 	 0,  LOG_NORMAL,0,0,0	},
        { ".",			do_chat,	POS_DEAD,2,LOG_NORMAL, 0,0,0	},
        { "clandisc",		do_clandisc,POS_SITTING,       3,  LOG_NORMAL, 0,0,0 },
        { "intro",		do_introduce,	POS_DEAD,	 3,LOG_NORMAL, 8,0,0, },
        { "intro",          do_introduce,   POS_DEAD,        3,LOG_NORMAL, 4,0,0, },
        { "emote",		do_xemote,	POS_SITTING,	 0,  LOG_NORMAL,0,0,0 },
        { ",",			do_xemote,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0},
        { "gtell",		do_gtell,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { ";",			do_gtell,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "howl",		do_howl,	POS_DEAD,	 	 1,  LOG_NORMAL, 0,0,0	},
        { "telepath",		do_telepath,	POS_DEAD,	 	 1,  LOG_NORMAL, 512,0,0	},
        { "music",		do_music,	POS_SLEEPING,	 2,  LOG_NORMAL,0,0,0 },
        { "note",		do_note,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "board",		do_board,	POS_DEAD,	0,	LOG_NORMAL,0,0,0},
        { "pose",		do_emote,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "quest",		do_quest,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "say",		do_say,		POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0	},
        { "'",		do_say,		POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0	},
        { "yell",		do_yell,	POS_SITTING,	 2,  LOG_NORMAL, 0,0,0 },
        { "powers", do_racecommands, POS_FIGHTING, 3, LOG_NORMAL,0,0,0 },

        /*
         * Object manipulation commands.
         */
        { "activate",		do_activate,POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "brandish",		do_brandish,POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "close",		do_close,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "draw",		do_draw,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "drink",		do_drink,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "drop",		do_drop,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "eat",		do_eat,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "empty",		do_empty,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "fill",		do_fill,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "give",		do_give,	POS_SITTING,	 0,  LOG_ALWAYS, 0,0,0	},
        { "gift",           do_gift,        POS_STANDING,    0,  LOG_NEVER, 0,0,0  },
        { "hold",		do_wear,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "lock",		do_lock,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "open",		do_open,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "pick",		do_pick,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "press",		do_press,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "pull",		do_pull,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "put",		do_put,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0 },
        { "quaff",		do_quaff,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "recite",		do_recite,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "remove",		do_remove,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "removealias",    do_removealias, POS_STANDING,    2,  LOG_NORMAL, 0,0,0  },
        { "sheath",		do_sheath,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "take",		do_get,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "throw",		do_throw,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "turn",		do_turn,	POS_MEDITATING,	 0,  LOG_NORMAL, 0,0,0	},
        { "twist",		do_twist,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "sacrifice",	do_sacrifice,	POS_SITTING,	 1,  LOG_NORMAL, 0,0,0	},
        { "unlock",		do_unlock,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "wear",		do_wear,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "voodoo",		do_voodoo,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "zap",		do_zap,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "junk",           do_sacrifice,POS_STANDING,     3,  LOG_NORMAL, 0,0,0 },

  	    { "stalk"	,do_stalk, POS_STANDING,	0, LOG_NORMAL,128,0,0 },


        { "ancestralpath",  do_hologramtransfer, POS_STANDING, 3, LOG_NORMAL, 16, 0, 0 },
        { "techniques",     do_bladespin,        POS_STANDING, 3, LOG_NORMAL, 16, 0, 0 },
        { "web",            do_web,              POS_FIGHTING, 3, LOG_NORMAL, 16, 0, 0 },
        { "focus",          do_focus,            POS_FIGHTING, 3, LOG_NORMAL, 16, 0 ,0 },
        { "slide",          do_slide,            POS_FIGHTING, 3, LOG_NORMAL, 16, 0, 0 },
        { "sidestep",       do_sidestep,         POS_FIGHTING, 3, LOG_NORMAL, 16, 0, 0 },
        { "block",          do_block,            POS_FIGHTING, 3, LOG_NORMAL, 16, 0, 0 },
        { "countermove",    do_countermove,      POS_FIGHTING, 3, LOG_NORMAL, 16, 0, 0 },
        { "martial",        do_martial,          POS_STANDING, 3, LOG_NORMAL, 16, 0, 0 },

       /*
         * Combat commands.
         */
        { "generation",     do_generation,POS_STANDING,   12,  LOG_ALWAYS,0,0,0 },
        { "class",          do_class,   POS_STANDING,     11, LOG_ALWAYS,0,0,0},
        { "backstab",		do_backstab,POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "berserk",		do_berserk,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "bs",			do_backstab,POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "disarm",		do_disarm,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "flee",		do_flee,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "fightstyle",	do_fightstyle,POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "hurl",		do_hurl,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "kick",		do_kick,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "servant",        do_servant, POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_DAIM,8 },
        { "punch",		do_punch,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "rescue",		do_rescue,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "stance",		do_stance,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},

       /* Demon pray - yep, kinda needed it here for some reason, damn tables. */

        { "pray",           do_pray,        POS_MEDITATING,  1,  LOG_NORMAL, 64,0,0 },

        /*
         * Lich commands.
         */
    
        { "lore",         do_lore,          POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "studylore",    do_studylore,     POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "lichtalk",     do_lichtalk,      POS_SLEEPING,   3,  LOG_NORMAL, 256,0,0},
        { "objectgate",   do_objectgate,    POS_STANDING,   3,  LOG_NORMAL, 256,0,0}, 
        { "fireball",     do_infernal,      POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "chaosmagic",   do_chaosmagic,    POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0}, 
        { "chaossurge",   do_chaossurge,    POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "chaosshield",  do_chaosshield,   POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "golemsummon",  do_summongolem,   POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "planartravel", do_planartravel,  POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "truesight",    do_truesight,     POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "planarstorm",  do_planarstorm,   POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "readaura",     do_readaura,      POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "powertransfer",do_powertransfer, POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "polarity",     do_polarity,      POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "chillhand",    do_chillhand,     POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "creepingdoom", do_creepingdoom,  POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "painwreck",    do_painwreck,     POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "earthswallow", do_earthswallow,  POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "licharmor",    do_licharmor,     POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "soulsuck",     do_soulsuck,      POS_FIGHTING,   3,  LOG_NORMAL, 256,0,0},
        { "zombie",       do_zombie,        POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "pentagram",    do_pentagram,     POS_STANDING,   3,  LOG_NORMAL, 256,0,0},
        { "planeshift",   do_planeshift,    POS_STANDING,   3,  LOG_NORMAL, 256,0,0},

        { "channels",               do_channels,POS_DEAD,            0,  LOG_NORMAL, 0,0,0  },


        /*
         * Tanar'ri commands.
         */

        { "earthquake",	do_earthquake,  POS_FIGHTING, 3, LOG_NORMAL, 1024,0,0},
        { "tornado",	do_tornado,	POS_FIGHTING, 3, LOG_NORMAL, 1024,0,0},
        { "infernal",	do_infernal,    POS_FIGHTING, 3, LOG_NORMAL, 1024,0,0},
        { "bloodsacrifice", do_bloodsac,    POS_STANDING, 3, LOG_NORMAL, 1024,0,0},
        { "enmity",		do_enmity,	POS_FIGHTING, 3, LOG_NORMAL, 1024,0,0},
        { "enrage",		do_enrage,	POS_FIGHTING, 3, LOG_NORMAL, 1024,0,0},
        { "booming",        do_booming,     POS_FIGHTING, 3, LOG_NORMAL, 1024,0,0},
        { "truesight",      do_truesight,   POS_STANDING, 3, LOG_NORMAL, 1024,0,0},
        { "web",		do_web,		POS_FIGHTING, 3, LOG_NORMAL, 1024,0,0},
        { "claws",		do_claws,	POS_STANDING, 3, LOG_NORMAL, 1024,0,0},
        { "chaosgate",	do_chaosgate,	POS_STANDING, 3, LOG_NORMAL, 1024,0,0},
        { "fury",		do_fury,	POS_STANDING, 3, LOG_NORMAL, 1024,0,0},
        { "tantalk",	do_tantalk,	POS_DEAD,     3, LOG_NORMAL, 1024,0,0},
        { "taneq",		do_taneq,	POS_STANDING, 3, LOG_NORMAL, 1024,0,0},
        { "bloodrite",      do_unholyrite,  POS_STANDING, 3, LOG_NORMAL, 1024,0,0},
        { "lavablast",	do_lavablast,	POS_FIGHTING, 3, LOG_NORMAL, 1024,0,0},
        { "chaossurge",	do_chaossurge,	POS_FIGHTING, 3, LOG_NORMAL, 1024,0,0},

        /*
         * Undead Knight commands
         */

        { "knighttalk",     do_knighttalk, POS_DEAD,   3,  LOG_NORMAL, 4096,0,0},
        { "knightarmor",  do_knightarmor, POS_STANDING, 3,  LOG_NORMAL,4096,0,0},
        { "gain",		do_gain,	POS_STANDING, 3, LOG_NORMAL,4096,0,0},
        { "weaponpractice", do_weaponpractice, POS_STANDING, 3, LOG_NORMAL, 4096,0,0},
        { "powerword",      do_powerword, POS_FIGHTING, 3,	LOG_NORMAL, 4096,0,0},
        { "aura",		do_aura,	POS_STANDING, 3, LOG_NORMAL, 4096,0,0},
        { "command",	do_command,   POS_STANDING,  3, LOG_ALWAYS, 4096,0,0},
        { "unholysight",	do_truesight,  POS_STANDING, 3, LOG_NORMAL, 4096,0,0},
        { "bloodrite",	do_unholyrite, POS_STANDING, 3, LOG_NORMAL, 4096,0,0},
        { "ride",		do_ride,	POS_STANDING, 3, LOG_NORMAL, 4096,0,0},
        { "soulsuck",     do_soulsuck,      POS_FIGHTING,   3,  LOG_NORMAL, 4096,0,0},


        /*
         * Angel Commands.
         */

        { "prayer",        do_angeltalk,     POS_MEDITATING,3, LOG_NORMAL, 2048,0,0 },
        { "gpeace",        do_gpeace,        POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "innerpeace",    do_innerpeace,    POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "houseofgod",    do_houseofgod,    POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "angelicaura",   do_angelicaura,   POS_FIGHTING,  3, LOG_NORMAL, 2048,0,0 },
        { "gbanish",       do_gbanish,       POS_FIGHTING,  3, LOG_NORMAL, 2048,0,0 },
        { "harmony",       do_harmony,       POS_FIGHTING,  3, LOG_NORMAL, 2048,0,0 },
        { "gsenses",       do_gsenses,       POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "gfavor",        do_gfavor,        POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "forgiveness",   do_forgivness,    POS_FIGHTING,  3, LOG_NORMAL, 2048,0,0 },
        { "martyr",        do_martyr,        POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "swoop",         do_swoop,         POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "awings",        do_awings,        POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "halo",          do_halo,          POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "sinsofthepast", do_sinsofthepast, POS_FIGHTING,  3, LOG_NORMAL, 2048,0,0 },
        { "eyeforaneye",   do_eyeforaneye,   POS_FIGHTING,  3, LOG_NORMAL, 2048,0,0 },
        { "angelicarmor",  do_angelicarmor,  POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },
        { "touchofgod",    do_touchofgod,    POS_FIGHTING,  3, LOG_NORMAL, 2048,0,0 },
        { "spiritform",    do_spiritform,    POS_STANDING,  3, LOG_NORMAL, 2048,0,0 },

        /*
         * Shapeshifter Commands.
         */
    
        { "shift",       do_shift,    POS_FIGHTING,   3,  LOG_NORMAL, 512,0,0 },
        { "formlearn",   do_formlearn, POS_STANDING,  3,  LOG_NORMAL, 512,0,0 },
        { "camouflage",  do_camouflage, POS_STANDING, 3,  LOG_NORMAL, 512,0,0 },
        { "mask",        do_mask,	POS_STANDING,     3,  LOG_NORMAL, 512,0,0 },
        { "truesight",   do_truesight, POS_STANDING,  3,  LOG_NORMAL, 512,0,0 },
        { "shapeshift",  do_shapeshift, POS_STANDING, 3,  LOG_NORMAL, 512,0,0 },
        { "hatform",     do_hatform,   POS_STANDING,  3,  LOG_NORMAL, 512,0,0 },
        { "mistwalk",    do_mistwalk,  POS_STANDING,  3,  LOG_NORMAL, 512,0,0 },
        { "shapearmor",  do_shapearmor, POS_STANDING, 3,  LOG_NORMAL, 512,0,0 },
        { "roar",        do_shaperoar, POS_FIGHTING,  3,  LOG_NORMAL, 512,0,0 },
        { "charge",      do_charge,   POS_FIGHTING,   3,  LOG_NORMAL, 512,0,0 },
        { "fblink",      do_faerieblink, POS_FIGHTING,3,  LOG_NORMAL, 512,0,0 },
        { "stomp",       do_stomp,  POS_FIGHTING,     3,  LOG_NORMAL, 512,0,0 },
        { "faeriecurse", do_faeriecurse, POS_FIGHTING,3,  LOG_NORMAL, 512,0,0 },
        { "phase",       do_phase,   POS_FIGHTING,    3,  LOG_NORMAL, 512,0,0 },
        { "breath",      do_breath, POS_FIGHTING,     3,  LOG_NORMAL, 512,0,0 },

        /*
         * Mage Commands.
         */

        { "magics",       do_magics,    POS_STANDING,   3,  LOG_NORMAL, 2,0,0 },
        { "teleport",     do_teleport,  POS_STANDING,   3,  LOG_NORMAL, 2,0,0 },
        { "invoke",       do_invoke,    POS_STANDING,   3,  LOG_NORMAL, 2,0,0 },
        { "chant",        do_chant,     POS_MEDITATING, 3,  LOG_NORMAL, 258,0,0 },
        { "magearmor",    do_magearmor, POS_MEDITATING, 3,  LOG_NORMAL, 2,0,0 },
        { "objectgate",   do_objectgate,POS_STANDING,   3,  LOG_NORMAL, 2,0,0 },
        { "discharge",    do_discharge,	POS_FIGHTING,	  3,  LOG_NORMAL, 2,0,0 },
        { "scry",	      do_scry,      POS_FIGHTING,   3,  LOG_NORMAL, 2,0,0 },
        { "reveal",       do_reveal,    POS_STANDING,   3,  LOG_NORMAL, 2,0,0 },
        { "chaosmagic",   do_chaosmagic, POS_FIGHTING,  3,  LOG_NORMAL, 2,0,0 },

                        /* PK POWERS */

        { "eaglesight",       do_pkscry,    POS_STANDING,   3,  LOG_NORMAL,0,0,0},
        { "silverpath",       do_pkportal,  POS_STANDING,   3,  LOG_NORMAL,0,0,0},
        { "lifesense",	  do_pkaura,	POS_STANDING,   3,  LOG_NORMAL,0,0,0},
        { "sanctum",	  do_pkheal,    POS_STANDING,   3,  LOG_NORMAL,0,0,0},
        { "calltoarms",	  do_pkcall,	POS_FIGHTING,   3,  LOG_NORMAL,0,0,0},
        { "ironmind",	  do_pkmind,    POS_STANDING,   3,  LOG_NORMAL,0,0,0},
        { "objectscry",       do_pkobjscry, POS_STANDING,   3,  LOG_NORMAL,0,0,0},
        { "crystalsight",     do_pkvision,  POS_STANDING,   3,  LOG_NORMAL,0,0,0},


    /*                      ****|  V-A-M-P-I-R-E-S  |****          */

    // Melpominee
        { "scream",		do_scream,    POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_MELP, 1 },

    // Daimoinon
        { "guardian",	do_guardian,  POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_DAIM, 1 },
        { "fear",		do_fear,      POS_FIGHTING,  3,  LOG_NORMAL, 8, DISC_VAMP_DAIM, 2 },
        { "portal",		do_gate,      POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_DAIM, 3 },
    // Lvl 4 - curse ---
        { "vtwist",		do_vtwist,     POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_DAIM, 5 },
        { "wither", do_wither, POS_FIGHTING, 3, LOG_NORMAL, 4,DISC_WERE_HAWK,7 },

    // Thanatosis
        { "hagswrinkles",	do_hagswrinkles,POS_STANDING, 3, LOG_NORMAL, 8, DISC_VAMP_THAN, 1 },
        { "putrefaction",   do_rot,	      POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_THAN, 2 },
    /*    { "ashes",		do_ashes,     POS_STANDING,  3,
    LOG_NORMAL, 8, DISC_VAMP_THAN, 3 }, */
        { "withering",	do_withering, POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_THAN, 4 },
        { "drainlife",	do_drain,     POS_FIGHTING,  3,  LOG_NORMAL, 8, DISC_VAMP_THAN, 5 },

    // Necromancy
   
        { "preserve",	do_preserve,  POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_NECR, 2 },
        { "spiritgate",	do_spiritgate,POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_NECR, 3 },
        { "spiritguard",	do_spiritguard,POS_STANDING, 3,  LOG_NORMAL, 8, DISC_VAMP_NECR, 4 },


    // Auspex
        { "truesight",      do_truesight, POS_STANDING,  3,  LOG_NORMAL, 4, DISC_WERE_HAWK, 3 },
        { "truesight",	do_truesight, POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_AUSP, 1 },
        { "readaura",	do_readaura,  POS_FIGHTING,  3,  LOG_NORMAL, 8, DISC_VAMP_AUSP, 2 },
        { "scry",		do_scry,      POS_FIGHTING,  3,  LOG_NORMAL, 8, DISC_VAMP_AUSP, 3 },
        { "astralwalk",	do_astralwalk,POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_AUSP, 4 },
        { "unveil",		do_unveil,    POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_AUSP, 5 },

    // Obfuscate
        { "vanish",		do_vanish,    POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_OBFU, 1 },
        { "mask",		do_mask,      POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_OBFU, 2 },
        { "shield",		do_shield,    POS_STANDING,  3,  LOG_NORMAL, 8, DISC_VAMP_OBFU, 3 },
        { "shield",         do_shield,    POS_STANDING,  3,  LOG_NORMAL, 4, DISC_WERE_OWL, 2 },

    // Chimerstry
        { "mirror",		do_mirror,    POS_STANDING,  3, LOG_NORMAL, 8, DISC_VAMP_CHIM, 1 },
        { "formillusion",	do_formillusion,POS_STANDING, 3, LOG_NORMAL,8, DISC_VAMP_CHIM, 2 },
        { "controlclone",	do_control,   POS_STANDING,  3, LOG_NORMAL, 8, DISC_VAMP_CHIM, 4 },

        /*
         * Miscellaneous commands.
         */
        { "accep",		do_huh,		POS_STANDING,	 2,  LOG_NORMAL, 0,0,0	},
        { "accept",		do_accept,	POS_STANDING,	 2,  LOG_NORMAL, 0,0,0	},
        { "artifact",	do_artifact,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "birth",		do_birth,	POS_STANDING,	 1,  LOG_NORMAL, 0,0,0	},
        { "blindfold",	do_blindfold,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "breaku",		do_huh,		POS_STANDING,	 2,  LOG_NORMAL, 0,0,0	},
        { "breakup",	do_breakup,	POS_STANDING,	 2,  LOG_NORMAL, 0,0,0	},
        { "claim",		do_claim,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "complete",	do_complete,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "consen",		do_huh,		POS_STANDING,	 1,  LOG_NORMAL, 0,0,0	},
        { "consent",	do_consent,	POS_STANDING,	 1, LOG_NORMAL, 0,0,0	},
        { "finger",		do_finger,	POS_SITTING,	 1,  LOG_NORMAL, 0,0,0	},
        { "follow",		do_follow,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "gag",		do_gag,		POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "godsfavor",      do_godsfavor,POS_DEAD,         3,  LOG_NORMAL, 64,0,0 },
        { "hide",		do_hide,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "home",		do_home,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "hunt",		do_hunt,	POS_STANDING,	 1,  LOG_NORMAL, 0,0,0	},
        { "locate",		do_locate,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "practice",		do_practice,POS_SLEEPING,	 0,  LOG_NORMAL, 0,0,0	},
        { "propos",		do_huh,	POS_STANDING,	 2,  LOG_NORMAL, 0,0,0	},
        { "propose",		do_propose,	POS_STANDING,	 2,  LOG_NORMAL, 0,0,0	},
        { "qui",		do_qui,	POS_DEAD,		 0,  LOG_NORMAL, 0,0,0	},
        { "quit",		do_quit,	POS_SLEEPING,	 0,  LOG_NORMAL, 0,0,0	},
        { "recall",		do_recall,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "escape",		do_escape,	POS_DEAD,	 	 3,  LOG_NORMAL, 0,0,0	},
        { "/",			do_recall,	POS_FIGHTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "recharge",		do_recharge,POS_STANDING,	 0,LOG_NORMAL, 0,0,0	},
        { "rent",		do_rent,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "safe",		do_safe,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "save",		do_save,	POS_DEAD,	 	 0,  LOG_NORMAL, 0,0,0	},
        { "sleep",		do_sleep,	POS_SLEEPING,	 0,  LOG_NORMAL, 0,0,0	},
        { "smother",		do_smother,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "sneak",		do_sneak,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "scan",		do_scan,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "spy",		do_spy,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "steal",		do_steal,	POS_STANDING,	 0,  LOG_NORMAL, 0,0,0	},
        { "notravel",		do_notravel,POS_DEAD,	 	 1,LOG_NORMAL, 0,0,0 },
        { "nosummon",		do_nosummon,POS_DEAD,	 	 1,  LOG_NORMAL, 0,0,0	},
        { "embrace",        do_embrace, POS_STANDING,      3,  LOG_NORMAL, 8,0,0 },
        { "diablerise",	do_diablerise, POS_STANDING, 3, LOG_NORMAL, 8,0,0 },
        { "assassinate",    do_assassinate,POS_STANDING,   3,  LOG_NORMAL, 8,DISC_VAMP_QUIE,4 },
        { "tendrils",           do_tendrils,POS_FIGHTING,      3,  LOG_NORMAL, 8,DISC_VAMP_SERP,4 },
        { "lamprey",        do_lamprey, POS_FIGHTING,      3,  LOG_NORMAL, 8,DISC_VAMP_OBTE,5 },
        { "entrance",       do_entrance,POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_PRES,3 },
        { "fleshcraft",     do_fleshcraft,POS_STANDING,    3,  LOG_NORMAL, 8,DISC_VAMP_VICI,2 },
        { "zombie",         do_zombie,  POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_NECR,5 },
        { "baal",           do_baal,    POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_DOMI,5 },
        { "dragonform",     do_dragonform,POS_STANDING,    3,  LOG_NORMAL, 8,DISC_VAMP_VICI,4 },
        { "spew",           do_spew,    POS_FIGHTING,      3,  LOG_NORMAL, 8,DISC_VAMP_THAU,6 },
        { "bloodwater",     do_bloodwater,POS_FIGHTING,    3,  LOG_NORMAL, 8,DISC_VAMP_NECR,5 },
        { "gourge",         do_gourge,  POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_THAU,8 },
        { "roar",		do_roar,    POS_FIGHTING,      3,  LOG_NORMAL, 4,DISC_WERE_BEAR,6 },
        { "jawlock",	do_jawlock, POS_STANDING,      3,  LOG_NORMAL, 4,DISC_WERE_RAPT,8 },
        { "perception",	do_perception,POS_STANDING,    3,  LOG_NORMAL, 4,DISC_WERE_RAPT,3 },
        { "skin",		do_skin,    POS_STANDING,      3,  LOG_NORMAL, 4,DISC_WERE_BEAR,7 },
        { "rend",		do_rend,    POS_STANDING,      3,  LOG_NORMAL, 4,DISC_WERE_BOAR,7 },
        { "slam",		do_slam,    POS_STANDING,      3,  LOG_NORMAL, 4,DISC_WERE_BEAR,8 },
        { "shred",		do_shred,   POS_STANDING,      3,  LOG_NORMAL, 4,DISC_WERE_RAPT,7 },
        { "diablerize",	do_diablerise, POS_STANDING,   3,  LOG_NORMAL, 8,0,0},
        { "taste",          do_taste,   POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_THAU,1 },
        { "pigeon",         do_pigeon,  POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_ANIM,3 },
        { "bloodagony",     do_bloodagony,POS_STANDING,    3,  LOG_NORMAL, 8,DISC_VAMP_QUIE,3 },
        { "tie",		do_tie,	POS_STANDING,	 3,  LOG_NORMAL, 0,0,0	},
        { "token",		do_token,	POS_STANDING,	 2,  LOG_NORMAL, 0,0,0	},
        { "track",		do_track,	POS_STANDING,	 1,  LOG_NORMAL, 0,0,0	},
        { "train",		do_train,   POS_STANDING,	 1,  LOG_NORMAL, 0,0,0	},
        { "unpolymorph",	do_unpolymorph,POS_STANDING,	 4,  LOG_NORMAL, 0,0,0 },
        { "untie",		do_untie,	POS_STANDING,	 1,  LOG_NORMAL, 0,0,0	},
        { "visible",		do_visible,	POS_SLEEPING,	 1,  LOG_NORMAL, 0,0,0 },
        { "wake",		do_wake,	POS_SLEEPING,	 0,  LOG_NORMAL, 0,0,0	},
        { "where",		do_where,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},

    /* need it before forge */


         { "contraception", do_contraception, POS_DEAD,  1,      LOG_NORMAL, 0,0,0},


     /*
      * Monk
      */
        { "chaoshands",	do_chands,	POS_STANDING,	 3,  LOG_NORMAL, 64,0,0 },
        { "monkarmor",	do_monkarmor,	POS_STANDING,	 3,  LOG_NORMAL, 64,0,0 },
        { "ghold",		do_ghold,	POS_STANDING,    3,  LOG_NORMAL, 64,0,0 },
        { "godsheal",	do_godsheal,	POS_FIGHTING,	 3,  LOG_NORMAL, 64,0,0 },
        { "mantra",		do_mantra,	POS_STANDING,	 3, LOG_NORMAL, 64,0,0 },
        { "guide",		do_guide,	POS_STANDING,	 3,  LOG_NORMAL, 64,0,0 },
        { "wrathofgod",  do_wrathofgod, POS_FIGHTING, 3, LOG_NORMAL, 64,0,0},
        { "cloak",		do_cloak,	POS_STANDING,      3,  LOG_NORMAL, 64,0,0 },
        { "prayofages",	do_prayofages,POS_STANDING,    3,  LOG_NORMAL, 64,0,0 },
        { "sacredinvis",	do_sacredinvis, POS_STANDING,	 3,  LOG_NORMAL, 64,0,0 },
        { "flaminghands",   do_flaminghands,POS_STANDING,  3,  LOG_NORMAL, 64,0,0 },
        { "darkblaze",	do_darkblaze, POS_FIGHTING,	3, LOG_NORMAL, 64,0,0},
        { "adamantium",	do_adamantium,POS_STANDING,    3,  LOG_NORMAL, 64,0,0 },
        { "godseye",		do_godseye,	POS_STANDING,	 3,  LOG_NORMAL, 64,0,0 },
        { "celestial",	do_celestial,POS_STANDING,	 3,  LOG_NORMAL, 64,0,0 },
        { "steelskin",	do_steelskin,POS_STANDING,	 3,  LOG_NORMAL, 64,0,0 },
        { "godsbless",	do_godsbless,POS_FIGHTING,	 3,  LOG_NORMAL, 64,0,0 },
        { "thrustkick",	do_thrustkick,POS_FIGHTING,	3, LOG_NORMAL, 64,0,0 },
        { "spinkick",	do_spinkick,POS_FIGHTING,3,LOG_NORMAL,64,0,0 },
        { "backfist",	do_backfist,POS_FIGHTING,3,LOG_NORMAL,64,0,0 },
        { "elbow",		do_elbow,POS_FIGHTING,3,LOG_NORMAL,64,0,0 },
        { "sweep",		do_sweep,POS_FIGHTING,3,LOG_NORMAL,64,0,0 },
        { "reverse",	do_reverse,POS_FIGHTING,3,LOG_NORMAL,64,0,0 },
        { "knee",		do_knee,POS_FIGHTING,3,LOG_NORMAL,64,0,0 },
        { "shinkick",	do_shinkick,POS_FIGHTING,3,LOG_NORMAL,64,0,0 },
        { "palmstrike",	do_palmstrike,POS_FIGHTING,3,LOG_NORMAL,64,0,0 },
        { "spiritpower",	do_spiritpower,POS_FIGHTING,3,LOG_NORMAL,64,0,0},
        { "deathtouch",	do_deathtouch,POS_STANDING,3,LOG_NORMAL,64,0,0 },
        { "relax",		do_relax,POS_FIGHTING,3,LOG_NORMAL,64,0,0},
        { "monktalk",	do_monktalk,POS_DEAD,3,LOG_NORMAL,64,0,0 },
        { "disciplines",    do_disciplines,POS_STANDING,   3,  LOG_NORMAL, 0,0,0 },
        { "research",		do_research,POS_STANDING,      3,  LOG_NORMAL, 0,0,0 },


    /*
     * Garou
     */
    // Ahroun
        { "razorclaws",	do_razorclaws, POS_FIGHTING, 3, LOG_NORMAL, 4,DISC_WERE_WOLF,4 },

    // Homid
    //  Persuasion, automatic
        { "staredown",	do_staredown, POS_FIGHTING, 3, LOG_NORMAL, 4,DISC_WERE_OWL,5 },
        { "disquiet",	do_disquiet, POS_FIGHTING, 3 , LOG_NORMAL, 4,DISC_WERE_OWL,6 }, 
        { "reshape",	do_reshape,  POS_STANDING,  3,  LOG_NORMAL, 4,DISC_WERE_OWL,7 },
        { "cocoon",		do_cocoon,   POS_FIGHTING,  3,  LOG_NORMAL, 4,DISC_WERE_OWL, 8 },

    // Metis
        { "quills",	do_quills, POS_FIGHTING, 3, LOG_NORMAL, 4,DISC_WERE_HAWK,5 },
        { "burrow", do_burrow, POS_FIGHTING, 3, LOG_NORMAL, 4,DISC_WERE_HAWK,6 },
        { "nightsight",do_nightsight,POS_FIGHTING,3,LOG_NORMAL,4,DISC_WERE_HAWK,1 },

        { "learn",		do_learn, POS_FIGHTING, 3, LOG_NORMAL, 64,0,0 },

        /*
         * Vampire and werewolf commands.
         */
        { "vamparmor",	do_vampirearmor, POS_STANDING, 3, LOG_NORMAL, 8, 0, 0 },
        { "bloodwall",	do_bloodwall,POS_STANDING,	 3,  LOG_NORMAL, 8,DISC_VAMP_DAIM,2 },
        { "conceal",     do_conceal,  POS_STANDING,  3,  LOG_NORMAL, 8,DISC_VAMP_OBFU,5 },
        { "sharpen",	do_sharpen,  POS_STANDING,     3,  LOG_NORMAL, 8,DISC_VAMP_QUIE,7 },
        { "purify",      do_purification, POS_STANDING, 3, LOG_NORMAL, 0, 0, 0 },

         /* Protean */ /* healing has to go after drow heal */
        /* Obtene */
        { "grab",		do_grab,	POS_STANDING,    	 3,  LOG_NORMAL, 8,DISC_VAMP_OBTE,8 },
        { "shadowgaze",	do_shadowgaze,POS_STANDING,    3,  LOG_NORMAL, 8,DISC_VAMP_OBTE,10 },

       /* Luna Powers */
        { "flameclaws",	do_flameclaws,  POS_STANDING,  3,  LOG_NORMAL, 4,DISC_WERE_LUNA,1 },
        { "motherstouch",	do_motherstouch,POS_FIGHTING,  3,  LOG_NORMAL, 4,DISC_WERE_LUNA,3 },
        { "gmotherstouch",  do_gmotherstouch,POS_FIGHTING, 3,  LOG_NORMAL, 4,DISC_WERE_LUNA,4 },
        { "sclaws",		do_sclaws,	POS_STANDING,      3,  LOG_NORMAL, 4,DISC_WERE_LUNA,5 },
        { "moonbeam",	do_moonbeam,POS_FIGHTING,      3,  LOG_NORMAL, 4,DISC_WERE_LUNA,8 },
        { "moonarmour",	do_moonarmour,POS_STANDING,    3,  LOG_NORMAL, 4,DISC_WERE_LUNA,2 },
        { "moongate",	do_moongate,POS_STANDING,      3,  LOG_NORMAL, 4,DISC_WERE_LUNA,6 },
       /* No more luna Powers */

        { "tribe",		do_tribe,	POS_STANDING,	3,LOG_NORMAL,4,0,0},
        { "info",		do_info,	POS_DEAD,      12,LOG_NORMAL,0,0,0 },
        { "demongate",	do_dgate,      POS_FIGHTING,   3, LOG_NORMAL, 1,0,0 },
        { "devour",		do_devour,     POS_STANDING,   3, LOG_NORMAL, 4,DISC_WERE_RAPT,5 },
        { "frostbreath",    do_frostbreath,POS_FIGHTING,   3, LOG_NORMAL, CLASS_DEMON,DISC_DAEM_GELU,2 },
        { "tick",		do_tick,       POS_DEAD,      12, LOG_ALWAYS, 0,0,0},
        { "resetarea",	do_resetarea,  POS_DEAD,      10, LOG_ALWAYS, 0,0,0},
        { "graft",		do_graft,      POS_STANDING,   3, LOG_NORMAL, CLASS_DEMON,DISC_DAEM_ATTA,5 },
        { "rage",		do_rage,       POS_FIGHTING,   3, LOG_NORMAL, CLASS_DEMON,DISC_DAEM_ATTA,3 },
        { "calm",		do_calm,       POS_STANDING,   3, LOG_NORMAL, CLASS_DEMON,DISC_DAEM_ATTA,4 },
        { "vamptalk",       do_vamptalk,   POS_DEAD,       1, LOG_NORMAL, 8,0,0 },      
        { "obtain",          do_obtain,  POS_STANDING,   3,  LOG_NORMAL, 0,0,0 },
        { "warps",          do_warps,  POS_STANDING,   3,  LOG_NORMAL, 0,0,0 },   
        { "claws",		do_claws,	POS_FIGHTING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_ATTA,1 },
        { "claws",          do_claws,       POS_FIGHTING,  3,  LOG_NORMAL, 4,DISC_WERE_WOLF,1 },
        { "fangs",		do_fangs,	POS_FIGHTING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_ATTA,2 },
        { "fangs",          do_fangs,       POS_FIGHTING,  3,  LOG_NORMAL, 4,DISC_WERE_WOLF,2 },
        { "horns",		do_horns,	POS_FIGHTING,  3, LOG_NORMAL, 1,DISC_DAEM_ATTA,4 },
        { "blink",		do_blink,	POS_FIGHTING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_ATTA,7 },
        { "inferno",	do_dinferno,	POS_DEAD,      3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_HELL, 3 },
        { "tail",		do_tail,	POS_FIGHTING,  3,  LOG_NORMAL, 1,0,0 },

    /* Vamp */
        { "binferno",	do_inferno,	POS_STANDING,  3,  LOG_NORMAL, 1,DISC_VAMP_DAIM, 6 },
    /* Vamp ^^^^ */

        { "immolate",	do_immolate,    POS_STANDING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_HELL, 2 },
        { "daemonseed",	do_seed,	POS_STANDING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_HELL, 7 },
        { "hellfire",	do_hellfire,	POS_STANDING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_HELL, 8 },
        { "ban",		do_ban,	POS_DEAD,		 12,  LOG_ALWAYS,0,0,0	},
        { "transfer",       do_transfer,    POS_DEAD,      7,  LOG_NORMAL,0,0,0 },
        { "runeeq",		do_runeeq,	POS_STANDING,    2,  LOG_NORMAL,0,0,0 },
        { "afk",      	do_afk,         POS_STANDING,    3,  LOG_NORMAL,0,0,0 },
        { "hedit",		do_hedit,	POS_STANDING, 10, LOG_NORMAL,0,0,0 },
        { "freeze",		do_freeze,      POS_DEAD,     9, LOG_ALWAYS,0,0,0 },  
        { "bitchslap", 	do_freeze,   POS_DEAD,     9, LOG_ALWAYS,0,0,0 },
        { "unnerve",	do_unnerve,     POS_FIGHTING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_DISC,1 },
        { "freezeweapon",	do_wfreeze,     POS_STANDING,  3, LOG_NORMAL, CLASS_DEMON,DISC_DAEM_GELU, 1 },
        { "chaosportal",	do_chaosport,   POS_FIGHTING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_DISC, 4 },
        { "caust",		do_caust,       POS_STANDING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_CORR, 4 },
        { "gust",		do_gust,	POS_STANDING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_GELU, 7 },
        { "entomb",		do_entomb,      POS_STANDING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_GELU, 6 },
        { "evileye",	do_evileye,     POS_STANDING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_DISC, 2 },
        { "leech",		do_leech,	POS_FIGHTING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_NETH,4 },
        { "deathsense",	do_deathsense,  POS_FIGHTING,  3,  LOG_NORMAL, CLASS_DEMON,DISC_DAEM_NETH, 2 },
        { "prefix",		do_prefix,	POS_DEAD,      10,  LOG_NORMAL, 0,0,0 },

        /* bugaboo lala Dunkirk Shit Lala mmm POOP Daemon Stuff */


        /* Start of OLC Shit. Hmm */
        { "hset",		do_hset,        POS_DEAD,      12, LOG_ALWAYS, 0,0,0 },
        { "hlist",		do_hlist,	POS_DEAD,      12, LOG_ALWAYS, 0,0,0 },

        { "talons",         do_talons,   POS_FIGHTING,     3,  LOG_NORMAL, 4,DISC_WERE_RAPT,10 },
        { "bonemod",		do_bonemod,	POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_VICI,3 },
        { "cauldron",		do_cauldron,POS_FIGHTING,      3, LOG_NORMAL, 8,DISC_VAMP_THAU,2 },
        { "flamehands",	do_flamehands,POS_FIGHTING,	 3,  LOG_NORMAL, 8,DISC_VAMP_PROT,5 },
   
        { "summon",		do_summon,	POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_PRES,4 },
        { "shroud",		do_shroud,	POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_OBTE,1 },
        { "share",		do_share,	POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_ANIM,4 },
        { "frenzy",		do_frenzy,	POS_FIGHTING,	 3,  LOG_NORMAL, 8,DISC_VAMP_ANIM,5 },
        { "far",		do_far,	POS_STANDING,	 3,  LOG_NORMAL, 8,DISC_VAMP_PRES,9 },
        { "awe",            do_awe,     POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_PRES,1 },


        { "forge",		do_forge,	POS_STANDING,  1,LOG_NORMAL,0,0,0 },
        { "forget",         do_forget,  POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_DOMI,8 },
        { "acid",           do_acid,    POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_DOMI,4 },
        { "vsilence",       do_death,   POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_QUIE,5 },
        { "flash",          do_flash,   POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_QUIE,9 },
        { "tide",   	do_tide,    POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_THAU,5 },
        { "coil",           do_coil,    POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_SERP,8 },
        { "infirmity",	do_infirmity,POS_FIGHTING,	 3,  LOG_NORMAL, 8,DISC_VAMP_QUIE,2 },
        { "klaive",         do_klaive,  POS_STANDING,      3,  LOG_NORMAL, 4,0,0 },
        { "calm",		do_calm,	POS_STANDING,	 3,  LOG_NORMAL, 4,DISC_WERE_WOLF,3	},
        { "change",		do_change,	POS_STANDING,	 3,  LOG_NORMAL, 8,DISC_VAMP_PROT,3	},
        { "katana",		do_katana,	POS_RESTING, 3, LOG_NORMAL, CLASS_SAMURAI, 0, 0 },
        { "earthshatter",	do_earthshatter,POS_FIGHTING,   3, LOG_NORMAL, 0, 0, 0 },
        { "ninjaarmor",          do_ninjaarmor,       POS_STANDING, 3, LOG_NORMAL, CLASS_NINJA, 0, 0 },
        { "shadowstep",	do_shadowstep,	POS_STANDING,    3,  LOG_NORMAL, 8,DISC_VAMP_OBTE,4 },
        { "claws",		do_claws,	POS_SITTING,	 3,  LOG_NORMAL, 8,DISC_VAMP_PROT,2	},
        { "darkheart",	do_darkheart,	POS_STANDING,	 3,  LOG_NORMAL, 8,DISC_VAMP_SERP,1	},
        { "earthmeld",      do_earthmeld,	POS_STANDING,     3,  LOG_NORMAL, 8,DISC_VAMP_PROT,4 },
        { "burrow",         do_burrow, 	POS_STANDING,      3,  LOG_NORMAL, 4,DISC_WERE_BOAR,5 },
        { "fangs",		do_fangs,	POS_SITTING,	 3,  LOG_NORMAL, 8,0,0	},
        { "flex",		do_flex,	POS_SITTING,	 0,  LOG_NORMAL, 0,0,0	},
        { "gcommand",	do_fcommand,	POS_STANDING,	 3,  LOG_NORMAL, 0,0,0	},
        { "possession",     do_possession,	POS_STANDING,    3,  LOG_NORMAL, 8,DISC_VAMP_DOMI,3 },
        { "hum",		do_monktalk,	POS_DEAD,		3, LOG_NORMAL, 0, 0, 0},
        { "humanform",	do_humanform,POS_SITTING,	 2,  LOG_NORMAL, 0,0,0 },
        { "theft",          do_theft,   POS_FIGHTING,      3,  LOG_NORMAL, 8,DISC_VAMP_THAU,4 },   
        { "plasma",         do_plasma,  POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_VICI,5 },
        { "zuloform",       do_zuloform,POS_FIGHTING,      3,  LOG_NORMAL, 8,DISC_VAMP_VICI,2},
        { "beckon",         do_beckon,  POS_STANDING,      3,  LOG_NORMAL, 8,DISC_VAMP_ANIM,1},

        /* Ninja */

        { "miktalk", do_miktalk, 	POS_SLEEPING, 2, LOG_NORMAL, 128, 0, 0},
        { "principles", do_principles, POS_MEDITATING, 3, LOG_NORMAL, 128, 0, 0 },
        { "michi", do_michi, POS_FIGHTING, 3, LOG_NORMAL, 128, 0, 0 },
        { "harakiri", do_hara_kiri, POS_MEDITATING,3, LOG_NORMAL, 128, 0, 0 },
        { "circle",	do_circle, POS_FIGHTING, 3, LOG_NORMAL, 128, 0, 0},
        { "kakusu", do_kakusu, POS_STANDING, 3, LOG_NORMAL, 128, 0, 0 },
        { "kanzuite", do_kanzuite, POS_MEDITATING, 3, LOG_NORMAL, 128, 0, 0 },
        { "mienaku", do_mienaku, POS_FIGHTING, 3, LOG_NORMAL, 128, 0, 0 },
        { "bomuzite", do_bomuzite, POS_MEDITATING, 3, LOG_NORMAL, 128, 0, 0  },
        { "tsume", do_tsume, POS_FIGHTING, 3, LOG_NORMAL, 128, 0, 0 },
        { "mitsukeru", do_mitsukeru, POS_MEDITATING, 3, LOG_NORMAL, 128, 0, 0 },
        { "koryou", do_koryou, POS_MEDITATING, 3, LOG_NORMAL, 128,0,0},
        { "hakunetsu", do_strangle,  POS_STANDING, 3, LOG_NORMAL, 128,0,0},

        /*start drow section */

        { "newbie",		do_newbie,	POS_DEAD,	1, LOG_NORMAL,0,0,0},
        { "sign",		do_sign,	POS_DEAD,	 1,  LOG_NORMAL, 32,0,0 },
        { "relevel",		do_relevel,	POS_DEAD,   	 0,  LOG_ALWAYS, 0,0,0 },
        { "grant",		do_grant,	POS_STANDING,	 3,  LOG_NORMAL, 32,0,0 },
        { "drowsight",	do_drowsight,POS_STANDING,     3,  LOG_NORMAL, 32,0,0 },
        { "drowshield",	do_drowshield,POS_STANDING,    3,  LOG_NORMAL, 32,0,0 },
        { "drowfire",		do_drowfire,POS_FIGHTING,      3,  LOG_NORMAL, 32,0,0 },
        { "drowhate",	do_drowhate,	POS_STANDING,    3,  LOG_NORMAL, 32,0,0 },
        { "drowpowers",	do_drowpowers,	POS_STANDING,    3,  LOG_NORMAL, 32,0,0 },
        { "darkness",       do_darkness,	POS_STANDING,    3,  LOG_NORMAL, 32,0,0 },
        { "lloth",		do_lloth,	POS_STANDING,	3,	LOG_NORMAL,32,0,0},
        { "shadowwalk",	do_shadowwalk,	POS_STANDING,    3,  LOG_NORMAL, 32,0,0 },
        { "drowcreate",    	do_drowcreate,	POS_STANDING,    3,  LOG_NORMAL, 32,0,0 },
        { "heal",		do_heal,	POS_FIGHTING,    3,  LOG_NORMAL, 32,0,0 },
        { "garotte",	do_garotte,	POS_FIGHTING,    3,  LOG_NORMAL, 32,0,0 },
        { "spiderform",	do_spiderform,	POS_STANDING,    3,  LOG_NORMAL, 32,0,0 },
        { "chaosblast",	do_chaosblast,	POS_FIGHTING,    3,  LOG_NORMAL, 32,0,0 },
        { "dgarotte",	do_dark_garotte,POS_STANDING,   3, LOG_NORMAL, 32, 0, 0 },
        { "glamour",	do_glamour	,POS_RESTING,	3, LOG_NORMAL, 32, 0, 0 },
        { "confuse",	do_confuse	,POS_FIGHTING,  3, LOG_NORMAL, 32, 0, 0 },
        { "darktendrils", do_darktendrils, POS_STANDING,  3, LOG_NORMAL, 32, 0, 0 },
  	    { "fightdance", do_fightdance, POS_STANDING,  3, LOG_NORMAL, 32, 0, 0},

    /* end drow */



    /*demon section*/

        { "eyespy",		do_eyespy,      POS_STANDING,    3,  LOG_NORMAL, 1,0,0 },
        { "champions",	do_champions,	POS_STANDING,	 3,  LOG_NORMAL, 1,0,0 },
        { "demonarmour",	do_demonarmour,	POS_STANDING,	 3,  LOG_NORMAL, 1,0,0 },
        { "hooves",		do_hooves,	POS_STANDING,	 3,  LOG_NORMAL, 1,0,0 },
        { "humanform",	do_humanform,	POS_SITTING,	 2,  LOG_NORMAL, 1,0,0 },
        { "inpart",		do_inpart,	POS_STANDING,	 3,  LOG_NORMAL, 1,0,0 },
        { "travel",		do_travel,	POS_STANDING,	 3,  LOG_NORMAL, 1,0,0 },
        { "weaponform",	do_weaponform,	POS_STANDING,	 2,  LOG_NORMAL, 1,0,0 },
        { "leap",		do_leap,	POS_STANDING,	 3,  LOG_NORMAL, 1,0,0 },
        { "wings",		do_wings,	POS_STANDING,	 3,  LOG_NORMAL, 1,0,0 },
        { "demonform",	do_demonform,	POS_STANDING,    3,  LOG_NORMAL, 1,0,0, },

    /*end demon section*/



    /* vamp protean healing*/
        { "healing",		do_healing, POS_FIGHTING,      3,   LOG_NORMAL, 8,DISC_VAMP_PROT,8},
        { "healingtouch",   do_healingtouch,POS_STANDING,3,LOG_NORMAL,64,0,0}, /*monks healing power*/
        { "inconnu",		do_inconnu,	POS_STANDING,	 3,  LOG_NORMAL, 8,0,0	},
        { "majesty",		do_majesty,	POS_STANDING,	 3,  LOG_NORMAL, 8,DISC_VAMP_PRES,5	},
        { "nightsight",	do_nightsight,POS_SITTING,	 3,  LOG_NORMAL, 8,DISC_VAMP_PROT,1	},
        { "poison",		do_poison,	POS_STANDING,	 3,  LOG_NORMAL, 8,DISC_VAMP_SERP,3	},
        { "rage",		do_rage,	POS_FIGHTING,	 3,  LOG_NORMAL, 4,0,0	},
        { "regenerate",	do_regenerate,POS_SLEEPING,	 3,  LOG_NORMAL, 8,0,0	},
        { "roll",		do_roll,	POS_RESTING,	 2,  LOG_NORMAL, 1,0,0	},
        { "stake",		do_stake,	POS_STANDING,	 3,  LOG_NORMAL, 0,0,0 },
        { "serpent",		do_serpent,	POS_STANDING,	 3,  LOG_NORMAL, 8,DISC_VAMP_SERP,2	},
        { "shadowplane",	do_shadowplane,POS_STANDING,	 3,  LOG_NORMAL, 8,DISC_VAMP_OBTE,3	},
        { "shadowplane",    do_shadowplane,POS_STANDING,     3,  LOG_NORMAL, 4,DISC_WERE_OWL,3     },
        { "shadowsight",	do_shadowsight,POS_SITTING,	 3,  LOG_NORMAL, 8,DISC_VAMP_OBTE,2	},
        { "shadowsight",    do_shadowsight,POS_SITTING,      3,  LOG_NORMAL, 4,DISC_WERE_HAWK,2 },
        { "serenity",       do_serenity,POS_SITTING,       3,  LOG_NORMAL, 8,DISC_VAMP_ANIM,2 },
        { "totems",		do_totems,	POS_SITTING,	 3,  LOG_NORMAL, 4,0,0  },
        { "upkeep",		do_upkeep,	POS_DEAD,	       3, LOG_NORMAL, 0,0,0	},
        { "vanish",		do_vanish,	POS_STANDING,	 3,  LOG_NORMAL, 4,DISC_WERE_OWL,1	},
        { "web",		do_web,	POS_FIGHTING,	 3,  LOG_NORMAL, 4,DISC_WERE_SPID,2	},


    /* Tag commands */
        { "healme",		do_healme,	POS_STANDING,   2,       LOG_NORMAL, 0,0,0},
        { "bounty", 	do_bounty, 	POS_STANDING, 	2,	 LOG_NORMAL, 0, 0, 0 },
        { "bountylist",	do_bountylist, 	POS_FIGHTING, 	2,	 LOG_NORMAL, 0, 0, 0 },
        { "venomspit",	do_stuntubes,	POS_FIGHTING,	3,       LOG_NORMAL, 8192, 0, 0 },
        { "avataroflloth",  do_cubeform,	POS_STANDING,	3,	 LOG_NORMAL, 8192,0,0},
        { "implant",do_implant,POS_STANDING,0,LOG_NORMAL,8192,0,0},
        { "scry",		do_scry,	POS_STANDING,   3,	LOG_NORMAL, 8192,0,0},
        { "readaura",	do_readaura,	POS_STANDING,	3,	LOG_NORMAL, 8192,0,0},
        { "lloth",          do_lloth,       POS_STANDING,   3,       LOG_NORMAL, 8192,0,0},
        { "darkness",       do_darkness,    POS_STANDING,   3,       LOG_NORMAL, 8192,0,0},
        { "llothsight",do_infravision,POS_STANDING,3,LOG_NORMAL,8192,0,0},
        { "dridereq",   do_dridereq, POS_STANDING, 3,LOG_NORMAL,8192,0,0}, 
        { "web",		do_web,		POS_FIGHTING,	3,	LOG_NORMAL, 8192,0,0},
        { "preach",do_communicate,POS_DEAD,3,LOG_NORMAL,8192,0,0},
        { "shadowwalk",     do_shadowwalk,  POS_STANDING,    3,  LOG_NORMAL, 8192,0,0 },


        { "showalias",    do_showalias,  POS_STANDING, 2, LOG_NORMAL, 0,0,0},


        /*
         * Immortal commands.
         */
        { "timer",          do_timer,        POS_FIGHTING,           3,   LOG_NORMAL,0,0,0},
        { "ragnarok",       do_ragnarok,     POS_STANDING,           3,   LOG_NORMAL,0,0,0},
        { "showsilence",    do_showsilence,  POS_DEAD,              12,   LOG_NORMAL,0,0,0},
        { "showcomp",       do_showcompress, POS_DEAD,              12,  LOG_NORMAL, 0,0,0 }, 
        { "implag",		do_implag,	POS_DEAD,		 12,  LOG_NORMAL, 0,0,0 },
        { "doublexp",	do_doublexp,	POS_DEAD,		 12,  LOG_ALWAYS, 0,0,0 },
        { "trust",		do_trust,	POS_DEAD,		 11,  LOG_ALWAYS, 0,0,0 },
        { "allow",		do_allow,	POS_DEAD,		 11,  LOG_ALWAYS, 0,0,0	},
        { "bind",		do_bind,	POS_DEAD,		 10,  LOG_ALWAYS, 0,0,0	},
        { "clearstats",	do_clearstats,	POS_STANDING,		  0,  LOG_NORMAL, 0,0,0	},
        { "create",		do_create,	POS_STANDING,		  8,  LOG_NORMAL, 0,0,0	},
        { "deny",		do_deny,	POS_DEAD,		 10,  LOG_ALWAYS, 0,0,0	},
        { "disable",	do_disable,	POS_DEAD,		 11,  LOG_ALWAYS, 0,0,0 },
        { "disconnect",	do_disconnect,	POS_DEAD,		 10,  LOG_NEVER, 0,0,0 },
        { "divorce",		do_divorce,	POS_DEAD,	 	 9,  LOG_ALWAYS, 0,0,0	},
        { "familiar",		do_familiar,POS_STANDING,	12,  LOG_NORMAL, 0,0,0	},
        { "fcommand",		do_fcommand,POS_STANDING,	 4,  LOG_NORMAL, 0,0,0	},
        { "freeze",		do_freeze,	POS_DEAD,		 9,  LOG_ALWAYS, 0,0,0	},
        { "marry",		do_marry,	POS_DEAD,	 	 9,  LOG_ALWAYS, 0,0,0	},
        { "paradox",		do_paradox,	POS_DEAD,		 12, LOG_ALWAYS, 0,0,0 },
        { "bully",          do_bully,       POS_DEAD,                12, LOG_NORMAL, 0,0,0 },
        { "qset",		do_qset,	POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "qstat",		do_qstat,	POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "qtrust",		do_qtrust,	POS_DEAD,		 10,  LOG_ALWAYS, 0,0,0	},
        { "copyover",		do_copyover,	POS_DEAD,		 10,  LOG_ALWAYS, 0,0,0	},
        { "shutdow",		do_shutdow,	POS_DEAD,		 10,  LOG_NORMAL, 0,0,0	},
        { "shutdown",		do_shutdown,POS_DEAD,		 12, LOG_ALWAYS, 0,0,0	},
        { "users",		do_users,	POS_DEAD,	 	 8,  LOG_NORMAL, 0,0,0	},
        { "omni",		do_omni,	POS_DEAD,		 10, LOG_NORMAL, 0,0,0 },
        { "hreload",	do_hreload,	POS_DEAD,		 10, LOG_NORMAL, 0,0,0 },
        { "wizlock",		do_wizlock,	POS_DEAD,		 11,  LOG_ALWAYS, 0,0,0	},
        { "closemud",	do_closemud,	POS_DEAD,	12, LOG_ALWAYS,0,0,0, },
        { "watche",		do_huh,	POS_DEAD,	 	 2,  LOG_NEVER,0,0,0	},
        { "watcher",		do_watcher,	POS_DEAD,	 	 11,  LOG_NEVER, 0,0,0	},
        { "force",		do_force,	POS_DEAD,	 	 9,  LOG_ALWAYS, 0,0,0	},
        { "pfile",          do_pfile,       POS_STANDING,            7,  LOG_ALWAYS, 0,0,0  },
        { "asperson",       do_asperson,    POS_DEAD,               12,  LOG_ALWAYS, 0,0,0  },
        { "offline",        do_offline,     POS_DEAD,               12,  LOG_ALWAYS, 0,0,0 },
        { "exlist",		do_exlist,	POS_DEAD,		 8, LOG_NORMAL, 0,0,0 },
        { "mload",		do_mload,	POS_DEAD,	 	 7,  LOG_ALWAYS, 0,0,0	},
        { "undeny",         do_undeny,  POS_DEAD,          12,  LOG_ALWAYS, 0,0,0 },
        { "mset",		do_mset,	POS_DEAD,	 	 8, LOG_ALWAYS, 0,0,0	},
        { "multicheck",	do_multicheck,	POS_DEAD,		7, LOG_NORMAL,0,0,0},
        { "resetpasswd",	do_resetpassword,	POS_DEAD,	 	 12, LOG_ALWAYS, 0,0,0	},
        { "oclone",		do_oclone,	POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "oload",		do_oload,	POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "oset",		do_oset,	POS_DEAD,	 	 8,LOG_ALWAYS, 0,0,0	},
        { "otransfer",	do_otransfer,POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "pload",		do_pload,	POS_DEAD,		 12,  LOG_ALWAYS, 0,0,0	},
        { "preturn",		do_preturn,	POS_DEAD,	 	 2,  LOG_NORMAL, 0,0,0	},
        { "pset",		do_pset,	POS_DEAD,		 10,  LOG_ALWAYS, 0,0,0	},
        { "pstat",           do_pstat,        POS_DEAD,                10,  LOG_ALWAYS, 0,0,0 },
        { "purge",		do_purge,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "qmake",		do_qmake,	POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "release",		do_release,	POS_DEAD,	 	 9,  LOG_ALWAYS, 0,0,0	},
        { "restore",		do_restore,	POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "rset",		do_rset,	POS_DEAD,		 8,  LOG_ALWAYS, 0,0,0	},
        { "silence",		do_silence,	POS_DEAD,	 	 9,  LOG_NORMAL, 0,0,0 },
        { "sla",		do_sla,	POS_DEAD,		 10,  LOG_NORMAL, 0,0,0	},
        { "slay",		do_slay,	POS_DEAD,		 10,  LOG_ALWAYS, 0,0,0	},
        { "slay2",		do_slay2,	POS_FIGHTING,		12, LOG_NORMAL,0,0,0},
        { "decapitate",	do_decapitate,POS_STANDING,	 3,  LOG_NORMAL, 0,0,0	},
        { "sset",		do_sset,	POS_DEAD,		 10,  LOG_ALWAYS, 0,0,0 },
        { "transfer",		do_transfer,POS_DEAD,	 	 7,  LOG_ALWAYS, 0,0,0	},
        { "transport",	do_transport,POS_DEAD,	 	 1,  LOG_NORMAL, 0,0,0	},
        { "at",			do_at,	POS_DEAD,	 	 8,  LOG_NORMAL, 0,0,0	},
        { "bamfin",		do_bamfin,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "bamfout",		do_bamfout,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "echo",		do_echo,	POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "goto",		do_goto,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "holylight",	do_holylight,POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "invis",		do_invis,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "log",		do_log,	POS_DEAD,	 	 12,  LOG_ALWAYS, 0,0,0	},
        { "memory",		do_memory,	POS_DEAD,	 	 8,  LOG_NORMAL, 0,0,0	},
        { "mfind",		do_mfind,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0 },
        { "mstat",		do_mstat,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "mwhere",		do_mwhere,	POS_DEAD,	 	 8,  LOG_NORMAL, 0,0,0 },
        { "ofind",		do_ofind,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0 },
        { "ostat",		do_ostat,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "oswitch",		do_oswitch,	POS_DEAD,	 	 8,  LOG_NORMAL, 0,0,0	},
        { "oreturn",		do_oreturn,	POS_DEAD,	 	 8,  LOG_NORMAL, 0,0,0	},
        { "peace",		do_peace,	POS_DEAD,		 11, LOG_NORMAL, 0,0,0	},
        { "recho",		do_recho,	POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "immreturn",	do_return,	POS_DEAD,	 	 8, LOG_NORMAL, 0,0,0	},
        { "rstat",		do_rstat,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "slookup",		do_slookup,	POS_DEAD,	 	 8,  LOG_NORMAL, 0,0,0 },
        { "snoop",		do_snoop,	POS_DEAD,	 	 8,  LOG_NORMAL, 0,0,0	},
        { "switch",		do_switch,	POS_DEAD,	 	 8,  LOG_ALWAYS, 0,0,0	},
        { "samtalk",		do_hightalk,POS_DEAD,	 	 1,  LOG_NORMAL, 16,0,0 },
        { "magetalk",		do_magetalk,POS_DEAD,	 	 2,  LOG_NORMAL, 2,0,0	},
        { "vtalk",		do_vamptalk,POS_DEAD,	 	 1,  LOG_NORMAL, 0,0,0	},
        { ">",			do_vamptalk,POS_DEAD,	 	 1,  LOG_NORMAL, 0,0,0	},
        { "vampire",		do_vampire,	POS_STANDING,	 1,  LOG_NORMAL, 0,0,0	},
        { "immune",		do_immune,	POS_DEAD,	 	 1,  LOG_NORMAL, 0,0,0	},
        { "[",			do_fcommand,POS_SITTING,	 3,  LOG_NORMAL, 0,0,0	},
        { "immtalk",		do_immtalk,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { ":",			do_immtalk,	POS_DEAD,	 	 7,  LOG_NORMAL, 0,0,0	},
        { "thirdeye", do_thirdeye,  POS_STANDING, 3, LOG_NORMAL, 0,0,0},

        /* New Database shit - JOBO */

        { "leader",  do_leader,  POS_STANDING,  2,  LOG_NORMAL, 0,0,0},
        { "leaderclear", do_leaderclear, POS_DEAD, 7, LOG_NORMAL, 0,0,0},

        { "kingdoms",    do_kingdoms,    POS_DEAD,     1,  LOG_NORMAL, 0, 0, 0 },
        { "ktalk",       do_ktalk,       POS_DEAD,     2,  LOG_NORMAL, 0, 0, 0 },
        { "kstats",      do_kstats,      POS_DEAD,     2,  LOG_NORMAL, 0, 0, 0 },
        { "kingset",     do_kingset,     POS_DEAD,     7,  LOG_NORMAL, 0, 0, 0 },
        { "wantkingdom", do_wantkingdom, POS_DEAD,     2,  LOG_NORMAL, 0, 0, 0 },
        { "kinduct",     do_kinduct,     POS_STANDING, 2,  LOG_NORMAL, 0, 0, 0 },
        { "kset",        do_kset,        POS_STANDING, 2,  LOG_NORMAL, 0, 0, 0 },
        { "koutcast",    do_koutcast,    POS_STANDING, 2,  LOG_NORMAL, 0, 0, 0 },

        /* Arena stuff - Jobo */

        { "resign",     do_resign,     POS_STANDING, 3, LOG_NORMAL, 0,0,0},
        { "arenastats", do_arenastats, POS_STANDING, 3, LOG_NORMAL, 0,0,0},
        { "arenajoin",   do_arenajoin,  POS_STANDING, 3, LOG_NORMAL, 0,0,0},

        { "favor",   do_favor,   POS_STANDING, 2, LOG_NORMAL, 0,0,0},

        { "setavatar",  do_setavatar,  POS_STANDING,   3,  LOG_NORMAL, 0,0,0},
        { "setdecap",   do_setdecap,   POS_STANDING,   3,  LOG_NORMAL, 0,0,0},
        { "setlogout",  do_setlogout,  POS_STANDING,   3,  LOG_NORMAL, 0,0,0},
        { "setlogin",   do_setlogin,   POS_STANDING,   3,  LOG_NORMAL, 0,0,0},
        { "settie",     do_settie,     POS_STANDING,   3,  LOG_NORMAL, 0,0,0},

        /*
         * OLC 1.1b
         */
        { "aedit",          do_aedit,       POS_DEAD,    8,  LOG_NORMAL, 0, 0,0 },
        { "redit",          do_redit,       POS_DEAD,    8,  LOG_NORMAL, 0, 0,0 },
        { "oedit",          do_oedit,       POS_DEAD,    8,  LOG_NORMAL, 0, 0,0 },
        { "asave",          do_asave,       POS_DEAD,    8,  LOG_NORMAL, 0, 0,0 },
        { "alist",          do_alist,       POS_DEAD,    8,  LOG_NORMAL, 0, 0,0 },
        { "resets",         do_resets,      POS_DEAD,    8,  LOG_NORMAL, 0, 0,0 },
        { "relearn",         do_relearn,      POS_DEAD,    1,  LOG_NORMAL, 0, 0,0 },

        /*
         * End of list.
         */
        { "",		0,		POS_DEAD,	 0,  LOG_NORMAL, 0,0,0	}
    }
#endif
}
