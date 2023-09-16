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

        public async Task OpenUrl(string url = "https://www.springboard.com")
        {
            await this._page.GotoAsync(url);
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