/*!
 * This file is a part of the open-sourced engine modules for
 * https://alex4401.github.io, and those modules' repository may be found
 * at https://github.com/alex4401/ReaperKing.
 *
 * The project is free software: you can redistribute it and/or modify it
 * under the terms of the GNU Affero General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Affero General Public License for more details.
 *
 * You should have received a copy of the GNU Affero General Public License
 * along with this program. If not, see http://www.gnu.org/licenses/.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;

namespace ReaperKing.Generation.ARK.Data
{
    public partial class DataManagerARK
    {
        private IEnumerable<ModInfo.Revision> _initModRevisions(ILogger log, string modId)
        {
            var searchPath = Path.Join(GetDataDirectoryPath(), modId);
            string[] revFiles = Directory.GetFiles(searchPath, "revision.yaml", SearchOption.AllDirectories);
            Array.Sort(revFiles);
            log.LogInformation($"{revFiles.Length} revisions have been found for {modId}");

            foreach(string filepath in revFiles)
            {
                string revisionPath = filepath.Remove(0, GetDataDirectoryPath().Length);
                revisionPath = revisionPath.Remove(revisionPath.Length - 5, 5);
                var revision = ReadYamlFile<ModInfo.Revision>(revisionPath, "revision");
                log.LogInformation($"Revision \"{revisionPath}\" of type \"{revision.Tag}\" has been loaded");
                revision.PathOnDisk = revisionPath.Remove(revisionPath.Length - 8, 8);

                if (revision.Tag == RevisionTag.ModUpdate
                    || revision.Tag == RevisionTag.ModInitDataUpdate)
                {
                    var initDataPath = Path.Join(revision.PathOnDisk, "ModInitialization");
                    var initData = ReadJsonFile<ModInitializationData>(initDataPath);
                    revision.InitData = initData;
                }
                
                yield return revision;
            }
        }

        public IEnumerable<Tuple<int, ModInfo.Revision>> FindModRevisionsByTag(string modId, RevisionTag tag)
        {
            var revList = LoadedMods[modId].Revisions;
            for (int index = revList.Count - 1; index >= 0; index--)
            {
                var revision = revList[index];
                
                if (revision.Tag == tag)
                {
                    yield return new Tuple<int, ModInfo.Revision>(index, revision);
                }
            }
        }

        public IEnumerable<Tuple<int, ModInfo.Revision>> FindModRevisionsByTags(string modId, RevisionTag[] tags)
        {
            var revList = LoadedMods[modId].Revisions;
            for (int index = revList.Count - 1; index >= 0; index--)
            {
                var revision = revList[index];
                
                if (((IList) tags).Contains(revision.Tag))
                {
                    yield return new Tuple<int, ModInfo.Revision>(index, revision);
                }
            }
        }

        public Dictionary<string, int> MapLegacyRevisionsToMaps(string modId)
        {
            var worldRevMap = new Dictionary<string, int>();
            
            // Map out old-style revisions to worlds.
            foreach (var pair in DataManagerARK.Instance.FindModRevisionsByTag(modId, RevisionTag.ModUpdateLegacy))
            {
                var index = pair.Item1;
                var revision = pair.Item2;
                
                foreach (string worldRef in revision.Contents)
                {
                    if (!worldRevMap.ContainsKey(worldRef))
                    {
                        worldRevMap[worldRef] = index;
                    }
                }
            }

            return worldRevMap;
        }
    }
}