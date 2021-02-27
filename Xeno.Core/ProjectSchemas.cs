/*!
 * This file is a part of Xeno, and the project's repository may be found at https://github.com/alex4401/rk.
 *
 * The project is free software: you can redistribute it and/or modify it under the terms of the GNU General Public
 * License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with this program. If not, see
 * http://www.gnu.org/licenses/.
 */

using Xeno.Core.Configuration;

namespace Xeno.Core
{
    namespace Schemas
    {
        [RkSchema("*")]
        public class Any : Schema
        { }

        [RkSchema("Xeno/Minimal/v*")]
        public class Minimal : Schema
        {
            public override PropertyDescriptor[] Properties
                => new PropertyDescriptor[]
                {
                    new("1", typeof(WebConfiguration)),
                    new("2", typeof(ImmutableRuntimeConfiguration)),
                };
        }
        
        [RkSchema("Xeno/v2")]
        public class V2 : Schema
        {
            public override PropertySetDescriptor[] PropertySets
                => new PropertySetDescriptor[]
                {
                    new("rk", new PropertyDescriptor[]
                    {
                        new("web", typeof(WebConfiguration)),
                        new("resources", typeof(ResourcesConfiguration)),
                    }),
                    new("modules", new PropertyDescriptor[] { }),
                };
        }
    }
}