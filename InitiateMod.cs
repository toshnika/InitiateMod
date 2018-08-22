using Terraria.ModLoader;

namespace InitiateMod
{
	class InitiateMod : Mod
	{
		public InitiateMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
