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

namespace ReaperKing.StaticConfig.Data
{
    public struct NpcSpawnGroup
    {
        public string AnEntryName { get; set; }
        // ReSharper disable InconsistentNaming
        public string NPCsToSpawn { get; set; }
        public string NPCsSpawnOffsets { get; set; }
        public string NPCsToSpawnPercentageChance { get; set; }
        // ReSharper restore InconsistentNaming
    }
}