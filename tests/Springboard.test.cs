using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using SpringBoard.Tests.Models;

[TestFixture]
public class SpringBoardTests: PageTest
{
    [Test]
    public async Task OpenSpringBoardHomePage()
    {
        var springBoardPage = new SpringBoardHomePage(Page);
        await springBoardPage.OpenUrl();

        await Expect(springBoardPage.GetPage()).ToHaveTitleAsync(new Regex("Springboard: Online Courses"));
    }

    [Test]
    public async Task OpenLoginPage()
    {
        var springBoardPage = new SpringBoardHomePage(Page);
        await springBoardPage.OpenUrl();
        await springBoardPage._loginButton.ClickAsync();

        await Expect(springBoardPage._emailTextBox).ToBeVisibleAsync();
        await Expect(springBoardPage._passwordTextBox).ToBeVisibleAsync();
    }

    [Test]
    public async Task LoginWithInvalidAccount()
    {
        var springBoardPage = new SpringBoardHomePage(Page);
        await springBoardPage.OpenUrl();
        await springBoardPage._loginButton.ClickAsync();
        await springBoardPage._emailTextBox.FillAsync("taofeek@gmail.com");
        await springBoardPage._passwordTextBox.FillAsync("police1991");
        await springBoardPage._submitLoginButton.ClickAsync();

        await Expect(springBoardPage._errorText).ToBeVisibleAsync();
    }

    [Test]
    public async Task VerifyBlogPage()
    {
        var springboardPage = new SpringBoardHomePage(Page);
        await springboardPage.OpenUrl();
        var blogPage = await springboardPage.ClickBlogLink();
        
        await Expect(blogPage._emailTextBox).ToBeVisibleAsync();
        await Expect(blogPage._suscribeButton).ToBeVisibleAsync();
    }
}