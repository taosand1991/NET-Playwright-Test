using Microsoft.Playwright;

namespace SpringBoard.Tests.Models
 {

    public class BlogPage: BasePage
    {
        private readonly IPage _page;
        public readonly ILocator _emailTextBox;

        public readonly ILocator _suscribeButton;

        public readonly ILocator _searchBlogTextBox;

        public readonly ILocator _searchBlogButton;

        public BlogPage(IPage page): base(page)
        {
            this._page = page;
            this._emailTextBox = this._page.GetByPlaceholder("Enter your email", new () {Exact = true});
            this._suscribeButton = this._page.GetByRole(AriaRole.Button, new() {Name = "Subscribe"}).First;
            this._searchBlogTextBox = this._page.Locator("#search");
            this._searchBlogButton = this._page.Locator(".search-button");
        }

    }
}
