using Microsoft.Playwright;

namespace SpringBoard.Tests.Models
{
    public class BasePage
    {
        private readonly IPage _page;

        public BasePage(IPage page)
        {
            this._page = page;
        }

        public async Task OpenUrl()
        {
            await this._page.GotoAsync("https://www.springboard.com/");
        }

        public IPage GetPage()
        {
            return this._page;
        }

        public string GetUrl()
        {
            return this._page.Url;
        }

    }
}