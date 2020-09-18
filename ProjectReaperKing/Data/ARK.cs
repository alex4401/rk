using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using ProjectReaperKing.Data;
using ProjectReaperKing.Data.ARK;
using ShellProgressBar;
using SiteBuilder.Core;

// TODO: just... uh... i don't know, refactor this in multiple ways

namespace ProjectReaperKing.Data
{
    public partial class DataManagerARK : DataManager
    {
        public static readonly DataManagerARK Instance = new DataManagerARK();
        
        public readonly Dictionary<string, MapInfo> LoadedMaps = new Dictionary<string, MapInfo>();
        public readonly Dictionary<string, ModInfo> LoadedMods = new Dictionary<string, ModInfo>();
        
        public override string GetTag() => "ark";

        public override void LoadObject(string objectName, string objectType) {
            string objectPath = objectName;
            if (objectType == "mod")
            {
                objectPath = objectName + "/mod";
            }
            
            switch (objectType)
            {
                case "mod":
                    var mod = ReadYamlFile<ModInfo>(objectPath, "mod");
                    mod.InternalId = objectName;
                    LoadedMods[objectName] = mod;
                    break;
                    
                case "map":
                    var map = ReadYamlFile<MapInfo>(objectPath, "map");
                    map.InternalId = objectName.Split('/', 2)[1];
                    LoadedMaps[objectName] = map;
                    break;
            }
        }
        
        public override void Initialize(ChildProgressBar pbar)
        {
            base.Initialize(pbar);
            var baseMessage = pbar.Message;
            
            pbar.MaxTicks += LoadedMods.Count;
            foreach (var modId in LoadedMods.Keys.ToArray())
            {
                pbar.Tick($"{baseMessage}: {modId}");
                
                var mod = LoadedMods[modId];
                mod.Revisions = _initModRevisions(pbar, modId, baseMessage).ToList();
                LoadedMods[modId] = mod;
            }
        }
        
    }
}