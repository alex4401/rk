/*!
 * This file is a part of Reaper King, and the project's repository may be
 * found at https://github.com/alex4401/ReaperKing.
 *
 * The project is free software: you can redistribute it and/or modify it
 * under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or (at
 * your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See
 * the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see http://www.gnu.org/licenses/.
 */

namespace ReaperKing.Anhydrate.Models
{
    public struct GutterLayoutSection
    {
        public string Id { get; init; }
        public SectionType Type { get; init; }
        public string CustomClass { get; init; }
        public string HtmlId { get; init; }

        public enum SectionType
        {
            Full,
            Grid,
            Row,
            NarrowFit,
            Narrower,
            Break,
            BreakMobile,
            Custom,
        }
    }
}