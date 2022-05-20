module.exports = [
	{
		token: "",
		port: 7777,
		host: 'localhost',
		/* Must match the token from the plugin's config */
		PluginToken: 'YourTokenChangeThisForSafety',
		name: "Light RP",
		/* prefix for rasend. Ex command usage: $list */
		prefix: "$",
		/* main logs */
		logs: "816260046547714070",
		/* remote admin logs */
		ralogs: "721380128432717935",
		/* send command to server channel */
		rasend: "817333851713175552",
		/* team kills logs */
		tklogs: "706170791028588644",
		/* bans & kicks logs */
		bklogs: "721377600672628736",
		translate: {
			ban: 'Ban',
			ban_msg: '%banned% has been banned by %banner%. Reason: %reason%\nUntil %to%',
			kick: 'Kick',
			kick_msg: '%kicked% has been kicked by %kicker%. Reason: %reason%',
			disconnect: '⚠️ Server disconnected.',
			connect: '\\✔️ Server connected.',
			player: "player",
			players: "players",
			/* for ru(винительный падеж(игрока)) */
			playera: "players",
			no_server: 'server offline',
		}
	},/*
	{
		token: "",
		port: 7779,
		host: 'localhost',
		PluginToken: 'YourTokenChangeThisForSafety',
		name: "",
		prefix: "$",
		logs: "",
		ralogs: "",
		rasend: "",
		tklogs: "",
		bklogs: "",
		translate: {
			ban: 'Ban',
			ban_msg: '%banned% has been banned by %banner%. Reason: %reason%\nUntil %to%',
			kick: 'Kick',
			kick_msg: '%kicked% has been kicked by %kicker%. Reason: %reason%',
			disconnect: '⚠️ Server disconnected.',
			connect: '\\✔️ Server connected.',
			player: "player",
			players: "players",
			playera: "players",
			no_server: 'server offline',
		}
	},*/
]