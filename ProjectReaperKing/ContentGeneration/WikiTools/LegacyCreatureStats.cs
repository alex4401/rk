using SiteBuilder.Core;

namespace ProjectReaperKing.ContentGeneration.WikiTools
{
    public class LegacyCreatureStats : IPageGenerator
    {
        public PageGenerationResult Generate(SiteContext ctx)
        {
            return new PageGenerationResult
            {
                Uri = "legacy",
                Name = "stats",
                Template = "wiki/legacyCreatureStats.cshtml",
                Model = new 
                {
                    Super = ctx.AcquireBaseModel(SiteName: "Legacy Tools",
                                                 DisplayTitle: "~alex/stats.html"),
                },
            };
        }
    }
}