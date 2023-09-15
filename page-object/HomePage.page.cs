using Microsoft.Playwright;

namespace SpringBoard.Tests.Models
{
    public class SpringBoardHomePage: BasePage
    {
        private readonly IPage _page;
        public readonly ILocator _brandLogo;

        public readonly ILocator _loginButton;

        public readonly ILocator _emailTextBox;

        public readonly ILocator _passwordTextBox;

        public readonly ILocator _errorText;

        public readonly ILocator _submitLoginButton;

        public readonly ILocator _blogLink;

        public readonly ILocator _facebookLoginButton;

        public readonly ILocator _linkedlnLoginButton;

        public readonly ILocator _googleLoginButton;

        public SpringBoardHomePage(IPage page) : base(page)
        {
            this._page = page;
            this._brandLogo = this._page.Locator("figure.brand-logo");
            this._loginButton = this._page.Locator("p", new () {HasText = "Login"}).First;
            this._emailTextBox = this._page.Locator("input[type='email']").First;
            this._passwordTextBox = this._page.Locator("input[type='password']").First;
            this._errorText = this._page.GetByText("The e-mail address and/or password you specified are not correct.", new() {Exact = true});
            this._submitLoginButton = this._page.GetByRole(AriaRole.Button, new() {Name = "Login"});
            this._blogLink = this._page.Locator("p", new () {HasText = "Blog"}).First;
            this._facebookLoginButton = this._page.Locator(".socialLoginButton.facebook");
            this._googleLoginButton = this._page.Locator(".socialLoginButton.google");
            this._linkedlnLoginButton = this._page.Locator(".socialLoginButton.linkedin");
        }

        public async Task<BlogPage> ClickBlogLink()
        {
            await this._blogLink.ClickAsync();
            return new BlogPage(this._page);
        }
    }
}